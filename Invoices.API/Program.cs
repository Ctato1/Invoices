using AutoMapper;
using Invoice.API.DBContext;
using Invoice.API.DTOs;
using Invoice.API.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<InvoiceContext>(
               o => o.UseSqlite(builder.Configuration["ConnectionStrings:InvoiceStr"])
           );

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//for automapper
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(Program));  // ??, ?? ???? ?????? ????? ?????????????????



var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Hello World!");


app.MapGet("/api/invoice/{invoiceId}", async Task<Results<NotFound, Ok<InvoicesForCreatingDTO>>> (InvoiceContext context,
    IMapper mapper,
    string invoiceId) =>
{
    var invoice = await context.Invoices
        .Include(x => x.SenderAddress)
        .Include(x => x.ClientAddress)
        .Include(x => x.Items)
        .FirstOrDefaultAsync(x => x.Id == invoiceId);

    if (invoice == null)
    {
        return TypedResults.NotFound();
    }

    var invoiceDTO = mapper.Map<InvoicesForCreatingDTO>(invoice);
    return TypedResults.Ok(invoiceDTO);
}).WithName("GetInvoice");

// Add Invoice
/*app.MapPost("/api/invoice", async (InvoiceContext context, IMapper mapper, [FromBody] InvoicesForCreatingDTO invoiceCreatingDTO) =>
{
    var invoice = mapper.Map<Invoices>(invoiceCreatingDTO);
    context.Add(invoice);

    await context.SaveChangesAsync();


});*/

app.Run();

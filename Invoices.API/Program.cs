using AutoMapper;
using Invoice.API.DBContext;
using Invoice.API.DTOs;
using Invoice.API.Entities;
using Invoices.API.EndpointHandler;
using Microsoft.AspNetCore.Builder;
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
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Hello World!");


app.MapGet("/api/invoice/{invoiceId}", InvoiceHandlers.GetInvoicesById).WithName("GetInvoice");
app.MapGet("/api/invoices", InvoiceHandlers.GetInvoices).WithName("GetInvoices");
app.MapPost("{invoiceId}/add-item", InvoiceHandlers.AddItemToInvoice);

// Add Invoice
/*app.MapPost("/api/invoice", async Task<CreatedAtRoute<InvoiceDTO>>(
    InvoiceContext context,
    IMapper mapper,
    [FromBody] InvoicesForCreatingDTO invoiceCreatingDTO) =>
{
    // Map DTO to InvoiceEntity
    var invoice = mapper.Map<InvoiceEntity>(invoiceCreatingDTO);

    // Add new invoice to context
    context.Add(invoice);

    // Save changes (including InvoiceItems)
    await context.SaveChangesAsync();

    // Return the newly created invoice
    var invoiceToReturn = mapper.Map<InvoiceDTO>(invoice);
    return TypedResults.CreatedAtRoute(
        invoiceToReturn,
        "GetInvoice",  // The name of the route to fetch the created invoice
        new { invoiceId = invoiceToReturn.Id }
    );
});
*/
app.MapPost("/api/invoice", InvoiceHandlers.PostInvoice);


app.Run();

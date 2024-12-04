using AutoMapper;
using Invoice.API.DBContext;
using Invoice.API.DTOs;
using Invoice.API.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Invoices.API.EndpointHandler
{
    public class InvoiceHandlers
    {
        public static async Task<Results<NotFound, Ok<InvoiceDTO>>> GetInvoicesById
            (InvoiceContext context,
            IMapper mapper,
            string invoiceId) 
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

            var invoiceDTO = mapper.Map<InvoiceDTO>(invoice);
            return TypedResults.Ok(invoiceDTO);
        }

        public static async Task<ActionResult<IEnumerable<InvoiceDTO>>> GetInvoices(
            InvoiceContext context,
            IMapper mapper)
        {
            var invoices = await context.Invoices
                .Include(i => i.SenderAddress)
                .Include(i => i.ClientAddress)
                .Include(i => i.Items)
                .ToListAsync();

            return mapper.Map<List<InvoiceDTO>>(invoices);
        }

        public static async Task<Results<NotFound<string>,BadRequest<string>, Ok<InvoiceDTO>>> AddItemToInvoice(
        InvoiceContext context,
        IMapper mapper,
        string invoiceId,
        [FromBody] ItemDTO newItemDto)
        {
            // მოძებნე ინვოისი ID-ის მიხედვით
            var invoice = await context.Invoices
                .Include(i => i.Items) // დატვირთე Items
                .FirstOrDefaultAsync(i => i.Id == invoiceId);

            if (invoice == null)
            {
                return TypedResults.NotFound($"Invoice with ID '{invoiceId}' not found.");
            }

            // ვალიდაცია
            if (newItemDto.Quantity <= 0 || newItemDto.Price < 0)
            {
                return TypedResults.BadRequest("Invalid item details. Quantity must be greater than 0 and price non-negative.");
            }

            // გარდაქმნა DTO -> Entity
            var newItem = mapper.Map<Item>(newItemDto);

            // დაამატე ახალი Item ინვოისში
            invoice.Items.Add(newItem);

            // გადათვალე ჯამი
            invoice.Total = invoice.Items.Sum(i => i.Total);

            // შეინახე ცვლილებები
            await context.SaveChangesAsync();

            // დააბრუნე განახლებული ინვოისი
            return TypedResults.Ok(mapper.Map<InvoiceDTO>(invoice));
        }


        public static async Task<Results<CreatedAtRoute<InvoiceDTO>, BadRequest<string>>> PostInvoice 
            (InvoiceContext context,
            IMapper mapper,
            [FromBody] InvoiceDTO invoiceDTO) 
        {
                var invoice = mapper.Map<InvoiceEntity>(invoiceDTO);

                context.Add(invoice);

                await context.SaveChangesAsync();

                var invoiceToReturn = mapper.Map<InvoiceDTO>(invoice);
                return TypedResults.CreatedAtRoute(invoiceToReturn,"GetInvoice",  new { invoiceId = invoiceToReturn.Id});
        }


    }
}

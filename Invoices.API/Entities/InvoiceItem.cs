namespace Invoice.API.Entities
{
    public class InvoiceItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Total { get; set; }
        public string InvoiceId { get; set; }
    }
}

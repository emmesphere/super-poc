namespace SuperPoc.BuildingBlocks.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public string Description { get; set; }

        public Product(string productName, string description, decimal unitPrice)
        {
            ProductName = productName;
            Description = description;
            UnitPrice = unitPrice;
        }
    }

}

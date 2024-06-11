namespace Course_History.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }

        public string OrderCode { get; set; }

        public string UserName { get; set; }

        public int ProductId { get; set; }

        public double Price{ get; set; }

        public int Quantity { get; set; }

        public ProductModel Product { get; set; }

    }
}

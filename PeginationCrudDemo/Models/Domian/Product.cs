namespace PeginationCrudDemo.Models.Domian
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }

         public int Pagesize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }

    }
}

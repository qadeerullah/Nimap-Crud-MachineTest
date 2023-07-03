namespace PeginationCrudDemo.Models
{
	public class UpdateProductViewModel
	{
		public Guid ProductId { get; set; }
		public string ProductName { get; set; }
		public Guid CategoryId { get; set; }
		public string CategoryName { get; set; }
	}
}

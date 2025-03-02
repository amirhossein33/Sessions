namespace EfProject.Models
{
    public class Payment
    {

        public int PaymentId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string? PaymentMethod { get; set; }



        public Order? Order { get; set; }
        public Customer? Customer { get; set; }
        public string? CustomerId { get;  set; }
        public int OrderId { get;  set; }
    }

}



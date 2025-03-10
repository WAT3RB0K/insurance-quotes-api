namespace InsuranceQuoteApp.Data
{
    public class Quote
    {
        public int Id { get; set; } // Primary Key
        public decimal Amount { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = new Customer();

        public int InsurancePlanId { get; set; }
        public required InsurancePlan InsurancePlan { get; set; } = new InsurancePlan();
        public DateTime StartDate = DateTime.Now;
    }
}

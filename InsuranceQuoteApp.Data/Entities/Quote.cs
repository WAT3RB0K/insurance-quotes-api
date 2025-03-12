namespace InsuranceQuoteApp.Data
{
    public class Quote
    {
        public int Id { get; set; } // Primary Key
        public decimal Amount { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public int InsurancePlanId { get; set; }
        public InsurancePlan? InsurancePlan { get; set; }        
        public DateTime StartDate = DateTime.Now;
    }
}

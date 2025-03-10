namespace InsuranceQuoteApp.BusinessLogic.Models
{
    public class InsuranceQuoteDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string InsurancePlanName { get; set; } = string.Empty;
        public decimal QuoteAmount { get; set; }
    }
}

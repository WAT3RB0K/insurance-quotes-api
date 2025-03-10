namespace InsuranceQuoteApp.BusinessLogic;

public class HealthInsuranceService
{
    public decimal CalculatePremium(int age, string healthCondition)
    {
        decimal basePremium = 200;
        if (age > 50) basePremium += 100;
        if (healthCondition == "poor") basePremium += 150;
        return basePremium;
    }
}

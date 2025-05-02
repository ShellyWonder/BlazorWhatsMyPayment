    using System.ComponentModel.DataAnnotations;
namespace BlazorLoanCalcApp.Models
{
    // This class is used to represent a singular loan payment.
    public class LoanPayment
    {
        public int Month { get; set; }

        public double Payment { get; set; }

        public double MonthlyPrincipal { get; set; }

        public double MonthlyInterest { get; set; }

        public double TotalInterest { get; set; }

        public double Balance { get; set; }
    }
}

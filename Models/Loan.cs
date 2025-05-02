using System.ComponentModel.DataAnnotations;

namespace BlazorLoanCalcApp.Models
{
    public class Loan
    {
        [Required(ErrorMessage = "Please enter a loan amount.")]
        [Range(1000, double.MaxValue, ErrorMessage = "Loan amount must be between $1,000.00 and $1,000,000.")]
        public double PurchaseAmount { get; set; }
        [Required]
        [Range(0.0, 12, ErrorMessage = "Please input a preferred interest rate between 0.0 and 12%.")]
        public double Rate { get; set; }

        //Term is measured in years
        [Required]
        [Range(1, 30, ErrorMessage = "Please input a preferred term between 1 and 30 years.")]
        public int Term { get; set; }

        public double Payment { get; set; }

        public double TotalInterest { get; set; }
       
        public double TotalCost { get; set; }

        public List<LoanPayment> Payments { get; set; } = new List<LoanPayment>();

    }
}

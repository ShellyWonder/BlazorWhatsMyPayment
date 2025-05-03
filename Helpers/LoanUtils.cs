using BlazorLoanCalcApp.Models;

namespace BlazorLoanCalcApp.Helpers
{
    public static class LoanUtils
    {
        /// <summary>
        /// Calculates the monthly payment, total cost, and total interest for a loan.
        /// </summary>
        /// <param name="loan"></param>
        /// <returns>a loan object</returns>
        public static Loan GetPayments(Loan loan)
        {
            loan.Payments.Clear();
            loan.Payment = CalcPayment(loan.PurchaseAmount, loan.Rate, loan.Term);

            var loanMonths = loan.Term * 12;
            //variables to hold total cost and interest
            double balance = loan.PurchaseAmount;
            double totalInterest = 0;
            double monthlyPrincipal = 0;
            double monthlyInterest = 0;
            double monthlyRate = CalcMonthlyRate(loan.Rate);
            for (int month = 1; month <= loanMonths; month++)
            {
                //calculate monthly interest
                monthlyInterest = CalcMonthlyInterest(balance, monthlyRate);

                //add to total interest
                totalInterest += monthlyInterest;

                //calculate monthly principal
                monthlyPrincipal = loan.Payment - monthlyInterest;

                //calculate new balance
                balance -= monthlyPrincipal;

                //add payment to list
                LoanPayment payment = new();

                payment.Month = month;
                payment.Payment = loan.Payment;
                payment.MonthlyPrincipal = monthlyPrincipal;
                payment.MonthlyInterest = monthlyInterest;
                payment.TotalInterest = totalInterest;
                payment.Balance = balance < 0 ? 0 : balance;

                loan.Payments.Add(payment);
            }
            loan.TotalInterest = totalInterest;
            loan.TotalCost = loan.PurchaseAmount + totalInterest;
            return loan;
        }

        /// <summary>
        /// Calculates the monthly payment for a loan based on the amount, interest rate, and term.
        /// </summary>
        /// <param name="amount">Loan Amount</param>
        /// <param name="rate">Annualized Rate(double)</param>
        /// <param name="term">term(years)</param>
        /// <returns>A monthly payment as a double</returns>
        /// Summary>
        public static double CalcPayment(double amount, double rate, int term)
        {
            double monthlyRate = CalcMonthlyRate(rate);
            int months = term * 12;
            double payment = (amount * monthlyRate) / (1 - Math.Pow(1 + monthlyRate, -months));
            return payment;
        }
        private static double CalcMonthlyRate(double rate)
        {
            return rate / 1200;
        }

        public static double CalcMonthlyInterest(double balance, double monthlyRate)
        {
            return balance * monthlyRate;
        }
    }
}

namespace BlazorLoanCalcApp.Helpers
{
    public static class LoanUtils
    {

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
    }
}

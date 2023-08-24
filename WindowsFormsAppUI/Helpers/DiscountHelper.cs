namespace WindowsFormsAppUI.Helpers
{
    public class DiscountHelper
    {
        public static double discountAmount { get; set; }
        public static double discountedBalance { get; set; }

        public static double Calculate(double price, double discount)
        {
            discountAmount = (discount * price) / 100;
            discountedBalance = price - discountAmount;

            return discountedBalance;
        }
    }
}

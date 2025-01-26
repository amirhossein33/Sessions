namespace Simplicity_Driven_Development.Sample1
{
    //False
   
    public class SalesService
    {
        public double CalculateTotalPrice(double price)
        {
            double tax = price * 0.1; // محاسبه مالیات
            return price + tax;
        }

        public double CalculateDiscountedPrice(double price, double discount)
        {
            double discountedPrice = price - discount;
            double tax = discountedPrice * 0.1; // محاسبه مالیات دوباره
            return discountedPrice + tax;
        }
    }

}
//True
public class SalesService
{
    private double CalculateTax(double amount)
    {
        return amount * 0.1;
    }

    public double CalculateTotalPrice(double price)
    {
        double tax = CalculateTax(price);
        return price + tax;
    }

    public double CalculateDiscountedPrice(double price, double discount)
    {
        double discountedPrice = price - discount;
        double tax = CalculateTax(discountedPrice);
        return discountedPrice + tax;
    }
}
namespace Simplicity_Driven_Development.Sample1
{
    //False
    public class NumberProcessor
    {
        public int CountEvenNumbers(List<int> numbers)
        {
            int count = 0;
            foreach (var number in numbers)
            {
                if (number % 2 == 0)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
//True
public class NumberProcessor
{
    public int CountEvenNumbers(List<int> numbers)
    {
        return numbers.Count(n => n % 2 == 0);
    }
}

using Calculator_HomeWork1;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Введите выражение");
            string expression = Console.ReadLine();
            try
            {
                Console.WriteLine(Compute(expression));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }         
        }
    }
    public static int Compute(string expression)
    {
        if (string.IsNullOrWhiteSpace(expression))
            throw new ArgumentNullException("Полученно пустое выражение",nameof(expression));

        Brackets.CheckParenthesis(expression);

        return Brackets.EvaluteParenthesis(expression);
    }
}

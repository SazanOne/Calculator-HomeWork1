
using Calculator_HomeWork1;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        string exid = ("Для того чтобы выйти нажмите <Escape>");
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Введите выражение");
            string expression = Console.ReadLine();

            try
            {
                Console.WriteLine(Compute(expression));
                Console.WriteLine(exid);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(exid);
            }
            if (Console.ReadKey().Key == ConsoleKey.Escape)
                break;
        }
    }
    private static int Compute(string expression)
    {
        if (string.IsNullOrWhiteSpace(expression))
            throw new ArgumentNullException("Полученно пустое выражение",nameof(expression));

        Brackets.CheckParenthesis(expression);

        return Brackets.EvaluteParenthesis(expression);
    }
}

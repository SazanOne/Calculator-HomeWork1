using System.Text.RegularExpressions;

namespace Calculator_HomeWork1
{
    public class Calculator
    {
        private static readonly char[] supportedOperators = new[] { '*', '/', '+', '-' };
        private static readonly int[] priorities = new[] { 0, 0, 1, 1 };

        public static int ParseExpression(string expression)
        {
            List<char> ops = new List<char>();
            List<int> numbers = new List<int>();
            string[] tokens = Regex.Split(expression.Replace(" ", ""), @"(\b[-+*\/]|[+-]?\d+|[-+*\/])").Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

            foreach (string token in tokens)
            {
                if (int.TryParse(token, out int number))
                    numbers.Add(number);
                else
                    ops.Add(token[0]);
            }

            if (ops.Count + 1 != numbers.Count)
                throw new FormatException("Ошибка в выражении");

            foreach (int priority in priorities.Distinct())
            {
                List<char> operators = new List<char>();
                for (int i = 0; i < priorities.Length; i++)
                {
                    if (priorities[i] == priority)
                        operators.Add(supportedOperators[i]);
                }
                for (int i = 0; i < ops.Count; i++)
                {
                    if (operators.Contains(ops[i]))
                    {
                        numbers[i] = Calculate(numbers[i], numbers[i + 1], ops[i]);
                        numbers.RemoveAt(i + 1);
                        ops.RemoveAt(i);
                        i--;
                    }
                }
            }
            return numbers[0];
        }

        public static int Calculate(int left, int right, char op)
        {
            switch (op)
            {
                case '*': return left * right;
                case '/': return left / right;
                case '+': return left + right;
                case '-': return left - right;
                default: throw new NotSupportedException("Неподдерживаемый оператор");
            }
        }

    }
}


namespace Calculator_HomeWork1
{
    public class Brackets()
    {
        public static int EvaluteParenthesis(string expression)
        {
            string planarExpresion = expression;
            while (planarExpresion.Contains('('))
            {
                int clauseStart = planarExpresion.IndexOf('(') + 1;
                int clauseEnd = IndexOfRightParenthesis(planarExpresion, clauseStart);
                string clause = planarExpresion.Substring(clauseStart, clauseEnd - clauseStart);
                planarExpresion = planarExpresion.Replace("(" + clause + ")", EvaluteParenthesis(clause).ToString());
            }
            return Calculator.ParseExpression(planarExpresion);
        }
        private static int IndexOfRightParenthesis(string expresion, int start)
        {
            int c = 1;
            for (int i = start; i < expresion.Length; i++)
            {
                switch (expresion[i])
                {
                    case '(': c++;
                        break;
                    case ')': c--;
                        break;
                }
                if (c == 0)
                    return i;
            }
            return -1;
        }
        public static void CheckParenthesis(string expression)
        {
            int i = 0;
            foreach (char c in expression)
            {
                switch (c)
                {
                    case '(': i++; break;
                    case ')': i--; break;
                }
                if (i < 0)
                    throw new ArgumentException("Не хватает '('", nameof(expression));
            }
            if (i > 0)
                throw new ArgumentException("Не хватает ')'", nameof(expression));
        }


    }
}

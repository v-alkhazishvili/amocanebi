using CalculatorApi.Models;

namespace CalculatorApi.Services;

public class Tokenizer
{
    public List<Token> Tokenize(string expression)
    {
        var tokens = new List<Token>();
        int i = 0;

        while (i < expression.Length)
        {
            char c = expression[i];

            if (char.IsDigit(c))
            {
                int start = i;
                while (i < expression.Length && char.IsDigit(expression[i]))
                    i++;

                tokens.Add(new Token(TokenType.Number, expression[start..i]));
                continue;
            }

            if ("+-*/".Contains(c))
                tokens.Add(new Token(TokenType.Operator, c.ToString()));
            else if (c == '(')
                tokens.Add(new Token(TokenType.LeftParen, "("));
            else if (c == ')')
                tokens.Add(new Token(TokenType.RightParen, ")"));

            i++;
        }

        return tokens;
    }
}

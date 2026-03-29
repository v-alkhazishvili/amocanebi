using CalculatorApi.Models;

namespace CalculatorApi.Services;

public class RpnEvaluator
{
    public double Evaluate(Queue<Token> tokens)
    {
        var stack = new Stack<double>();

        while (tokens.Count > 0)
        {
            var token = tokens.Dequeue();

            if (token.Type == TokenType.Number)
            {
                stack.Push(double.Parse(token.Value));
            }
            else if (token.Type == TokenType.Operator)
            {
                double b = stack.Pop();
                double a = stack.Pop();

                stack.Push(token.Value switch
                {
                    "+" => a + b,
                    "-" => a - b,
                    "*" => a * b,
                    "/" => a / b,
                    _ => throw new Exception("Unknown operator")
                });
            }
        }
        return stack.Pop();
    }
}
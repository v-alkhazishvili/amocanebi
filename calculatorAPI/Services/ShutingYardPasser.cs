using CalculatorApi.Models;

namespace CalculatorApi.Services;

public class ShuntingYardParser
{
    public Queue<Token> ToRpn(List<Token> tokens)
    {
        var output = new Queue<Token>();
        var operators = new Stack<Token>();

        foreach (var token in tokens)
        {
            switch (token.Type)
            {
                case TokenType.Number:
                    output.Enqueue(token);
                    break;

                case TokenType.Operator:
                    while (operators.Count > 0 &&
                           operators.Peek().Type == TokenType.Operator &&
                           Precedence(operators.Peek()) >= Precedence(token))
                    {
                        output.Enqueue(operators.Pop());
                    }
                    operators.Push(token);
                    break;

                case TokenType.LeftParen:
                    operators.Push(token);
                    break;

                case TokenType.RightParen:
                    while (operators.Count > 0 && operators.Peek().Type != TokenType.LeftParen)
                        output.Enqueue(operators.Pop());

                    operators.Pop(); // remove '('
                    break;
            }
        }

        while (operators.Count > 0)
            output.Enqueue(operators.Pop());

        return output;
    }

    private int Precedence(Token token)
    {
        return token.Value switch
        {
            "+" or "-" => 1,
            "*" or "/" => 2,
            _ => 0
        };
    }
}
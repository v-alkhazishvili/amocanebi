namespace CalculatorApi.Models;

public enum TokenType
{
    Number,
    Operator,
    LeftParen,
    RightParen
}

public class Token
{
    public TokenType Type { get; }
    public string Value { get; }

    public Token(TokenType type, string value)
    {
        Type = type;
        Value = value;
    }
}

using CalculatorApi.Models;

namespace CalculatorApi.Services;

public class CalculatorService
{
    private readonly Tokenizer _tokenizer = new();
    private readonly ShuntingYardParser _parser = new();
    private readonly RpnEvaluator _evaluator = new();

    public double Evaluate(string expression)
    {
        var tokens = _tokenizer.Tokenize(expression);
        var rpn = _parser.ToRpn(tokens);
        return _evaluator.Evaluate(rpn);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

public class BooleanFormulaEvaluator
{
    private Dictionary<string, bool> variables;

    public BooleanFormulaEvaluator(Dictionary<string, bool> variables)
    {
        this.variables = variables ?? new Dictionary<string, bool>();
    }

    public bool Evaluate(string formula)
    {
        if (string.IsNullOrWhiteSpace(formula))
            throw new ArgumentException("Formula cannot be empty or null");

        var tokens = Tokenize(formula);
        var rpn = ConvertToRPN(tokens);
        return EvaluateRPN(rpn);
    }

    private List<Token> Tokenize(string formula)
    {
        var tokens = new List<Token>();
        int i = 0;

        while (i < formula.Length)
        {
            char c = formula[i];

            if (char.IsWhiteSpace(c))
            {
                i++;
                continue;
            }

            if (char.IsLetter(c))
            {
                string identifier = c.ToString();
                i++;
                while (i < formula.Length && char.IsLetterOrDigit(formula[i]))
                {
                    identifier += formula[i];
                    i++;
                }

                if (identifier.Equals("true", StringComparison.OrdinalIgnoreCase))
                {
                    tokens.Add(new Token(TokenType.Constant, true));
                }
                else if (identifier.Equals("false", StringComparison.OrdinalIgnoreCase))
                {
                    tokens.Add(new Token(TokenType.Constant, false));
                }
                else
                {
                    tokens.Add(new Token(TokenType.Variable, identifier));
                }

                continue;
            }

            if (c == '!' && (i + 1 < formula.Length && formula[i + 1] == '='))
            {
                tokens.Add(new Token(TokenType.Operator, "!="));
                i += 2;
                continue;
            }

            switch (c)
            {
                case '(':
                    tokens.Add(new Token(TokenType.LeftParenthesis, "("));
                    i++;
                    break;
                case ')':
                    tokens.Add(new Token(TokenType.RightParenthesis, ")"));
                    i++;
                    break;
                case '!':
                    tokens.Add(new Token(TokenType.Operator, "!"));
                    i++;
                    break;
                case '&':
                    if (i + 1 < formula.Length && formula[i + 1] == '&')
                    {
                        tokens.Add(new Token(TokenType.Operator, "&&"));
                        i += 2;
                    }
                    else
                    {
                        throw new FormatException($"Unexpected character '&' at position {i}");
                    }
                    break;
                case '|':
                    if (i + 1 < formula.Length && formula[i + 1] == '|')
                    {
                        tokens.Add(new Token(TokenType.Operator, "||"));
                        i += 2;
                    }
                    else
                    {
                        throw new FormatException($"Unexpected character '|' at position {i}");
                    }
                    break;
                case '=':
                    if (i + 1 < formula.Length && formula[i + 1] == '=')
                    {
                        tokens.Add(new Token(TokenType.Operator, "=="));
                        i += 2;
                    }
                    else
                    {
                        throw new FormatException($"Unexpected character '=' at position {i}");
                    }
                    break;
                default:
                    throw new FormatException($"Unexpected character '{c}' at position {i}");
            }
        }

        return tokens;
    }

    private List<Token> ConvertToRPN(List<Token> tokens)
    {
        var output = new List<Token>();
        var operators = new Stack<Token>();

        foreach (var token in tokens)
        {
            switch (token.Type)
            {
                case TokenType.Variable:
                case TokenType.Constant:
                    output.Add(token);
                    break;
                case TokenType.Operator:
                    while (operators.Count > 0 &&
                           operators.Peek().Type == TokenType.Operator &&
                           GetPrecedence(operators.Peek().Value.ToString()) >= GetPrecedence(token.Value.ToString()))
                    {
                        output.Add(operators.Pop());
                    }
                    operators.Push(token);
                    break;
                case TokenType.LeftParenthesis:
                    operators.Push(token);
                    break;
                case TokenType.RightParenthesis:
                    while (operators.Count > 0 && operators.Peek().Type != TokenType.LeftParenthesis)
                    {
                        output.Add(operators.Pop());
                    }
                    if (operators.Count == 0)
                        throw new FormatException("Mismatched parentheses");
                    operators.Pop(); 
                    break;
            }
        }

        while (operators.Count > 0)
        {
            var op = operators.Pop();
            if (op.Type == TokenType.LeftParenthesis || op.Type == TokenType.RightParenthesis)
                throw new FormatException("Mismatched parentheses");
            output.Add(op);
        }

        return output;
    }

    private bool EvaluateRPN(List<Token> rpn)
    {
        var stack = new Stack<bool>();

        foreach (var token in rpn)
        {
            switch (token.Type)
            {
                case TokenType.Variable:
                    string varName = token.Value.ToString();
                    if (!variables.TryGetValue(varName, out bool value))
                        throw new KeyNotFoundException($"Variable '{varName}' not found in the provided dictionary");
                    stack.Push(value);
                    break;
                case TokenType.Constant:
                    stack.Push((bool)token.Value);
                    break;
                case TokenType.Operator:
                    string op = token.Value.ToString();
                    bool right, left;

                    switch (op)
                    {
                        case "!":
                            if (stack.Count < 1) throw new FormatException("Not enough operands for operator '!'");
                            right = stack.Pop();
                            stack.Push(!right);
                            break;
                        case "&&":
                            if (stack.Count < 2) throw new FormatException("Not enough operands for operator '&&'");
                            right = stack.Pop();
                            left = stack.Pop();
                            stack.Push(left && right);
                            break;
                        case "||":
                            if (stack.Count < 2) throw new FormatException("Not enough operands for operator '||'");
                            right = stack.Pop();
                            left = stack.Pop();
                            stack.Push(left || right);
                            break;
                        case "==":
                            if (stack.Count < 2) throw new FormatException("Not enough operands for operator '=='");
                            right = stack.Pop();
                            left = stack.Pop();
                            stack.Push(left == right);
                            break;
                        case "!=":
                            if (stack.Count < 2) throw new FormatException("Not enough operands for operator '!='");
                            right = stack.Pop();
                            left = stack.Pop();
                            stack.Push(left != right);
                            break;
                        default:
                            throw new FormatException($"Unknown operator '{op}'");
                    }
                    break;
                default:
                    throw new FormatException($"Unexpected token type {token.Type}");
            }
        }

        if (stack.Count != 1)
            throw new FormatException("Invalid expression");

        return stack.Pop();
    }

    private int GetPrecedence(string op)
    {
        switch (op)
        {
            case "!":
                return 4;
            case "&&":
                return 3;
            case "||":
                return 2;
            case "==":
            case "!=":
                return 1;
            default:
                throw new ArgumentException($"Unknown operator '{op}'");
        }
    }

    private enum TokenType
    {
        Variable,
        Constant,
        Operator,
        LeftParenthesis,
        RightParenthesis
    }

    private class Token
    {
        public TokenType Type { get; }
        public object Value { get; }

        public Token(TokenType type, object value)
        {
            Type = type;
            Value = value;
        }

        public override string ToString() => $"{Type}: {Value}";
    }
}


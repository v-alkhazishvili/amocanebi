using System;
using System.Collections.Generic;

namespace MyNamespace
{
    class Program
    {
        static void Main(string[] args)
        {            
            // string input = "4+18/(9-3)";        
            string input = "13+8/2*(6-4)"; 
            Console.WriteLine("Input: " + input);
            Console.WriteLine("Result: " + EvaluateExpression(input));
        }

        static double EvaluateExpression(string expression)
        {
            //create token list
            List<string> tokens = new List<string>();
            Stack<char> operatorStack = new Stack<char>();
            Queue<string> outputQueue = new Queue<string>();
            int lastOperatorIndex = -1;
            for (int i = 0; i < expression.Length; i++)
            {             
                if (IsOperator(expression[i]))                
                {
                    //add operator to the list
                    string a;
                    if (!string.IsNullOrEmpty(expression.Substring(lastOperatorIndex + 1, i - lastOperatorIndex - 1)))
                    {
                        a = expression.Substring(lastOperatorIndex + 1, i - lastOperatorIndex - 1);
                        tokens.Add(a.ToString());
                        // Console.WriteLine(a);
                    }                    
                    tokens.Add(expression[i].ToString());
                    lastOperatorIndex = i;
                }
                //handle the last number in the expression
                if (i == expression.Length - 1 && IsDigit(expression[i]))
                {
                    int a = int.Parse(expression.Substring(lastOperatorIndex + 1, i - lastOperatorIndex));                                
                    tokens.Add(a.ToString());
                    // Console.WriteLine(a);
                }
            }
            //token list is filled, now we go fill out the operator stack and queue
            foreach (string token in tokens)
            {   
                if (IsOperator(token[0]))
                {
                    if(token[0] == '(')
                    {
                        operatorStack.Push(token[0]);
                    }
                    else if(token[0] == ')')
                    {
                        while (operatorStack.Count > 0 && operatorStack.Peek() != '(')
                        {
                            outputQueue.Enqueue(operatorStack.Pop().ToString());
                        }

                        if (operatorStack.Count > 0 && operatorStack.Peek() == '(')
                        {
                            operatorStack.Pop(); // remove '('
                        }
                    }
                    else
                    {
                        while (operatorStack.Count > 0 &&
                        Precedence(operatorStack.Peek()) >= Precedence(token[0]))
                        {
                            outputQueue.Enqueue(operatorStack.Pop().ToString());
                        }   
                        operatorStack.Push(token[0]);            
                    }
                }
                else
                {
                    outputQueue.Enqueue(token);
                }
            }
            while (operatorStack.Count > 0)
            {
                outputQueue.Enqueue(operatorStack.Pop().ToString());
            }
            /////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("reverse polish:\n" + string.Join(", ", outputQueue));
            return EvaluateRPN(outputQueue);        
        }


        static int Precedence(char op) //operator precedence
        {
            if (op == '+' || op == '-') return 1;
            else if (op == '*' || op == '/') return 2;
            else return 0;
        }
        static bool IsDigit(char c)
        {
            return c >= '0' && c <= '9';
        }

        static bool IsOperator(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/' || c=='(' || c==')';
        }
        static double EvaluateRPN(Queue<string> tokens) 
        {
            //evaluate the reverse polish notation
             Stack<double> stack = new Stack<double>();
             int i = 0;
            while (tokens.Count > 0)
            {
                stack.Push(tokens.Dequeue() switch
                {
                    "+" => stack.Pop() + stack.Pop(),
                    "-" => -stack.Pop() + stack.Pop(),
                    "*" => stack.Pop() * stack.Pop(),
                    "/" => 1 / stack.Pop() * stack.Pop(),
                    var number => double.Parse(number)
                });
                i++;
            }
            return stack.Pop();
        }
    }
}

using StackTraining.Stack.LinkedList;
using System;
using System.Collections;

namespace StackTraining.Stack.Calc
{
    public class Calculator
    {

        private Stack<int> _list = new Stack<int>();

        // ex | 5 6 7 * + 1 - 
        public double Calculate(string[] tokens)
        { 
            foreach(var token in tokens)
            {
                if(!parseToken(token))
                {
                    var rhs = _list.Pop();
                    var lhs = _list.Pop();
                    Evaluate(lhs, rhs, token);
                }
            }
            return _list.Pop();
        }

        private bool parseToken(string token)
        {
            int value;
            if(int.TryParse(token, out value))
            {
                _list.Push(value);
                return true;
            }
            return false;
        }

        private void Evaluate(int left, int right, string token)
        {
            switch(token)
            {
                case "+":
                    _list.Push(left + right);
                    break;
                case "-":
                    _list.Push(left - right);
                    break;
                case "*":
                    _list.Push(left * right);
                    break;
                case "/":
                    _list.Push(left / right);
                    break;
                case "%":
                    _list.Push(left % right);
                    break;
                default:
                    throw new ArgumentException($"Unrecognized token value: {token}");
            }
        }
    }
}
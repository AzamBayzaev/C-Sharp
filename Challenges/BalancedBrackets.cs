using System;
using System.Collections.Generic;

class BalancedBrackets
{
    public static bool IsBalanced(string s)
    {
        Stack<char> stack = new Stack<char>();

        foreach (char c in s)
        {
           
            if (c == '(' || c == '{' || c == '[')
            {
                stack.Push(c);
            }
          
            else if (c == ')' || c == '}' || c == ']')
            {
                if (stack.Count == 0) return false;

                char top = stack.Pop();

                if ((c == ')' && top != '(') ||
                    (c == '}' && top != '{') ||
                    (c == ']' && top != '['))
                {
                    return false;
                }
            }
        }

       
        return stack.Count == 0;
    }

}


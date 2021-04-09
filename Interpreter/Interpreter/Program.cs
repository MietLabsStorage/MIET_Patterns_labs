using System;
using System.Text;
using Interpreter.TerminalExpressions;

namespace Interpreter
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string text =
                "nljksgdn g\"ngsfd ()D\" )D((\n)(D)\" _D)D_)_DD   __\"D))9 )( KDK _)  ffdsfd - sfd e-dffds fddsdf sfdf\n\nfvxvc\tfv\t\tgggf\t\t\t\tgfdggfdgdf     dfsfsd ) ( -";
            
            Console.WriteLine(text);
            Console.WriteLine("******************************************************************");
            
            TextExpression textExpression = new TextExpression();
            textExpression.Expressions.Add(new CloseRoundExpression());
            textExpression.Expressions.Add(new DashExpression());
            textExpression.Expressions.Add(new DoubleSpaceExpression());
            textExpression.Expressions.Add(new NewlinesExpression());
            textExpression.Expressions.Add(new OpenRoundBracketExpression());
            textExpression.Expressions.Add(new TabExpression());
            textExpression.Expressions.Add(new QuotationExpression());

            bool isNeedInterpret = false;

            do
            {
                isNeedInterpret = textExpression.Interpret(ref text);
            } while (isNeedInterpret);
            
            Console.WriteLine(text);

            Console.ReadKey();
        }
    }
}
using System.Collections.Generic;

namespace Interpreter
{
    public class TextExpression:IExpression
    {
        public List<IExpression> Expressions { get; } = new List<IExpression>();
        
        public bool Interpret(ref string context)
        {
            bool result = false;
            foreach (var expression in Expressions)
            {
                result |= expression.Interpret(ref context);
            }

            return result;
        }
    }
}
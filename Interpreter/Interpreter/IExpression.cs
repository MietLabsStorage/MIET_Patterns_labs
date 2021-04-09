namespace Interpreter
{
    public interface IExpression
    {
        bool Interpret(ref string context);
    }
}
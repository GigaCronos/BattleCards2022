namespace Compiler;
public abstract class UnaryExpr: Expression
{
    public Expression Left;
    public override bool Validate(IContext context)
    {
        if(Left.Validate(context))
        return true;
        else
        return false;
    }
}
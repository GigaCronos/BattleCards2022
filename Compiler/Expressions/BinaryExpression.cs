namespace Compiler;
public abstract class BinaryExpr :Expression  
{
    public Operator Op;
    public Expression Left;
    public Expression Rigth;
    public override bool Validate(IContext context)
    {
        if(Left.Validate(context) && Rigth.Validate(context))
        return true;
        else
        return false;
    }
}
namespace Compiler;
public abstract class BinaryExpr :Expression  
{
    public Expression Left;
    public Expression Rigth;
    public Type NodeType;
    public BinaryExpr(Expression a,Expression b)
    {
        Left=a;Rigth=b;
    }
    public override bool Validate(IContext context)
    {
        if(Left.Validate(context) && Rigth.Validate(context))
        return true;
        else
        return false;
    }
    public override bool CheckTypes(IContext context){
        return true;
    }
}
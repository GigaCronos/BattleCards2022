namespace Compiler;
public abstract class UnaryExpr: Expression
{
    public Expression Left;
    public UnaryExpr(Expression a){Left=a;}
    public override bool Validate(IContext context)
    {
        if(Left==null)return false;
        if(Left.Validate(context))
        return true;
        else
        return false;
    }
   public override bool CheckTypes(IContext context){
        return true;
    }

}
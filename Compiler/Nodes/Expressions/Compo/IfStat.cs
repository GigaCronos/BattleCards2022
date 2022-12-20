namespace Compiler;
public class IfStat:CompExpression
{
    public Expression Condition;
    public IfStat(Expression C,List<Expression> B):base(B){
        Condition=C;
    }
    public override bool Validate(IContext context){
        return true;
    }
}
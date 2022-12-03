namespace Compiler;
public class IfStat:CompExpression
{
    public Expression Condition;
    public Expression Body;

    public IfStat(Expression C,Expression B){
        Condition=C;Body=B;
    }
    public override bool Validate(IContext context){
        return true;
    }
}
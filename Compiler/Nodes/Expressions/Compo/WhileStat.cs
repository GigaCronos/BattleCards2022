namespace Compiler;
public class WhileStat:CompExpression
{
    public Expression Condition;
    public ComandBlock Body;
    public WhileStat(Expression C,ComandBlock B){
        Condition=C;
        Body=B;
    }
    public override bool Validate(IContext context){
        return true;
    }
    public override string Run(IContext context){
        return "0";
    }
}
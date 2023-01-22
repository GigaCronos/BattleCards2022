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
        IContext cur=context.CreateChildContext();
        return (Condition.Validate(cur) && Body.Validate(cur));
    }
    public override string Run(IContext context){
        IContext cur=context.CreateChildContext();
        while(Condition.Run(cur)!="0"){
            Body.Run(cur);
        }
        return "0";
    }
}
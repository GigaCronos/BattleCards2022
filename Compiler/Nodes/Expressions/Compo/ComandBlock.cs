namespace Compiler;
public class ComandBlock:CompExpression
{   
    public List<Expression> Statements;
    public ComandBlock(List<Expression> L){
        Statements=L;
    }
    public override bool Validate(IContext context)
    {
        foreach(var St in Statements)
        {
            if(!St.Validate(context))
            {
                return false;
            }
        }
        return true;
    }
    public override string Run(IContext context){
        foreach(var St in Statements){
            St.Run(context);
        }
        return "0";
    }
}
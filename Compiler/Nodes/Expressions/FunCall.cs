namespace Compiler;
public class FunCall:Expression
{
    public string Identifier;
    public List<Expression> Args;
    public override bool Validate(IContext context)
    {
        foreach(var ar in Args)
        {
            if(!ar.Validate(context))
            return false;
        }
        return context.IsDefined(Identifier,Args.Count);
    }
}
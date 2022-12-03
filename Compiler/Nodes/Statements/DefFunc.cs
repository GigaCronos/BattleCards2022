namespace Compiler;
public class DefFunc:Statement
{   
    public string Identifier;
    public List<string> Args;
    public Expression Body;
    public DefFunc(string Id,List<string> A, Expression E){
        Identifier=Id;Args=A;Body=E;
    }

    public override bool Validate(IContext context)
    {
        var innerContext = context.CreateChildContext();
        
        foreach(var arg in Args)
        {
            innerContext.Define(arg);
        }

        if(Body.Validate(innerContext))
        return false;

        if(!context.Define(Identifier,Args.ToArray()))
        return false;

        return true;
    }
}
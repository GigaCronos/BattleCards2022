namespace Compiler;
public class FunCall:Expression
{
    public string Identifier;
    public List<Expression> Args;
    public FunCall(string Id,List<Expression> A){
        Identifier=Id;Args=A;
    }
    public override bool Validate(IContext context)
    {
        foreach(var ar in Args)
        {
            if(!ar.Validate(context))
            return false;
        }
        return context.IsDefined(Identifier,Args.Count);
    }

    public override string Run(IContext context){
           List<string> L=new List<string>();
           foreach(var a in Args){
            L.Add(a.Run(context));
           }
           return context.RunFunction(Identifier,L); 
    }
}
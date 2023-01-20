namespace Compiler;
public class DefFun:Expression
{
    public string Identifier;
    public List<string> Args;
    public ComandBlock Body;
    public DefFun(string Id,List<string> A,ComandBlock B){
        Identifier=Id;Args=A;Body=B;
    }
    public override bool Validate(IContext context)
    {
        
        IContext C=context.CreateChildContext();
        foreach(var ar in Args)
        {
            C.Assign(ar,"0");
        }
        if(!Body.Validate(C))
        return false;
        return context.Define(Identifier,this);
    }
    public string Run(List<string> Params,IContext context){
        IContext C=context.CreateChildContext();
        for(int i=0;i<Params.Count;i++)
        {
            C.Assign(Args[i],Params[i]);
        }
        C.Assign("return","0");
        Body.Run(C);
        return context.GetVariable("return");
    }

    public override string Run(IContext context){
        return "0";
    }
}
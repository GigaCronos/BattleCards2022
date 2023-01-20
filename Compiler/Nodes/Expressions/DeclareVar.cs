using System.Collections.Generic;
namespace Compiler;
public class DeclareVar:Expression
{
    public string Type;
    public string Identifier;
    
    public DeclareVar(string Id){
        Identifier=Id;
    }
    public override bool Validate(IContext context)
    {
        context.Assign(Identifier,"0");
        return true;
    }

    public override string Run(IContext context){
            return "0";
    }

}
using System.Collections.Generic;
namespace Compiler;
public class DeclareVar:Expression
{
    public string Type;
    public string Identifier;
    
    public DeclareVar(string Ty,string Id){
        Identifier=Id;Type=Ty;
    }
    public override bool Validate(IContext context)
    {
        return context.Define(Identifier,Type);
    }

    public override bool CheckTypes(IContext context){
        return true;
    }
}
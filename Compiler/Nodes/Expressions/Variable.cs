namespace Compiler;
public class Variable:Expression{
    public string Identifier;
    public Variable(string Id){
        Identifier=Id;
    }
    public override bool Validate(IContext context)
    {
        return context.IsDefined(Identifier);
    }
}
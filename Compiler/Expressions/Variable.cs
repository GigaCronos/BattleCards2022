using Compiler;
public class Variable:Expression{
    public string Identifier;
    public override bool Validate(IContext context)
    {
        return context.IsDefined(Identifier);
    }
}
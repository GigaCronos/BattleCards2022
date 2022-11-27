namespace Compiler;
public class LetVar:Statement
{   
    public string Identifier;
    public Expression Expr;
    public override bool Validate(IContext context)
    {
        return context.IsDefined(Identifier)&& Expr.Validate(context);
    }
}
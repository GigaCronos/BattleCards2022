namespace Compiler;
public class LetVar:Statement
{   
    public string Identifier;
    public Expression Expr;

    public LetVar(string Id,Expression E){
        Identifier=Id;
        Expr=E;
    }
    public override bool Validate(IContext context)
    {
        return context.IsDefined(Identifier)&& Expr.Validate(context);
    }
}
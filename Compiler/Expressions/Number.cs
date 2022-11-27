using Compiler;
public class Number:Expression
{
    public string Value;
    public override bool Validate(IContext context)
    {
        return true;
    }
}
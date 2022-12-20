namespace Compiler;
public class StringNode:Expression{
    public string Str;
    public StringNode(string s){
        Str=s;
    }
    public override bool Validate(IContext context)
    {
        return true;
    }
}
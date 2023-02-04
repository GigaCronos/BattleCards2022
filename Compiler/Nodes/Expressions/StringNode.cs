namespace Compiler;
public class StringNode:Expression{
    //Not Implemented,Don't Use
    public string Str;
    public StringNode(string s){
        Str=s;
    }
    public override bool Validate(IContext context)
    {
        return true;
    }
    public override string Run(IContext context){
        return Str;
    }
   
}
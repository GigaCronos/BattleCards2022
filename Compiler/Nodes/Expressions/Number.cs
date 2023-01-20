namespace Compiler;
public class Number:Expression
{
    public string Value;
    public Number(string value){
        Value=value;
    }
    public override bool Validate(IContext context)
    {
       return true;
    }

    public override string Run(IContext context){
            return Value;
    }
      
}
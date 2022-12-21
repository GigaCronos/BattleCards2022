namespace Compiler;
public class Number:Expression
{
    public string Value;
    public string Typename;
    public Number(string value){
        Value=value;
        Typename="int";
    }
    public override bool Validate(IContext context)
    {
       return true;
    }
   public override bool CheckTypes(IContext context){
        return true;
    }
      
}
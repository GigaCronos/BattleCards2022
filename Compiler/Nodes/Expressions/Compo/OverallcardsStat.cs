namespace Compiler;
public class OverallcardsStat:CompExpression
{
    public ComandBlock Body;
    public OverallcardsStat(ComandBlock B){
        Body=B;
    }
    public override bool Validate(IContext context){
        return true;
    }
    public override bool CheckTypes(IContext context){
        return true;
    }
}
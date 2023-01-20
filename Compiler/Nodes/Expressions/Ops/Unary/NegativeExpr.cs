namespace Compiler;
public class NegativeExpr : UnaryExpr
{
    public NegativeExpr(Expression a):base(a){}           
    public override string Run(IContext context){
        int d1=Int32.Parse(Left.Run(context));
        return (-d1).ToString();    
    }
        
}
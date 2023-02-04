namespace Compiler;
public class BNotExpr : UnaryExpr
{
        //Unary Boolean Not !
        public BNotExpr(Expression a):base(a){}
        public override string Run(IContext context){
                return "0"==Left.Run(context)?"1":"0";
        }
}
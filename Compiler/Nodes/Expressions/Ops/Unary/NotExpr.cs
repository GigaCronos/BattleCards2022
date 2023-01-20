namespace Compiler;
public class NotExpr : UnaryExpr
{
        public NotExpr(Expression a):base(a){}                    

        public override string Run(IContext context){
            int d1=Int32.Parse(Left.Run(context));
            return (~d1).ToString();
        }     
}
namespace Compiler;
public class RestExpr : BinaryExpr{
        //Rest
        public RestExpr(Expression a,Expression b):base(a,b){}
        public override string Run(IContext context){
                int d1=Int32.Parse(Left.Run(context));
                int d2=Int32.Parse(Rigth.Run(context));               
                return (d1-d2).ToString();        
        }      
}
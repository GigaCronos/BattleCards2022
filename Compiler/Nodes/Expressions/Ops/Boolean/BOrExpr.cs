namespace Compiler;
public class BOrExpr : BinaryExpr
{
        //Boolean Or ||
        public BOrExpr(Expression a,Expression b):base(a,b){}

        public override string Run(IContext context){
                return (Left.Run(context)!="0" || Rigth.Run(context)!="0")?"1":"0";
        }
}
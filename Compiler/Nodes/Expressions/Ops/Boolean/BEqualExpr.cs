namespace Compiler;
public class BEqualExpr : BinaryExpr
{
        //Boolean Equals
        public BEqualExpr(Expression a,Expression b):base(a,b){}

        public override string Run(IContext context){
                return Left.Run(context)==Rigth.Run(context)?"1":"0";
        }
}
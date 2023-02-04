namespace Compiler;
public class BNotEqualExpr : BinaryExpr
{
        //Boolean Not Equal To !=
        public BNotEqualExpr(Expression a,Expression b):base(a,b){}

        public override string Run(IContext context){
                return Left.Run(context)!=Rigth.Run(context)?"1":"0";
        }
}
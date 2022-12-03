namespace Compiler;
public class SumExpr : BinaryExpr{
        

        public override bool CheckType(IContext context){
            return true;
        }
}
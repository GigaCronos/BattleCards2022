namespace Compiler;
public class AssignExpr:BinaryExpr{
        Variable L;
        public AssignExpr(Expression a,Expression b):base(a,b){
        L=(Variable)a;
        }
        public override string Run(IContext context){
                context.Assign(L.Identifier,Rigth.Run(context)); 
                return context.GetVariable(L.Identifier);
        }
}
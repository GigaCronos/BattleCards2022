namespace Compiler;
public class AssignExpr:BinaryExpr{
        Variable L;
        public AssignExpr(Expression a,Expression b):base(a,b){
        L=(Variable)a;
        }
        public override bool Validate(IContext context){
                if(!Rigth.Validate(context)){
                        return false;
                }
                context.Assign(L.Identifier,"0");
                return true;
        }
        public override string Run(IContext context){
                context.Assign(L.Identifier,Rigth.Run(context)); 
                return context.GetVariable(L.Identifier);
        }
}
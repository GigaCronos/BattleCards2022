namespace Compiler;
using Extensors;

public class AST{
    public List<DefFun> Actions;
    public List<AssignExpr> Properties;
    public IContext MainContext;
    public AST(string txt){
            List<string> L;
            try
            {
                L=Lexer.Lex(txt);
            }
            catch (System.Exception)
            {
                throw;
            } 
            MainContext=new Context();            
            try{                
            (Actions,Properties)=Parser.Parse(L);
            foreach(var As in Properties){
                As.Validate(MainContext);        
            }
            foreach (var F in Actions)
            {
                F.Validate(MainContext);
            }
            foreach(var As in Properties){
                As.Run(MainContext);
            }
            }catch(System.Exception)
            {
                throw;
            }
    }
    public string RunFunction(string Name,List<string> Params){
        System.Random rnd=new System.Random();
        MainContext.Assign("Random",rnd.Next(0,100000).ToString());
        try{
        return MainContext.RunFunction(Name,Params);
        }catch(System.Exception a){
            return "0";
        }
    }
}
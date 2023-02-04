namespace Compiler;
using Extensors;

public class AST{
    public List<DefFun> Actions;
    public List<AssignExpr> Properties;
    public IContext MainContext;
    public bool Valid{get;private set;}
    public AST(string txt){
            Valid=true;
            List<string> L;
            try
            {
                L=Lexer.Lex(txt);
            }
            catch (System.Exception)
            {
                  Valid=false;  
                  return;                
            } 
            MainContext=new Context();            
            MainContext.Assign("Random","0");
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
                Valid=false;
            }
    }
    //Enumerates all the Functions just Names
    public IEnumerable<string> GetFunctions(){
        foreach(var Def in Actions){
            yield return Def.Identifier;
        }
    }
    //Run a Function Given Parameters as List<string>
    public string RunFunction(string Name,List<string> Params){
        System.Random rnd=new System.Random();
        int d=rnd.Next(0,100000);
        MainContext.Assign("Random",d.ToString());
        try{
            string s=MainContext.RunFunction(Name,Params);
            return s;
        }catch(System.Exception a){
             if(Name=="Perform_Attack")
            throw a;
            return "0";
        }
    }
}
namespace Compiler;
using Extensors;

public class AST{
    public List<DefFun> Actions;
    public IContext MainContext;
    public AST(string txt,Properties Stats){
            List<string> L=Lexer.Lex(txt);
            MainContext=new Context();
            Actions=new List<DefFun>();//Parser(L);
            foreach (var F in Actions)
            {
                F.Validate(MainContext);
            }
    }
    public string RunFunction(string Name,List<string> Params){
           return MainContext.RunFunction(Name,Params);
    }
}
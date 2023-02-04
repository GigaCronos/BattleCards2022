namespace Compiler;
using Extensors;
public class Script
{
    public AST Program;
    public Script(string text)
    {
        Program=new AST(text);
    }    
    public int GetStat(string stat){
        string s= Program.RunFunction("Get"+stat,new List<string>(){});
        return Int32.Parse(s);
    }

    public bool Validate(){
        return Program.Valid;
    }
    public int Handle(string action, int[] L){
        List<string> L1=new List<string>();
        foreach(var a in L){
            L1.Add(a.ToString());
        }
        return Int32.Parse(Program.RunFunction("Handle_"+action,L1));
    }
    public int Perform(string action,int[] L){
        List<string> L1=new List<string>();
        foreach(var a in L){
            L1.Add(a.ToString());
        }
        return Int32.Parse(Program.RunFunction("Perform_"+action,L1));
    }
    public List<string> Actions(){
        List<string> Answer=new List<string>();
        foreach(var s in Program.GetFunctions()){
            if(s.Substring(0,7)=="Perform")
            Answer.Add(s.Substring(8));
        }
        return Answer;
    }

    public void Passive(){
        Program.RunFunction("Passive",new List<string>(){});
    }

}
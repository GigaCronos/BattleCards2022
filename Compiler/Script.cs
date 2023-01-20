namespace Compiler;
using Extensors;
public class Script
{
    Properties Stats;
    public AST Program;
    public Script(string text, Properties stats)
    {
        Stats=stats;
        Program=new AST(text,stats);
        Program.RunFunction("Init",new List<string>(){});
    }
    public int Atack(){
        string s= Program.RunFunction("Atack",new List<string>(){});
        return Int32.Parse(s);
    }    
    public bool DealDamage(int D){
        string s=Program.RunFunction("DealDamage",new List<string>{D.ToString()});
        return s!="0";
    }



}
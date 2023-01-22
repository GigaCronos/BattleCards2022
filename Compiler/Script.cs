namespace Compiler;
using Extensors;
public class Script
{
    public AST Program;
    public Script(string text)
    {
        Program=new AST(text);
    }
    public int Atack(){
        string s= Program.RunFunction("Atack",new List<string>(){});
        return Int32.Parse(s);
    }    
    public int GetStat(string stat){
        string s= Program.RunFunction("Get"+stat,new List<string>(){});
        return Int32.Parse(s);
    }
    public bool DealDamage(int D){
        string s=Program.RunFunction("DealDamage",new List<string>{D.ToString()});
        return s!="0";
    }



}
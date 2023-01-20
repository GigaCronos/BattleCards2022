namespace Compiler;
using System.Collections.Generic;
public class Context : IContext
{
    IContext ? parent;
    Dictionary<string,DefFun> FunctionLib=new Dictionary<string, DefFun>();
    Dictionary<string,string> variables=new Dictionary<string, string>();
    Dictionary<string,int> functions=new Dictionary<string,int>();
    public bool IsDefined(string variable)
    {
        return variables.ContainsKey(variable) || (parent!=null && parent.IsDefined(variable));
    }
    public bool IsDefined(string function,int args)
    {
        return (functions.ContainsKey(function) && functions[function]==args) || (parent !=null && parent.IsDefined(function,args));
    }
    public bool Define(string function,DefFun F)
    {
        if(functions.ContainsKey(function))
        return false;
        functions.Add(function,F.Args.Count);
        FunctionLib.Add(function,F);
        return true;
    }
    public string GetVariable(string val){
        return variables[val];
    }
    public string RunFunction(string funtion,List<string> Params){
        if(IsDefined(funtion,Params.Count)){
           return FunctionLib[funtion].Run(Params,this); 
        }else{
           return parent.RunFunction(funtion,Params);
        }
    }
    public void Assign(string variable,string val){
        if(variables.ContainsKey(variable))
        variables[variable]=val;
        else
        variables.Add(variable,val);
    }
    public IContext CreateChildContext(){
        return new Context(){ parent=this};
    }
}
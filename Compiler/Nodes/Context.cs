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
        if(functions.ContainsKey(function)){
            functions[function]=F.Args.Count;
            FunctionLib[function]=F;
            return true;
        }
        functions.Add(function,F.Args.Count);
        FunctionLib.Add(function,F);
        return true;
    }
    public string GetVariable(string val){
        if(variables.ContainsKey(val))
        return variables[val];
        else
        return parent.GetVariable(val);
    }
    public string RunFunction(string funtion,List<string> Params){
        if(IsDefined(funtion,Params.Count)){
            return FunctionLib[funtion].Run(Params,this); 
        }else{
           return parent.RunFunction(funtion,Params);
        }
    }
    public void Assign(string variable,string val){
        if(this.IsDefined(variable)){
        if(variables.ContainsKey(variable))
        variables[variable]=val;
        else
        parent.Assign(variable,val);
        }else{
            variables.Add(variable,val);
        }
    }
    public IContext CreateChildContext(){
        return new Context(){ parent=this};
    }
    public IEnumerable<string> GetFuns(){
        foreach(var s in FunctionLib){
            yield return s.Key;
        }
    }
    public IEnumerable<string> GetVars(){
        foreach(var s in variables){
            yield return s.Key;
        }
    }
}
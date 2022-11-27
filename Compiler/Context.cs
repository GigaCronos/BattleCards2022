using Compiler;
public class Context : IContext
{
    IContext parent;
    HashSet<string> variables=new HashSet<string>();
    Dictionary<string,string[]> functions=new Dictionary<string, string[]>();
    bool IsDefined(string variable)
    {
        return variables.Contains(variable) || (parent!=null && parent.IsDefined(variable));
    }
    bool IsDefined(string function,int args)
    {
        return (functions.ContainsKey(function) && functions[function].Count==args) || (parent !=null && parent.IsDefined(function,args));
    }
    bool Define(string variable)
    {
        return variable.Add(variable);
    }
    bool Define(string function,string[] args)
    {
        if(functions.ContainsKey(function) && functions[function].Length==args.Length)
        return false;
        functions[function]=args;
        return true;
    }
    IContext CreateChildrenContext(){
        return new Context(){ parent=this};
    }
}
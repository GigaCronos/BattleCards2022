namespace Compiler;
public class Context : IContext
{
    IContext ? parent;
    HashSet<string> variables=new HashSet<string>();
    Dictionary<string,string[]> functions=new Dictionary<string, string[]>();
    public bool IsDefined(string variable)
    {
        return variables.Contains(variable) || (parent!=null && parent.IsDefined(variable));
    }
    public bool IsDefined(string function,int args)
    {
        return (functions.ContainsKey(function) && functions[function].Length==args) || (parent !=null && parent.IsDefined(function,args));
    }
    public bool Define(string variable)
    {
        return variables.Add(variable);
    }
    public bool Define(string function,string[] args)
    {
        if(functions.ContainsKey(function) && functions[function].Length==args.Length)
        return false;
        functions[function]=args;
        return true;
    }
    public IContext CreateChildContext(){
        return new Context(){ parent=this};
    }
}
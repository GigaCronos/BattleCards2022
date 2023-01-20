namespace Compiler;
public interface IContext
{   
   public bool IsDefined(string variable);
   public bool IsDefined(string function,int args);
   public bool Define(string function,DefFun F);
   public string RunFunction(string funtion,List<string> Params);
   public string GetVariable(string val);
   public void Assign(string var,string val);
   public IContext CreateChildContext();
}

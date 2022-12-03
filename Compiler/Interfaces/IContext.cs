namespace Compiler;
public interface IContext
{   
   public bool IsDefined(string variable);
   public bool IsDefined(string function,int args);
   public bool Define(string variable);
   public bool Define(string function,string[] args);
   public IContext CreateChildContext();
}

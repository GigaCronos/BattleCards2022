namespace Compiler;
public interface IContext
{   
   bool IsDefined(string variable);
   bool IsDefined(string function,int args);
   bool Define(string variable);
   bool Define(string function,string[] args);
   IContext CreateChildContext();
}

namespace Compiler;
public abstract class Node
{   
    public Type NodeType;
    public abstract bool Validate(IContext context);
    public abstract bool CheckTypes(IContext context);
}
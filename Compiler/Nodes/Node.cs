namespace Compiler;
public abstract class Node
{   
    public abstract bool Validate(IContext context);
}
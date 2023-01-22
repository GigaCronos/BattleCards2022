namespace Compiler;
public abstract class Node
{   
    public abstract bool Validate(IContext context);
    public abstract string Run(IContext context);
}
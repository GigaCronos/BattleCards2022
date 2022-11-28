namespace Compiler;
public class Program:Node
{   
    public List<Statement> Statements;
    public override bool Validate(IContext context)
    {
        foreach(var St in Statements)
        {
            if(!St.Validate(context))
            {
                return false;
            }
        }
        return true;
    }
}
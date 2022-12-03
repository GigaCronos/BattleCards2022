namespace Compiler;
public class Program:Node
{   
    public List<Statement> Statements;
    public Program(List<Statement> L){
        Statements=L;
    }
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
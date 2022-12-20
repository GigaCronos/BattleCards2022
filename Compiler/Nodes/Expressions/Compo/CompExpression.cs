namespace Compiler;
public abstract class CompExpression: Expression
{
    public List<Expression> Expressions;
    public CompExpression(List<Expression> Li){
        Expressions=Li;
    }
}
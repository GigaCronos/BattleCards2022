namespace Compiler;
public class Parser
{
    public Parse(List<string> Tokens)
    {


    }
    public Expression ParseSimpleExpr(List<string> Tokens)
    {
        stack<tuple<Expression, string>> Ops = new stack<tuple<Expression, string>>();
        int last = -1;
        int parCount = 0;
        bool isFun = false;
        Expression CurExpr;
        foreach (var s in Tokens)
        {
            if (s == '(')
            {
                if (parCount == 0)
                {
                    if (last == -1 || IsLetter(List[last][0]) || List[last][0] == '_')
                    {
                        isFun = false;
                        last = IndexOf(s) + 1;
                    }
                    else
                    {
                        isFun = true;
                    }
                }
                parCount++;
                continue;
            }
            if (s == ')')
            {
                parCount--;
                if (parCount == 0)
                {
                    if (isFun)
                    {
                        CurExpr = ParseFunCall(SubList(last, IndexOf(s)));
                    }
                    else
                    {
                        CurExpr = ParseSimpleExpr(SubList(last, IndexOf(s) - 1));
                    }
                }
                continue;
            }
            if (parCount != 0)
            {
                continue;
            }
            if (Jerarquia.Jerarchy.Contains(s))
            {
                if(s=="-")
                {

                    continue;    
                }
                Acople(Ops,s,CurExpr);            

                continue;
            }
            last=IndexOf(s);
            CurExpr=ParseTerm(s);

        }

    }
    public FunCall ParseFunCall(List<string> Tokens)
    {

    }
    public ParseTerm(string s)
    {

    }
    public void Acople(List<tuple<Expression,string>> Ops,string s,Expression Expr)
    {

    }
    public void Acople(List<tuple<Expression,string>> Ops,Expression Expr)
    {

    }
}
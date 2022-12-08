using System.Collections.Generic;
namespace Compiler;
public class Parser
{
    public void Parse(List<string> Tokens)
    {
            
    }
    public Expression ParseSimpleExpr(List<string> Tokens)
    {
        Stack<Tuple<Expression, string>> Ops = new Stack<Tuple<Expression, string>>();
        int last = -1;
        int parCount = 0;
        bool isFun = false;
        Expression CurExpr=new SumExpr();
        for(int i=0; i<Tokens.Count;i++)
        {
            if (Tokens[i] == "(")
            {
                if (parCount == 0)
                {
                    string x = "a";
                    if (last == -1 || char.IsLetter(Tokens[last][0]) || Tokens[last][0] == '_')
                    {
                        isFun = false;
                        last = i + 1;
                    }
                    else
                    {
                        isFun = true;
                    }
                }
                parCount++;
                continue;
            }
            if (Tokens[i] == ")")
            {
                parCount--;
                if (parCount == 0)
                {
                    if (isFun)
                    {
                        CurExpr = ParseFunCall(SubList(Tokens,last, i));
                    }
                    else
                    {
                        
                        CurExpr = ParseSimpleExpr(SubList(Tokens,last,i - 1));
                    }
                }
                continue;
            }
            if (parCount != 0)
            {
                continue;
            }
            if (Jerarquia.Jerarchy.ContainsKey(Tokens[i]))
            {
                if(Tokens[i]=="-")
                {

                    continue;    
                }
                Acople(Ops,Tokens[i],CurExpr);            

                continue;
            }
            last=i;
            CurExpr=ParseTerm(Tokens[i]);

        }
        return null;
    }
    public List<string> SubList(List<string> Tokens,int ini,int last){
        return Tokens;
    }
    public FunCall ParseFunCall(List<string> Tokens)
    {
            return null;
    }
    public Expression ParseTerm(string s)
    {
            return null;
    }
    public void Acople(Stack<Tuple<Expression,string>> Ops,string s,Expression Expr)
    {
            
    }
    public void Acople(Stack<Tuple<Expression,string>> Ops,Expression Expr)
    {
            
    }
    public BinaryExpr Pa(string Symbol)
    {   
        BinaryExpr Ans=new SumExpr();
        switch (Symbol)
        {
            case "*":Ans=new MultExpr();break;
            case "/":Ans=new DivExpr();break;
            case "%":Ans=new ModExpr();break;
            case "+":Ans=new SumExpr();break;
            case "-":Ans=new RestExpr();break;
            case "<":Ans=new BLessExpr();break;
            case ">":Ans=new BGreatExpr();break;
            case "<=":Ans=new BLessOrEqualExpr();break;
            case ">=":Ans=new BGreatOrEqualExpr();break;
            case "==":Ans=new BEqualExpr();break;
            case "!=":Ans=new BNotEqualExpr();break;
            case "&":Ans=new AndExpr();break;
            case "^":Ans=new XorExpr();break;
            case "|":Ans=new OrExpr();break;
            case "&&":Ans=new BAndExpr();break;
            case "||":Ans=new BOrExpr();break;
            case "=":Ans=new AssignExpr(null);break;
            case "+=":Ans=new AssignExpr("+");break;
            case "-=":Ans=new AssignExpr("-");break;
            case "*=":Ans=new AssignExpr("*");break;
            case "/=":Ans=new AssignExpr("/");break;
            case "%=":Ans=new AssignExpr("%");break;
            case "&=":Ans=new AssignExpr("&");break;
            case "|=":Ans=new AssignExpr("|");break;
            case "^=":Ans=new AssignExpr("^");break;
            default:break;
        }
        return Ans;
    }
}
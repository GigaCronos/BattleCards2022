using System.Collections.Generic;
using System;
using Extensors;
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
        Expression CurExpr=null;
        for(int i=0; i<Tokens.Count;i++)
        {
            if (Tokens[i] == "(")
            {
                if (parCount == 0)
                {
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
                        CurExpr = ParseFunCall(Tokens.SubList(last, i));
                    }
                    else
                    {     
                        CurExpr = ParseSimpleExpr(Tokens.SubList(last,i - 1));
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
    public FunCall ParseFunCall(List<string> Tokens)
    {
            return null;
    }
    public Expression ParseTerm(string s)
    {
        if(s==null)
        if(char.IsLetter(s[0]) || s[0]=='_'){
           foreach(var d in s){
               if(!(char.IsLetterOrDigit(d) || d=='_')){
                   //Declarar Error
               }
           }
           return new Variable(s); 
        }
        if(char.IsDigit(s[0])){
            foreach(var d in s){
               if(!char.IsDigit(d)){
                   //Declarar Error
               }
           }
           return new Number(s);
        }
        if(s[0]=='"'){
            if(s[s.Length-1]!='"'){
                //Declarar Error
            }
            return new StringNode(s.Substring(1,s.Length-2));
        }
        //Declarar error
        throw new ArgumentException();
    }
    public void Acople(Stack<Tuple<Expression,string>> Ops,string s,Expression Expr)
    {
            
    }
    public void Acople(Stack<Tuple<Expression,string>> Ops,Expression Expr)
    {
            
    }
    public BinaryExpr CreateBinExpr(string Symbol)
    {   
        BinaryExpr Ans=null;
        switch (Symbol)
        {
            case "*":Ans=new MultExpr(null,null);break;
            case "/":Ans=new DivExpr(null,null);break;
            case "%":Ans=new ModExpr(null,null);break;
            case "+":Ans=new SumExpr(null,null);break;
            case "-":Ans=new RestExpr(null,null);break;
            case "<":Ans=new BLessExpr(null,null);break;
            case ">":Ans=new BGreatExpr(null,null);break;
            case "<=":Ans=new BLessOrEqualExpr(null,null);break;
            case ">=":Ans=new BGreatOrEqualExpr(null,null);break;
            case "==":Ans=new BEqualExpr(null,null);break;
            case "!=":Ans=new BNotEqualExpr(null,null);break;
            case "&":Ans=new AndExpr(null,null);break;
            case "^":Ans=new XorExpr(null,null);break;
            case "|":Ans=new OrExpr(null,null);break;
            case "&&":Ans=new BAndExpr(null,null);break;
            case "||":Ans=new BOrExpr(null,null);break;
            case "=":Ans=new AssignExpr(null,null,null);break;
            case "+=":Ans=new AssignExpr("+",null,null);break;
            case "-=":Ans=new AssignExpr("-",null,null);break;
            case "*=":Ans=new AssignExpr("*",null,null);break;
            case "/=":Ans=new AssignExpr("/",null,null);break;
            case "%=":Ans=new AssignExpr("%",null,null);break;
            case "&=":Ans=new AssignExpr("&",null,null);break;
            case "|=":Ans=new AssignExpr("|",null,null);break;
            case "^=":Ans=new AssignExpr("^",null,null);break;
            default:break;
        }
        return Ans;
    }
}
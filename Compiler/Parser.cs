using System.Collections.Generic;
using System;
using Extensors;
namespace Compiler;
public class Parser
{
    public Node Parse(List<string> Tokens)
    {
            
    }
    public Expression ParseSimpleExpr(List<string> Tokens)
    {
        if(Tokens.Count==1)
        return ParseTerm(Tokens[0]);
        int parCount = 0;
        int best=-1;
        for(int i=0;i<Tokens.Count;i++)
        {
            if (Tokens[i] == "(")
            {
                parCount++;    
            }
            if (Tokens[i] == ")")
            {
                parCount--;
            }
            if(parCount==0 && i!=0 && Tokens[i-1]!="(" && Jerarquia.Jerarchy.ContainsKey(Tokens[i]))
            {
                if(best==-1){
                    best=i;
                }
                if(Jerarquia.Jerarchy[Tokens[best]]<=Jerarquia.Jerarchy[Tokens[i]]){
                    best=i;
                }
            }
        }
        if(best==Tokens.Count-1)
        throw Exception("Expected Variable or Number after "+Tokens[best]);
        if(best!=-1){
            return CreateBinExpr(Tokens[best],ParseSimpleExpr(Tokens.SubList(0,best-1)),ParseSimpleExpr(Tokens.SubList(best+1,Tokens.Count-1)));
        }

        if(Jerarquia.Jerarchy.ContainsKey(Tokens[0])){
            return CreateUnExpr(Tokens[0],ParseSimpleExpr(Tokens.SubList(1,Tokens.Count-1)));
        }

        if(Tokens[0]=="("){
            if(Tokens[Tokens.Count-1]==")")
            return ParseSimpleExpr(1,Tokens.Count-2);
            throw new Exception("Expected )");
        }

        if(Tokens[Tokens.Count-1]==")"){
            return ParseFuntionCall(Tokens);
        }
        throw new Exception("Unidentified Error");
    }    
    public FunCall ParseFuntionCall(List<string> Tokens)
    {
        string Id=Tokens[0];
        if(char.IsLetter(Id[0]) || Id[0]=='_'){
           foreach(var d in Id){
               if(!(char.IsLetterOrDigit(d) || d=='_')){
                   throw new Exception("Invalid Function Name "+Id);
               }
           } 
        }else{
            throw new Exception("Invalid Function Name "+Id);
        } 
        if(Tokens[1]!="(" || Tokens[Tokens.Count-1]!=")")
            throw new Exception("Invalid Function Call "+Id);
        return FunCall(Id,ParseSimpleExpressionsList(Tokens.SubList(2,Tokens.Count-2)));
    }
    public List<Expressions> ParseSimpleExpressionsList(List<string> Tokens){
        int parCount = 0;
        int last=-1;
        List<Expressions> Li;
        for(int i=0;i<Tokens.Count;i++)
        {
            if (Tokens[i] == "(")
            {
                parCount++;    
            }
            if (Tokens[i] == ")")
            {
                parCount--;
            }
            if(Tokens[i]=="," && parCount==0){
                Li.Add(ParseSimpleExpr(Tokens.SubList(last+1,i-1)));
                last=i;
            }
        }
        return Li;
    }
    public Expression ParseTerm(string s)
    {
        if(s==null){
            throw new Exception("Unidentified Error");
        }
        if(char.IsLetter(s[0]) || s[0]=='_'){
           foreach(var d in s){
               if(!(char.IsLetterOrDigit(d) || d=='_')){
                   throw new Exception("Invalid Variable Name "+s);
               }
           }
           return new Variable(s); 
        }
        if(char.IsDigit(s[0])){
            foreach(var d in s){
               if(!char.IsDigit(d)){
                   throw new Exception("Invalid Number "+s);
               }
           }
           return new Number(s);
        }
        if(s[0]=='"'){
            if(s[s.Length-1]!='"'){
                throw new Exception("Missing \" in "+ s);
            }
            return new StringNode(s.Substring(1,s.Length-2));
        }
        throw new Exception("Invalid Character "+s[0]);
    }
    public BinaryExpr CreateBinExpr(string Symbol,Expression a,Expression b)
    {   
        BinaryExpr Ans=null;
        switch (Symbol)
        {
            case "*":Ans=new MultExpr(a,b);break;
            case "/":Ans=new DivExpr(a,b);break;
            case "%":Ans=new ModExpr(a,b);break;
            case "+":Ans=new SumExpr(a,b);break;
            case "-":Ans=new RestExpr(a,b);break;
            case "<":Ans=new BLessExpr(a,b);break;
            case ">":Ans=new BGreatExpr(a,b);break;
            case "<=":Ans=new BLessOrEqualExpr(a,b);break;
            case ">=":Ans=new BGreatOrEqualExpr(a,b);break;
            case "==":Ans=new BEqualExpr(a,b);break;
            case "!=":Ans=new BNotEqualExpr(a,b);break;
            case "&":Ans=new AndExpr(a,b);break;
            case "^":Ans=new XorExpr(a,b);break;
            case "|":Ans=new OrExpr(a,b);break;
            case "&&":Ans=new BAndExpr(a,b);break;
            case "||":Ans=new BOrExpr(a,b);break;
            case "=":Ans=new AssignExpr(null,a,b);break;
            case "+=":Ans=new AssignExpr("+",a,b);break;
            case "-=":Ans=new AssignExpr("-",a,b);break;
            case "*=":Ans=new AssignExpr("*",a,b);break;
            case "/=":Ans=new AssignExpr("/",a,b);break;
            case "%=":Ans=new AssignExpr("%",a,b);break;
            case "&=":Ans=new AssignExpr("&",a,b);break;
            case "|=":Ans=new AssignExpr("|",a,b);break;
            case "^=":Ans=new AssignExpr("^",a,b);break;
            default:throw new Exception("Unidentified Error");break;
        }
        return Ans;
    }
    public UnaryExpr CreateUnExpr(string Symbol,Expression a){
        UnaryExpr Ans=null;
        switch (Symbol)
        {
            case "-":Ans=new NegativeExpr(a);break;
            case "!":Ans=new BNotExpr(a);break;
            case "~":Ans=new NotExpr(a);break;
            default:throw new Exception("Unidentified Error");break;
        }
        return Ans;
    }
}
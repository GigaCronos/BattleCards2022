using System.Collections.Generic;
using System;
using Extensors;
namespace Compiler;
public class Parser
{
    public ComandBlock Parse(List<string> Tokens)
    {
        List<List<string>> Li=new List<List<string>>();
        List<Expression> Li2=new List<Expression>();
        int last=-1;
        int OpenBraquet=0;
        for(int i=0;i<Tokens.Count;i++){
            if(Tokens[i]=="{"){
              OpenBraquet++;  
            }
            if(Tokens[i]=="}"){
                OpenBraquet--;
                if(OpenBraquet==0){
                    Li.Add(Tokens.SubList(last+1,i));
                }
            }
            if(OpenBraquet==0 && Tokens[i]==";"){
                Li.Add(Tokens.SubList(last+1,i));
            }
        }
        foreach(var Expr in Li){
            switch(Expr[0]){
                case "while":{
                    int c1=-1;
                    int parCount=0;
                    for(int i=1;i<Expr.Count;i++){
                        if (Expr[i] == "(")
                        {
                            parCount++;    
                        }
                        if (Expr[i] == ")")
                        {
                            parCount--;
                            if(parCount==0){
                                c1=i;
                                break;
                            }
                        }
                    }
                    if(parCount!=0)throw new Exception("Expected "+(parCount>(int)0?")":"("));
                    if(c1==-1)throw new Exception("Expected ( after while statement");
                    if(c1==Expr.Count-1)throw new Exception("Expected Bracket Enclosed Block after )");
                    if(Expr[c1+1]!="{")throw new Exception("Expected Bracket Enclosed Block after )");
                    if(Expr[Expr.Count-1]!="}")throw new Exception("Expected }");
                    Li2.Add(new WhileStat(ParseSimpleExpr(Expr.SubList(2,c1-1)),Parse(Expr.SubList(c1+2,Expr.Count-2))));
                }break;
                case "if":{
                    int c1=-1;
                    int parCount=0;
                    for(int i=1;i<Expr.Count;i++){
                        if (Expr[i] == "(")
                        {
                            parCount++;    
                        }
                        if (Expr[i] == ")")
                        {
                            parCount--;
                            if(parCount==0){
                                c1=i;
                                break;
                            }
                        }
                    }
                    if(parCount!=0)throw new Exception("Expected "+(parCount>(int)0?")":"("));
                    if(c1==-1)throw new Exception("Expected ( after if statement");
                    if(c1==Expr.Count-1)throw new Exception("Expected Bracket Enclosed Block after )");
                    if(Expr[c1+1]!="{")throw new Exception("Expected Bracket Enclosed Block after )");
                    if(Expr[Expr.Count-1]!="}")throw new Exception("Expected }");
                    Li2.Add(new IfStat(ParseSimpleExpr(Expr.SubList(2,c1-1)),Parse(Expr.SubList(c1+2,Expr.Count-2))));
                }break;
               /* case "return":{
                    int c1=1;
                    if(c1==Expr.Count-1)throw new Exception("Expected Bracket Enclosed Block after overallcards statememnt");
                    if(Expr[c1+1]!="{")throw new Exception("Expected Bracket Enclosed Block after overallcards statement");
                    if(Expr[Expr.Count-1]!="}")throw new Exception("Expected }");
                    Li2.Add(new OverallcardsStat(Parse(Expr.SubList(2,Expr.Count-2))));
                }break;*/
                case "int":{
                    if(Expr[Expr.Count-1]!=";")throw new Exception("No variable declaration containing Bracket Enclosed Block at "+Expr[1]);
                    if(IsAValidId(Expr[1])){
                        Li2.Add(new DeclareVar(Expr[1]));
                        Li2.Add( ParseSimpleExpr(Expr.SubList(1,Expr.Count-2)));
                    }else{
                        throw new Exception("Not valid Variable name "+Expr[1]);
                    }
                }break;
                case "string":{
                    if(Expr[Expr.Count-1]!=";")throw new Exception("No variable declaration containing Bracket Enclosed Block at "+Expr[1]);
                    if(IsAValidId(Expr[1])){
                        Li2.Add(new DeclareVar(Expr[1]));
                        Li2.Add(ParseSimpleExpr(Expr.SubList(1,Expr.Count-2)));
                    }else{
                        throw new Exception("Not valid Variable name "+Expr[1]);
                    }
                }break;
                default:{
                    if(Expr[Expr.Count-1]!=";")throw new Exception("No variable declaration containing Bracket Enclosed Block");
                    Li2.Add(ParseSimpleExpr(Expr.SubList(1,Expr.Count-2)));
                }break;
            }
        }
        return new ComandBlock(Li2);
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
        throw new Exception("Expected Variable or Number after "+Tokens[best]);
        if(best!=-1){
            return CreateBinExpr(Tokens[best],ParseSimpleExpr(Tokens.SubList(0,best-1)),ParseSimpleExpr(Tokens.SubList(best+1,Tokens.Count-1)));
        }

        if(Jerarquia.Jerarchy.ContainsKey(Tokens[0])){
            return CreateUnExpr(Tokens[0],ParseSimpleExpr(Tokens.SubList(1,Tokens.Count-1)));
        }

        if(Tokens[0]=="("){
            if(Tokens[Tokens.Count-1]==")")
            return ParseSimpleExpr(Tokens.SubList(1,Tokens.Count-2));
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
        if(!IsAValidId(Id)){
            throw new Exception("Invalid Funcition name "+Id);
        }
        if(Tokens[1]!="(" || Tokens[Tokens.Count-1]!=")")
            throw new Exception("Invalid Function Call "+Id);
        return new FunCall(Id,ParseSimpleExpressionsList(Tokens.SubList(2,Tokens.Count-2)));
    }
    public List<Expression> ParseSimpleExpressionsList(List<string> Tokens){
        int parCount = 0;
        int last=-1;
        List<Expression> Li=new List<Expression>();
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
        if(IsAValidId(s)){
            return new Variable(s);
        }
        if(IsANumber(s)){
            return new Number(s);
        }
        if(s[0]=='"'){
            if(s[s.Length-1]!='"'){
                throw new Exception("Missing \" in "+ s);
            }
            return new StringNode(s.Substring(1,s.Length-2));
        }
        throw new Exception("Invalid Character at "+s);
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
            case "=":Ans=new AssignExpr((Variable)a,b);break;
            default:throw new Exception("Unidentified Error");
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
            default:throw new Exception("Unidentified Error");
        }
        return Ans;
    }
    public bool IsAValidId(string s){
        if(char.IsLetter(s[0]) || s[0]=='_'){
           foreach(var d in s){
               if(!(char.IsLetterOrDigit(d) || d=='_')){
                   return false;
               }
           }
           return true; 
        }
        return false;
    }
    public bool IsANumber(string s){
         if(char.IsDigit(s[0])){
            foreach(var d in s){
               if(!char.IsDigit(d)){
                   return false;
               }
           }
           return true;
        }
        return false;       
    }
}
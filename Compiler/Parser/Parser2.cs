using System.Collections.Generic;
using Extensors;
using System;
namespace Compiler;

public static partial class Parser
{

    public static (List<DefFun>,List<AssignExpr>) Parse(List<string> Tokens)
    {
            List<DefFun> DF=new List<DefFun>();
            List<AssignExpr> AE =new List<AssignExpr>();
            int ParCount=0;//Conteo de Parenthesis
            int last=0;       
            for(int i=0;i<Tokens.Count;i++){
                if(Tokens[i]=="{")ParCount++;
                if(Tokens[i]=="}"){
                    ParCount--;
                    if(ParCount==0){
                        DF.Add(ParseFunDef(Tokens.SubList(last,i)));
                        last=i+1;
                    }
                }
                if(Tokens[i]==";"){
                    if(ParCount==0){
                        AE.Add(ParseAssign(Tokens.SubList(last,i)));
                        last=i+1;
                    }
                }
            }
            return (DF,AE);
    }

    public static DefFun ParseFunDef(List<string> Tokens)
    {
        string Identifier=Tokens[0];
        if(!IsAValidId(Tokens[0])){
            throw new Exception("Invalid Function Name "+ Tokens[0]);
        }
        if(Tokens[1]!="("){
                throw new Exception("Missing ( at "+Tokens[0]);
        }
        List<string> Args=new List<string>();
        ComandBlock Body=null;
        for(int i=2;i<Tokens.Count;i++){
            if(Tokens[i]==")"){
                Body=ParseBlock(Tokens.SubList(i+2,Tokens.Count-2));
                break;
            }
            if(Tokens[i]!=",")
            Args.Add(Tokens[i]);
            if(i==Tokens.Count-1){
                throw new Exception("Missing ) at "+Tokens[0]);
            }
        }
        
        return new DefFun(Identifier,Args,Body);       
    }

    public static AssignExpr ParseAssign(List<string> Tokens){
        if(Tokens.Count==0){
            throw new Exception("Empty assignment");
        }
        if(!IsAValidId(Tokens[0])){
            Console.WriteLine(Tokens[0]);
            throw new Exception("Invalid Variable Name "+ Tokens[0]);
        }
        if(Tokens[1]!="="){
            throw new Exception("Not Valid Assignment at "+ Tokens[0]);
        }
        return new AssignExpr(new Variable(Tokens[0]),ParseSimpleExpr(Tokens.SubList(2,Tokens.Count-2)));
    }


}
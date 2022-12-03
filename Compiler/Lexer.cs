namespace Compiler;
public static class Lexer
{   
    public static List<string> Lex(string Sinput){
        List<string> List=new List<string>();
        bool QuotMark=false;
        int last=-1;
        bool OpenVariable=false;
        LexAutomaton Automaton=new LexAutomaton();
        var CurNode=Automaton.root;
        for(int i=0;i<Sinput.Length;i++)
        {
            if(QuotMark==true){
                if(Sinput[i]=='"' && Sinput[i-1]!='\\')
                {
                    QuotMark=false;
                    List.Add(Sinput.Substring(last,i-last+1));
                    last=-1;
                }   
                continue;
 
            }
            if(Sinput[i]=='"')
            {
                last=i;
                QuotMark=true;
                if(CurNode!=Automaton.root)
                {
                   List.Add(CurNode.Symbol); 
                   CurNode=Automaton.root;
                }else if(OpenVariable)
                {
                    List.Add(Sinput.Substring(last,i-last));
                    last=-1;
                    OpenVariable=false;
                }
                continue;
            }
            if(Sinput[i]==';' || Sinput[i]=='{' || Sinput[i]=='}')
            {
                if(CurNode!=Automaton.root)
                {
                   List.Add(CurNode.Symbol); 
                   CurNode=Automaton.root;
                }else if(OpenVariable)
                {
                    List.Add(Sinput.Substring(last,i-last));
                    last=-1;
                    OpenVariable=false;
                }
                List.Add(""+Sinput[i]);
                continue; 
            }
            if(Jerarquia.Jerarchy.ContainsKey(""+Sinput[i]))
            {
                if(OpenVariable)
                {
                    List.Add(Sinput.Substring(last,i-last));
                    last=-1;
                    OpenVariable=false;
                }
                if(CurNode.Edges.ContainsKey(Sinput[i]))
                {
                    CurNode=CurNode.Edges[Sinput[i]];
                }else
                {
                    List.Add(CurNode.Symbol);
                    CurNode=Automaton.root;
                    CurNode=CurNode.Edges[Sinput[i]];
                }
                continue;
            }
            if(Sinput[i]==' ' || Sinput[i]=='\n' || Sinput[i]=='\t')
            {
                if(OpenVariable)
                {
                    OpenVariable=false;
                    List.Add(Sinput.Substring(last,i-last));
                }
                continue;
            }
            if(!OpenVariable){
            if(CurNode!=Automaton.root)
                {
                   List.Add(CurNode.Symbol); 
                   CurNode=Automaton.root;
                }
            last=i;
            OpenVariable=true;
            }
        }
        if(OpenVariable)
        {
            OpenVariable=false;
            List.Add(Sinput.Substring(last,Sinput.Length-last));
        }
        if(CurNode!=Automaton.root)
        {
           List.Add(CurNode.Symbol); 
           CurNode=Automaton.root;
        }
    
        return List;
    }

}


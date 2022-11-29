namespace Compiler;
public class Parser
{   
    public string[] Lexer(string Sinput){
        string[] List=new List[];
        bool QuotMark=false;
        int last=0;
        bool OpenVariable=false;
        LexAutomaton Automaton=new LexAutomaton();
        Automaton.AutNode CurNode=Automaton.root;
        for(int i=0;i<Length(Sinput);i++)
        {
            if(QuotMark==true){
                if(Sinput[i]=='"' && Sinput[i-1]!='\\')
                {
                    QuotMark=false;
                    List.Add(Sinput.Substring(last,i-last+1));
                    continue;
                }
            }
            if(Sinput[i]==';')
            {

            }
            if(Jerarchy.ContainsKey(Sinput[i]))
            {

            }
            if(Sinput[i]==' ' || Sinput[i]=='\n' || Sinput=='\t')
            {

            }

        }
    }

}

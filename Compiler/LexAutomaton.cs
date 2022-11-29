using Compiler;
public class LexAutomaton
{
    class AutNode
    {
        string Symbol;
        Dictionary<char,AutNode> Edges;
        AutNode()
        {
            Edges=new Dictionary<string, AutNode>();
        }
        public void Add(AutNode a,char b)
        {
            Edges.Add(b.Symbol,a);
        }
    };
    AutNode root;
    LexAutomaton(){
        root=new AutNode();
        foreach(var Str in Jerarchy)
        {
            AutNode cur=root;
            foreach(var ch in Str.Key)
            {
                if(!cur.Edges.ContainsKey(ch)){
                   cur.Add(new AutNode(),ch); 
                }
                cur=cur.Edges[ch];               
            }
            cur.Symbol=Str.Key;
        }
    }
}
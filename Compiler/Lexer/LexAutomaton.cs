namespace Compiler;
public class LexAutomaton
{
    public class AutNode
    {
        public string ? Symbol;
        public Dictionary<char,AutNode> Edges;
        public AutNode()
        {
            Edges=new Dictionary<char ,AutNode>();
        }
        public void Add(AutNode a,char b)
        {
            Edges.Add(b,a);
        }
    };
    public  AutNode root;
    public LexAutomaton(){
        root=new AutNode();
        foreach(var Str in Jerarquia.Jerarchy)
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
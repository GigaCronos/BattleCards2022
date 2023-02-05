namespace CardsEngine;
public class Catalog:ICatalog{
    private Dictionary<string,IMonsterCard> Cards; //All the Cards. Key:Card Name(string), Value:Card(IMonsterCard)
    private List<string> Names;//Listed Names. Ordered lexicographicly
    public string this[int index]{get{return Names[index];}}//Get a Card of the List given index
    public int Count{get{return Names.Count;}}//Number of Cards in this Catalog
    public Catalog(){
        Cards=new Dictionary<string, IMonsterCard>();
        Names=new List<string>();
    }
    public void AddCard(string Name,string Info,string Script){
        if(!Cards.ContainsKey(Name)){
            Cards.Add(Name,new MonsterCard(Name,Info,Script));
            Names.Add(Name);
            Names.Sort((p,q)=>p.CompareTo(q));
        }     
    }
    //Returns the Info of a Card
    public string GetInfo(string Name){
        if(Cards.ContainsKey(Name))
        return (string)Cards[Name].Info.Clone();
        return null;
    }
    //Returns a Copy of the Card Given its Name. Catalog Cards can't be modified externally
    public IMonsterCard GetCard(string Name){
        if(Cards.ContainsKey(Name))
        return (MonsterCard)Cards[Name].Clone();
        return null;
    }
    //Enumerates all the Cards of the Catalog in lexicographic order
    public IEnumerable<string> GetCards(){
        foreach(var a in Names){
            yield return (string)a.Clone();
        }
    }
    //Validates the sintaxis of the CardScript
    public bool IsValid(string s){ 
        if(Cards.ContainsKey(s)){
            return Cards[s].Validate();
        }else{
            return false;
        }
    }
}
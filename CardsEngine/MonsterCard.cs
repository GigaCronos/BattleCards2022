namespace CardsEngine;
using Compiler;
using Extensors;
public class MonsterCard: IMonsterCard{
    public string Name{get;private set;}//Card Name
    public string Info{get;private set;}//Card Info
    private Script CardScript{get;set;}//Script ya compilado
    private string OriginalText{get;set;}//Texto Original del Codigo

    public MonsterCard(string s,string info,string script){
        Name=s;
        try{
        CardScript= new Script(script);
        }catch(System.Exception a){
            Console.WriteLine("An Error Ocurred at "+s);
            Console.WriteLine(a);
            throw new System.Exception("");
        }
        
        Info=info;
        OriginalText=script;
    }
    public int Health{
    get{
        return CardScript.GetStat("Health");
    }
    }
    public int Defense{
    get{
       return CardScript.GetStat("Defense");
    }
    }
    public int Damage{
    get{
        return CardScript.GetStat("Damage");
    }
    }
    public int Speed{
    get{
        return CardScript.GetStat("Speed");
    }
    }
    public int Mana{
        get{
            return CardScript.GetStat("Mana");
        }
    }
    public object Clone(){
        return new MonsterCard((string)Name.Clone(),(string)Info.Clone(),(string)OriginalText.Clone());
    }
    //Validates the Script
    public bool Validate(){
        return CardScript.Validate();
    }
    //Perform action over a Monster
    public int Handle(string action,params int[] L){
        return CardScript.Handle(action,L);
    }
    //Perform the action from the Monster
    public int Perform(string action,params int[] L){
        return CardScript.Perform(action,L);
    }
    //List of avaliable actions for this Monster
    public List<string> Actions(){
        return CardScript.Actions();
    }
    //Trigger the Passives habilities of this Monster
    public void TriggerPassive(){
        CardScript.Passive();
    }
}
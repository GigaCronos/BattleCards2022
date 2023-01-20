namespace CardsEngine;
using Compiler;
using Extensors;
public class MonsterCard: IMonsterCard
{
    public string Name{get;private set;}
    private Script CardScript{get;set;}
    public Properties Stats{get;set;}

    public MonsterCard(string s,string script){
        Name=s;
        Stats=new Properties();
        CardScript= new Script(script,Stats);
    }
    public bool DealDamage(int D){
        return CardScript.DealDamage(D);
    }
    public int Atack(){
        return CardScript.Atack();
    }
}
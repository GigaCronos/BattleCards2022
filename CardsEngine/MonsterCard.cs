namespace CardsEngine;
public class MonsterCard: IMonsterCard
{
    public int Energy{get;set;}
    public Element element{get;private set;}
    public int Damage{get;private set;}
    public int Health{get;private set;}
    public string Name{get;private set;}
    public int Defense{get;private set;}
    public int Speed{get;private set;}
    public int Player{get;private set;}
    public MonsterCard(string s,int da,int h,int de,int ty){
        Name=s;Health=h;
        Damage=da;Defense=de;
        Player=ty;
    }
    public bool DealDamage(int D){
        if(Defense==0){
            Health-=D;
        }else{
            Defense-=(D+1)/2;
            Defense=Math.Max(Defense,0);
        }
        return Health<=0;
    }
    public void Atack(IBoard B,IMonsterCard C,int Dam){
        C.DealDamage(Dam);
        B.Update();
    }
}
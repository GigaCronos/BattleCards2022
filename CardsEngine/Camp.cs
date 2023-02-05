using System.Collections.Generic;
using System.Collections;
namespace CardsEngine;

public class Camp: ICamp
{
    private int PlayerNumber;
    private List<IMonsterCard> Cards;
    private Logger L;
    private int Slots;

    public Camp(int s,Logger l,int p){
        Slots=s;
        PlayerNumber=p;
        L=l;
        Cards=new List<IMonsterCard>();
        for(int i=0;i<Slots;i++){
            Cards.Add(null);
        }
    }

    public IEnumerator<IMonsterCard> GetEnumerator(){
        foreach(var crd in Cards){
            yield return crd;
        }
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Destroy(){
        for(int i=0;i<Slots;i++){
            Cards[i]=null;
        }
    }

    public IMonsterCard this[int index]{get{return Cards[index];}}

    public void Update(){
        foreach(var a in Cards){
           if(a!=null)
            a.TriggerPassive();
        }   
        for(int i=0;i<Slots;i++){
            if(Cards[i]!=null && Cards[i].Health<0){
                L.Add($"{Cards[i].Name} of Player{PlayerNumber+1} has Died");
                Cards[i]=null;
            }
        }
    }

    public int AddCard(IMonsterCard C){
        for(int i=0;i<Slots;i++){
                if(Cards[i]==null){
                Cards[i]=C;
                return i;
                }
        }
        return -1;
    }

    public bool Empty(){
        foreach(var a in Cards){
            if(a!=null)
            return false;
        }
        return true;
    }

}
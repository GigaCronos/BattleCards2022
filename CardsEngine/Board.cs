using System.Collections.Generic;
using Extensors;
namespace CardsEngine;
public class Board: IBoard
{
    public List<IMonsterCard> Cards1;
    public List<IMonsterCard> Cards2;
    public OrderedList<int,IMonsterCard> Heap;
    public Board(){
        Cards1=new List<IMonsterCard>(6);
        Cards2=new List<IMonsterCard>(6);
        Heap=new OrderedList<int,IMonsterCard>( (q,p) => q<=p);
    }
    public void AddNewCard(string s,int ty,string txt)
    {
        IMonsterCard card= new MonsterCard(s,txt);
        if(ty==1){
            Cards1.Add(card);
        }else{
            Cards2.Add(card);
        }
        Heap.PushBack(new Tuple<int,IMonsterCard>(card.Stats.Speed,card)); 
    }
    public void Update(){
        
    }
    public int NextCard(){
        var A=Heap.Front();
        Heap.Remove(0);
        for(int i=0;i<Heap.Count;i++){
            Heap[i]=new System.Tuple<int, IMonsterCard>(Heap[i].Item1-A.Item1,Heap[i].Item2);
        }
        Heap.PushBack(new System.Tuple<int, IMonsterCard>(A.Item2.Stats.Speed,A.Item2));
        for(int i=0;i<6;i++){
            if(Cards1[i]!=null && Cards1[i].GetHashCode()==A.GetHashCode()){
                return i;
            }
            if(Cards2[i]!=null && Cards2[i].GetHashCode()==A.GetHashCode()){
                return 6+i;
            }
        }
        return -1;
    }
    public IEnumerable<IMonsterCard> Player1Cards{
        get{
            foreach(var c in Cards1){
                yield return c;
            }
        }
    }

    public IEnumerable<IMonsterCard> Player2Cards{
        get{
            foreach(var c in Cards2){
                yield return c;
            }
        }
    }

    public IMonsterCard GetCard(int pos){
        if(pos<6)
        return Cards1[pos];
        else
        return Cards2[pos-6];
    }


}
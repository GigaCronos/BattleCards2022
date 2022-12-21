using System.Collections.Generic;
using Extensors;
namespace CardsEngine;
public class Board: IBoard
{
    public List<IMonsterCard> Cards1;
    public List<IMonsterCard> Cards2;
    public OrderedList<int,IMonsterCard> Heap;
    public Board(){
        Cards1=new List<IMonsterCard>();
        Cards2=new List<IMonsterCard>();
        Heap=new OrderedList<int,IMonsterCard>( (q,p) => q<=p);
    }
    public void AddNewCard(string s,int da,int h,int de,int sp,int ty)
    {
        IMonsterCard card= new MonsterCard(s,da,h,de,sp,ty);
        if(ty==1){
            Cards1.Add(card);
        }else{
            Cards2.Add(card);
        }
        Heap.PushBack(new Tuple<int,IMonsterCard>(card.Speed,card));
        
    }
    public void Update(){
        
    }
    public IMonsterCard NextCard(){
        var A=Heap.Front();
        Heap.Remove(0);
        for(int i=0;i<Heap.Count;i++){
            Heap[i]=new System.Tuple<int, IMonsterCard>(Heap[i].Item1-A.Item1,Heap[i].Item2);
        }
        Heap.PushBack(new System.Tuple<int, IMonsterCard>(A.Item2.Speed,A.Item2));
        return A.Item2;
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




}
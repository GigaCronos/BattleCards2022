using System.Collections.Generic;
namespace CardsEngine;
public class Board: IBoard
{
    public List<IMonsterCard> Cards1;
    public List<IMonsterCard> Cards2;
    public List<IMonsterCard> Heap;  
    int k;
    public Board(){
        Cards1=new List<IMonsterCard>();
        Cards2=new List<IMonsterCard>();
        Heap=new List<IMonsterCard>();
        k=-1;
    }
    public void AddNewCard(string s,int da,int h,int de,int ty)
    {
        IMonsterCard card= new MonsterCard(s,da,h,de,ty);
        if(ty==1){
            Cards1.Add(card);
        }else{
            Cards2.Add(card);
        }
        Heap.Add(card);
        
    }
    public void Update(){
        
    }
    public IMonsterCard NextCard(){
       k++;
       if(k==Heap.Count){
               k=0;
        }
        return Heap[k];
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
using Extensors;
namespace CardsEngine;
public class GameQueue{
public IBoard Tablero;
OrderedList<int,int> Heap;//This structure handle the Order of the Cards in the Game, Based on their Speed
public GameQueue(IBoard B){
Tablero=B;
Heap=new OrderedList<int,int>( (q,p) => q<=p);
}

public int NextCard(){
        if(Heap.Count==0){
            return -1;
        }
        var A=Heap.Front();
        Heap.Remove(0);
        if(Tablero.GetCard(A.Item2)==null)
        return NextCard();
        for(int i=0;i<Heap.Count;i++){
            Heap[i]=new System.Tuple<int, int>(Heap[i].Item1-A.Item1,Heap[i].Item2);
        }
        Heap.PushBack(new System.Tuple<int, int>(Tablero.GetCard(A.Item2).Speed,A.Item2));
        return A.Item2;
}

public void AddCard(int pos,IMonsterCard C){
     Heap.PushBack(new Tuple<int,int>(C.Speed,pos)); 
}

}
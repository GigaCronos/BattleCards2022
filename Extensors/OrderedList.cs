using System;
using System.Collections.Generic;
using System.Collections;
namespace Extensors;

public class OrderedList<TKey,TValue>: IEnumerable<Tuple<TKey,TValue>>
{
    public int Count{get;private set;}
    List<Tuple<TKey,TValue>> Li;
    Comparission<TKey> C;
    public OrderedList(Comparission<TKey> c){
        Li=new List<Tuple<TKey,TValue>>();
        Count=0;
        C=c;
    }
    public Tuple<TKey,TValue> this[int index]{get{return Li[index];}set{Li[index]=value;}}
    public IEnumerator<Tuple<TKey,TValue>> GetEnumerator(){
        foreach(var crd in Li){
            yield return crd;
        }
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    public void Sort(){
        for(int i=0;i<Li.Count;i++){
            for(int j=0;j<Li.Count-1;j++){
                if(!C(Li[j].Item1,Li[j+1].Item1)){
                    (Li[j],Li[j+1])=(Li[j+1],Li[j]);
                }
            }
        }
    }
    public void Remove(int index){
        Li.RemoveRange(index,1);
        Count--;
    }
    public void PushBack(Tuple<TKey,TValue> t){
            Count++;
            Li.Add(t);
            Sort();
    }

    public void PushFront(Tuple<TKey,TValue> t){
            Count++;
            Li.Insert(0,t);
            Sort();
    }
    
    public Tuple<TKey,TValue> Front(){
        if(Li.Count>0)
        return Li[0];
        throw new ArgumentException();
    }

}
public delegate bool Comparission<T>(T a,T b);
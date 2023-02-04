using System.Collections.Generic;
using Extensors;
namespace CardsEngine;
public class Board: IBoard
{
    private int Slots;//Number of Slots per Player
    public List<IMonsterCard>[] Cards;//The Cards on the Board
    public OrderedList<int,int> Heap;//This structure handle the Order of the Cards in the Game, Based on their Speed
    public Board(int n){
        Cards=new List<IMonsterCard>[2];
        Slots=n;
        Cards[0]=new List<IMonsterCard>(Slots);
        Cards[1]=new List<IMonsterCard>(Slots);
        for(int i=0;i<Slots;i++){
            Cards[0].Add(null);Cards[1].Add(null);
        }
        Heap=new OrderedList<int,int>( (q,p) => q<=p);
    }
    public void AddNewCard(IMonsterCard card,int ty)
    {
        int pos=0;
        if(ty==1){
            for(int i=0;i<Slots;i++){
                if(Cards[0][i]==null){
                Cards[0][i]=card;
                pos=i;
                break;
                }
            }
        }else{
            for(int i=0;i<Slots;i++){
                if(Cards[1][i]==null){
                Cards[1][i]=card;
                pos=i+Slots;
                break;
                }
            }
        }
        Heap.PushBack(new Tuple<int,int>(card.Speed,pos)); 
    }
    //This Method Update the Board,Triggering Monster Passives and Handling Monster dying in the current Turn.
    public void Update(){
        foreach(var a in Cards[0]){
           if(a!=null)
            a.TriggerPassive();
        }
        foreach(var a in Cards[1]){
            if(a!=null)
            a.TriggerPassive();
        }   
        for(int i=0;i<Slots;i++){
            if(Cards[0][i]!=null && Cards[0][i].Health<0){
                Log+=$"\n {Cards[0][i].Name} of Player1 has Died";
                Cards[0][i]=null;
            }
            if(Cards[1][i]!=null && Cards[1][i].Health<0){
                Log+=$"\n {Cards[1][i].Name} of Player2 has Died";
                Cards[1][i]=null;
            }
        }
    }
    //Tells if Some Player Already Won,1 for Player2 ,2 for Player 1 and 0 for a Draw
    public int IsAWin(){
        int L1=0,L2=0;
        foreach(var a in Cards[0]){
            if(a!=null)
            L1=1;
        }
         foreach(var a in Cards[1]){
            if(a!=null)
            L2=1;
        }
        int ans=(L1)*2+L2;
        switch(ans){
            case 0:{Log+="\n Game is Finished Now. Is a Draw";}break;
            case 1:{Log+="\n Game is Finished Now. Player2 has Won";}break;
            case 2:{Log+="\n Game is Finished Now. Player1 has Won";}break;
            default:break;
        }
        return ans;
    }
    //Gives the Position of the Card on current Turn
    public int NextCard(){
        Log="";
        if(Heap.Count==0){
            return -1;
        }
        var A=Heap.Front();
        Heap.Remove(0);
        if(GetCard(A.Item2)==null)
        return NextCard();
        for(int i=0;i<Heap.Count;i++){
            Heap[i]=new System.Tuple<int, int>(Heap[i].Item1-A.Item1,Heap[i].Item2);
        }
        Heap.PushBack(new System.Tuple<int, int>(GetCard(A.Item2).Speed,A.Item2));
        return A.Item2;
    }
    //Enumerates all the Cards of one Player
    public IEnumerable<IMonsterCard> PlayerCards(int n){
            foreach(var c in Cards[n-1]){
                yield return c;
            }
    }
    //Returns an IMonsterCard object given the position,null if the Slot is Empty 
    public IMonsterCard GetCard(int pos){
        if(pos<0 || pos>11)
        return null;
        if(pos<Slots)
        return Cards[0][pos];
        else
        return Cards[1][pos-Slots];
    }
    //Destroy all the Cards of a Player(Use for Surrender)
    public void Destroy(int P){
        for(int i=0;i<Slots;i++){
            Cards[P-1][i]=null;
        }
    }
    //Enumerates the Actions that some Card can do
    public List<string> Actions(int pos,int Pla){
        return Cards[Pla-1][pos].Actions();
    } 
    //Return a Message and a Menu for Graphic Interface based on What a player can do with the Card
    public (string,List<string>) ActionTarget(string action,int pos,int Pla){
        string message="";
        List<string> Menu=new List<string>();
        switch(action){
            case "Attack":{
                message="Select Your Target for Attack";
                foreach(var a in Cards[2-Pla]){
                    if(a!=null)
                    Menu.Add(a.Name);
                }
            }break;
            case "Heal":{
                message="What Hero Do You Wanna Heal?";
                foreach(var a in Cards[Pla-1]){
                    if(a!=null)
                    Menu.Add(a.Name);
                }
            }break;
            case "Buff":{
                message="Boost! Boost! Boooost!";
                Menu.Add("Continue");    
            }break;
            case "Buff1":{
                message="Boost! Boost! Boooost!";
                Menu.Add("Continue");
            }break;
            case "Buff2":{
                message="Boost! Boost! Boooost!";
                Menu.Add("Continue");
            }break;
            default:{
                message="Who is the Chosen one for the suffering?";
                foreach(var a in Cards[2-Pla]){
                    if(a!=null)
                    Menu.Add(a.Name);
                }
            }break;
        }
        return (message,Menu);
    }
    //Perform the current action of the Card over another Card or Over Himself
    public void PerformAction(string action,int target,int pos,int Pla){
         switch(action){
            case "Attack":{
                int D=Cards[Pla-1][pos].Perform(action);
                int New=0,Old=0;
                string t="";
                foreach(var a in Cards[2-Pla]){
                    if(a==null)continue;
                    if(target==0){
                        Old=a.Health;
                        a.Handle(action,D);
                        t=a.Name;
                        New=a.Health;
                        break;
                    }
                    target--;
                }
               Log=Cards[Pla-1][pos].Name+" atacked "+t+$" and Dealed {Old-New} points of Damage";
            }break;
            case "Heal":{
                int D=Cards[Pla-1][pos].Perform(action);
                int New=0,Old=0;
                string t="";
                foreach(var a in Cards[Pla-1]){
                    if(a==null)continue;
                    if(target==0){
                        Old=a.Health;
                        a.Handle(action,D);
                        t=a.Name;
                        New=a.Health;
                        break;
                    }
                    target--;
                }
                Log=Cards[Pla-1][pos].Name+" healed "+t+$" for {New-Old} points";
            }break;
            case "Buff":{
                Cards[Pla-1][pos].Perform(action);    
                Log="You feel Enlightened "+Cards[Pla-1][pos].Name;
            }break;
            case "Buff1":{
                Cards[Pla-1][pos].Perform(action);
                Log="You feel Enlightened "+Cards[Pla-1][pos].Name;
            }break;
            case "Buff2":{
                Cards[Pla-1][pos].Perform(action);
                Log="You feel Enlightened "+Cards[Pla-1][pos].Name;
            }break;
            default:{
                int D=Cards[Pla-1][pos].Perform(action);
                int New=0,Old=0;
                string t="";
                foreach(var a in Cards[2-Pla]){
                    if(a==null)continue;
                    if(target==0){
                        Old=a.Health;
                        a.Handle("Magic",D);
                        t=a.Name;
                        New=a.Health;
                        break;
                    }
                    target--;
                }
                Log=Cards[Pla-1][pos].Name+" hit "+t+$" with magic dealing {Old-New} points of Damage";
            }break;
        }

    }
    public string Log{get;private set;}//Show What Happened in that Turn
}
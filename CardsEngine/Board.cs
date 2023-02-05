using System.Collections.Generic;
using Extensors;
namespace CardsEngine;
public class Board: IBoard
{
    private int Slots;//Number of Slots per Player
    private ICamp[] Cards;//The Cards on the Board
    private GameQueue Heap;
    private Logger L=new Logger();

    
    public Board(int n){
        Cards=new ICamp[2];
        Slots=n;
        Cards[0]=new Camp(Slots,L,0);
        Cards[1]=new Camp(Slots,L,1);    
        Heap=new GameQueue(this);
    }
    public void AddNewCard(IMonsterCard card,int ty)
    {
        int pos=0;
        if(ty==1){
            pos=Cards[0].AddCard(card);
        }else{
           pos=Cards[1].AddCard(card)+Slots;
        }
       Heap.AddCard(pos,card);
    }
    //This Method Update the Board,Triggering Monster Passives and Handling Monster dying in the current Turn.
    public void Update(){
        Cards[0].Update();
        Cards[1].Update();
    }
    //Tells if Some Player Already Won,1 for Player2 ,2 for Player 1 and 0 for a Draw
    public int IsAWin(){
        int L1=Cards[0].Empty()?0:1,L2=Cards[1].Empty()?0:1;
        int ans=(L1)*2+L2;
        switch(ans){
            case 0:{L.Add("Game is Finished Now. Is a Draw");}break;
            case 1:{L.Add("Game is Finished Now. Player2 has Won");}break;
            case 2:{L.Add("Game is Finished Now. Player1 has Won");}break;
            default:break;
        }
        return ans;
    }
    //Gives the Position of the Card on current Turn
    public int NextCard(){
        L.Reset();
       return Heap.NextCard();
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
        Cards[P-1].Destroy();
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
               L.Add(Cards[Pla-1][pos].Name+" atacked "+t+$" and Dealed {Old-New} points of Damage");
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
                L.Add(Cards[Pla-1][pos].Name+" healed "+t+$" for {New-Old} points");
            }break;
            case "Buff":{
                Cards[Pla-1][pos].Perform(action);    
                L.Add("You feel Enlightened "+Cards[Pla-1][pos].Name);
            }break;
            case "Buff1":{
                Cards[Pla-1][pos].Perform(action);
                L.Add("You feel Enlightened "+Cards[Pla-1][pos].Name);
            }break;
            case "Buff2":{
                Cards[Pla-1][pos].Perform(action);
                L.Add("You feel Enlightened "+Cards[Pla-1][pos].Name);
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
                L.Add(Cards[Pla-1][pos].Name+" hit "+t+$" with magic dealing {Old-New} points of Damage");
            }break;
        }

    }
   //Show What Happened in that Turn
    public string Log{get{return L.Display;}}

}
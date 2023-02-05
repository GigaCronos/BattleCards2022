using CardsEngine;
using Extensors;
public partial class GInterface{
    public void StartGameMenu(){
        G.DisplayMenu(new string[]{"StartGame","Back"});
        G.Update();
        int n=G.GetEvent();
        if(n==0){
            Match();
        }else{
            if(n==1){
                PlayMenu(4);
            }else{
                PlayMenu(5);
            }
        }

    }
    public void Match(){
        Tablero=new Board(CSlots);
        PlayerInterface[0].AddCards();
        PlayerInterface[1].AddCards();
        while(true){
        int pos=Tablero.NextCard();
        if(pos<0)
        throw new Exception();
        if(pos<CSlots){
            PlayerInterface[0].NextTurn(pos);
        }else{
            PlayerInterface[1].NextTurn(pos-CSlots);
        }
        Tablero.Update();
        int d=Tablero.IsAWin();
        G.DisplayMessage(CampInfo());
        G.DisplayMessage(Tablero.Log);
        G.Update();
        Utils.Wait(3500);
        if(d!=3)
        break;
        }
        MainMenu();
    }

}
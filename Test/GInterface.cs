using CardsEngine;
public class GInterface{
    IBoard Tablero;
    public GInterface(IBoard B){
        Tablero=B;
    }
    public void Show(){
        Console.WriteLine("Player1");
        foreach(var a in Tablero.Player1Cards){
            Console.WriteLine(a.Name+" "+a.Health+" "+a.Defense+" "+a.Damage);
        }
        Console.WriteLine("\n"+"Player2");
        foreach(var a in Tablero.Player2Cards){
            Console.WriteLine(a.Name+" "+a.Health+" "+a.Defense+" "+a.Damage);
        }
        Console.WriteLine();
    }

    public void NextTurn(){
        Show();
        IMonsterCard C=Tablero.NextCard();
        Console.WriteLine("Turn of "+C.Name);
        Atack(C); 
        Tablero.Update();
        if(IsAWin(C.Player))
        return;
        NextTurn();
    }

    public void Atack(IMonsterCard Atacker){
        Console.WriteLine("Time to Attack Payer"+Atacker.Player);
        string s=Console.ReadLine();
        IEnumerable<IMonsterCard> Ser=Atacker.Player==1 ? Tablero.Player2Cards:Tablero.Player1Cards;
        foreach(var crd in Ser){
            if(crd.Name==s){
                crd.DealDamage(Atacker.Damage);
                return;
            }
        }
        Console.WriteLine("Invalid Card");
        Atack(Atacker);
    }

    public bool IsAWin(int t){
        bool W1=true,W2=true;
        foreach(var crd in (t==1?Tablero.Player2Cards:Tablero.Player1Cards)){
            if(crd.Health>0){
            W1=false;
            break;
            }
        }
        foreach(var crd in (t!=1?Tablero.Player2Cards:Tablero.Player1Cards)){
            if(crd.Health>0){
            W2=false;
            break;
            }
        }
        if(W1 && W2){
            Console.WriteLine("Is a Draw");
            return true;
        }
        if(W1){
            Console.WriteLine("Player "+t+" has Won");
            return true;
        }
        if(W2){
            Console.WriteLine("Player "+(int)(3-t)+" has Won");
            return true;
        }
    return false;
    }
}
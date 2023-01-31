using CardsEngine;
using System;
public partial class GInterface{
    public IBoard Tablero{get;private set;}
    public ICatalog Catalogo{get;private set;}
    GComponent G;
    IPlayer[] PlayerInterface;
    public GInterface(IBoard B,ICatalog C){
        Tablero=B;
        G=new GComponent();
        Catalogo=C;
        PlayerInterface=new IPlayer[2];
    }
    public void Run(){
        MainMenu();
    }
    public void Show(){
        Console.Clear();
        Console.ForegroundColor=ConsoleColor.Red;
        Console.WriteLine("Player1");
        foreach(var a in Tablero.Player1Cards){
            if(a==null){
                Console.WriteLine("EmptySlot");
                continue;
            }
            Console.WriteLine(a.Name+" "+a.Health+" "+a.Defense+" "+a.Damage);
        }
        Console.WriteLine("\n"+"Player2");
        foreach(var a in Tablero.Player2Cards){
            if(a==null){
                Console.WriteLine("EmptySlot");
                continue;
            }
            Console.WriteLine(a.Name+" "+a.Health+" "+a.Defense+" "+a.Damage);
        }
        Console.WriteLine();
    }

    public void NextTurn(){
        Show();
        int C=Tablero.NextCard();
        Atack(C); 
        Tablero.Update();
        if(IsAWin(C<6?1:2))
        return;
        NextTurn();
    }

    public void Atack(int pos){
        Console.WriteLine("Time to Attack Payer"+(pos>=6?2:1)+"! Your "+Tablero.GetCard(pos).Name+" is ready");
        string s=Console.ReadLine();
        int A;
        try
        {
            A=Int32.Parse(s);
            A--;
        }catch(System.Exception){
            A=-1;
        }
        if(Tablero.GetCard(A)==null || ((pos<6) == (A<6))){
        Console.WriteLine("Invalid Card");
        Atack(pos);
        }else{
        int D=Tablero.GetCard(pos).Atack();
        Tablero.GetCard(A).DealDamage(D);
        }
    }

    public bool IsAWin(int t){
        bool W1=true,W2=true;
        foreach(var crd in (t==1?Tablero.Player2Cards:Tablero.Player1Cards)){
            if(crd==null)
            continue;
            if(crd.Health>0){
            W1=false;
            break;
            }
        }
        foreach(var crd in (t!=1?Tablero.Player2Cards:Tablero.Player1Cards)){
            if(crd==null)
            continue;
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
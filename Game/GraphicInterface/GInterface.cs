using CardsEngine;
using System;
public partial class GInterface{
    public IBoard Tablero{get;private set;}
    public ICatalog Catalogo{get;private set;}
    GComponent G;
    IPlayer[] PlayerInterface;
    public GInterface(ICatalog C){
        G=new GComponent();
        Catalogo=C;
        PlayerInterface=new IPlayer[2];
    }
    public void Run(){
        MainMenu();
    }
   
}
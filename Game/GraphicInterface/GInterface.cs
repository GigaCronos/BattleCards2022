using CardsEngine;
using System;
public partial class GInterface{
    public IBoard Tablero{get;private set;}
    public ICatalog Catalogo{get;private set;}
    GComponent G;
    IPlayerInterface[] PlayerInterface;
    public GInterface(ICatalog C){
        G=new GComponent();
        Catalogo=C;
        PlayerInterface=new IPlayerInterface[2];
    }
    public void Run(){
        MainMenu();
    }
   
}
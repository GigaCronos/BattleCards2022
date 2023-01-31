using CardsEngine;
using System.IO;

IBoard Tablero=new Board();
Compiler.Jerarquia.precalc();
string path=Directory.GetCurrentDirectory();
path=path+"\\Test\\Cards";
Directory.SetCurrentDirectory(path);
DirectoryInfo di=new DirectoryInfo(path);
ICatalog C= new Catalog();
foreach(var a in di.GetDirectories()){
    string name=a.Name;
    string cad=File.ReadAllText(path+"\\"+name+"\\"+name+".txt");

    C.AddCard(name,"feo",cad);
}
GInterface Game=new GInterface(Tablero,C);
Game.Run();
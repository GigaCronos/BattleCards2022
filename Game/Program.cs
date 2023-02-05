using CardsEngine;
using System.IO;

Compiler.Jerarchy.precalc();
string path=Directory.GetCurrentDirectory();
path=path+"\\Game\\Cards";
Directory.SetCurrentDirectory(path);
DirectoryInfo di=new DirectoryInfo(path);
ICatalog C= new Catalog();
string Base=File.ReadAllText(path+"\\"+"base.txt");
foreach(var a in di.GetDirectories()){
    string name=a.Name;
   
    string cad="";
    try{
    cad=File.ReadAllText(path+"\\"+name+"\\"+name+".txt");
    }catch(System.Exception){
        continue;
    }
    
    string info="No Info";
    try
    {
        info=File.ReadAllText(path+"\\"+name+"\\Info.txt");
    }
    catch (System.Exception)
    {
        
    }
    C.AddCard(name,info,Base+cad);
}
GInterface Game=new GInterface(C);
Game.Run();


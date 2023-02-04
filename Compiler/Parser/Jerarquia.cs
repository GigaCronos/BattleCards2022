namespace Compiler;
public static class Jerarchy{
    //Jerarchy table for operators and symbols
    public static Dictionary<string,int> ? JerarchyTab;
    public static void precalc()
    {
    JerarchyTab=new Dictionary<string, int>{
    {".",1},{"[",1},{"]",1},{"(",1},{")",1},
    {"!",2},{"~",2},
    {"*",3},{"/",3},{"%",3},
    {"+",4},{"-",4},
    {"<",5},{">",5},{"<=",5},{">=",5},
    {"==",6},{"!=",6},
    {"&",7},
    {"^",8},
    {"|",9},
    {"&&",10},
    {"||",11},
    {"=",12},{"+=",12},{"-=",12},{"*=",12},{"/=",12},{"%=",12},{"&=",12},{"|=",12},{"^=",12},
    {",",13},
    };

    }
}
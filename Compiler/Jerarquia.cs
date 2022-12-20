namespace Compiler;
public static class Jerarquia{
    public static Dictionary<string,int> ? Jerarchy;
    public static void precalc()
    {
    Jerarchy=new Dictionary<string, int>{
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
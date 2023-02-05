using System.Diagnostics;
namespace Extensors;
public static class Utils{
    public static void Wait(int n){
    Stopwatch F=new Stopwatch();
    F.Start();
    long d=F.ElapsedMilliseconds;
    while(true){
        if(F.ElapsedMilliseconds-d>n){
            F.Stop();
            break;
        }
    }
    }
}
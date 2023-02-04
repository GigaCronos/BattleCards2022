using System.Diagnostics;
partial class GInterface{
    public void Wait(int n){
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
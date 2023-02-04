public class Greedy01:IPlayer{
    int PlayerNumber;
    public Greedy01(int n){PlayerNumber=n;}
    public int ChooseSlot(IEnumerable<string> Slots){
        int cont=0;
        foreach(var a in Slots){
               if(a=="[Empty]")
               return cont;
               cont++; 
        }
        return -1;
    }

    public int ChooseCards(IEnumerable<string> Cards){
        Random rnd=new Random();
        int p=rnd.Next(1000);
        int cant=0;
        foreach(var a in Cards)cant++;
        p%=cant;
        return p;
    }

    public int Actions(IEnumerable<string> actions){
        int ind=0;
        int cant=0;
        foreach(var a in actions){
            if(a=="Attack")
            ind=cant;
            cant++;
        }
        if(cant==1)
        return 0;
        Random rnd=new Random();
        int p=rnd.Next();
        p%=100;
        if(p<70)
        return ind;
        p-=70;
        p%=(cant-1);
        return 1+p;

    }
    public int SelectTarget(IEnumerable<string> Cards,string action ){
        return 0;
    }

}
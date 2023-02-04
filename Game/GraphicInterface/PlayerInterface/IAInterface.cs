public class IAInterface:IPlayerInterface{
    public int PlayerNumber{get;private set;}//[1,2]
    private GComponent GComp{get;set;}//Graphic Component
    private GInterface GInt{get;set;}//Main Graphic Interface
    string[] Slots;// Slots for Cards
    private IPlayer Player;
    public IAInterface(int n,GComponent g,GInterface interf){
        PlayerNumber=n;
        GComp=g;            
        GInt=interf;
        Slots=new string[GInt.CSlots];
        Player=new Greedy01(PlayerNumber);
        for(int i=0;i<GInt.CSlots;i++){
            Slots[i]="[Empty]";
        }
    }
    //Menu for choosing Slot to fill 
    public bool ChooseSlot(){
        bool IsFilled=true;
        foreach(var s in Slots){
            if(s=="[Empty]")
            IsFilled=false;
        }
        if(IsFilled){
            return true;
        }
        int n=Player.ChooseSlot((string[])Slots.Clone());
        if(0<=n && n<GInt.CSlots){ 
            string s=ChooseCards();
            if(s==null){
               return ChooseSlot();
            }
            foreach(var a in Slots){
                if(s==a){
                    return ChooseSlot();
                }
            }
            Slots[n]=s;
            return ChooseSlot();     
        }
        return false;
    }
    private string ChooseCards(){
        int n=Player.ChooseCards(GInt.Catalogo.GetCards());   
        if(0<=n && n<GInt.Catalogo.Count)
        {
            if(!GInt.Catalogo.IsValid(GInt.Catalogo[n])){
                return ChooseCards();
            } 
            return GInt.Catalogo[n];
        }
        if(n==GInt.Catalogo.Count){
            return null;
        }
        return ChooseCards();
    }     
    //Add the Cards of this player to the Board
    public void AddCards(){
        foreach(var a in Slots){
            GInt.Tablero.AddNewCard(GInt.Catalogo.GetCard(a),PlayerNumber);
        }
    }

    public void NextTurn(int pos){
        List<string> actions=GInt.Tablero.Actions(pos,PlayerNumber);
        int n=Player.Actions(actions);
        if(n<actions.Count() && n>=0){
           List<string> b;
           string a;
           (a,b)=GInt.Tablero.ActionTarget(actions[n],pos,PlayerNumber);
           int n1=Player.SelectTarget(b,actions[n]);
           if(n1<b.Count()){
               GInt.Tablero.PerformAction(actions[n],n1,pos,PlayerNumber); 
           }else{
                NextTurn(pos);
           }
        }else{
            if(n==actions.Count()){
                GInt.Tablero.Destroy(PlayerNumber);
            }else{
                NextTurn(pos);
            }
        }
    }
   
    
}

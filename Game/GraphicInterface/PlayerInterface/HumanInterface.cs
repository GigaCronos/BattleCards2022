using Extensors;
public class HumanInterface:IPlayerInterface{
    public int PlayerNumber{get;set;}//[1,2]
    string[] Slots;// Slots for Cards
    public GComponent GComp;//Graphic Component
    private GInterface GInt{get;set;}//Main Graphic Interface
    public HumanInterface(int n,GComponent g,GInterface interf){
        PlayerNumber=n;
        GComp=g;
        GInt=interf;
        Slots=new string[GInt.CSlots];
        for(int i=0;i<GInt.CSlots;i++){
            Slots[i]="[Empty]";
        }
    }
    //Menu for choosing Slot to fill 
    public bool ChooseSlot(){
        GComp.DisplayMessage("Choose an slot to fill Player"+$"{PlayerNumber}");
        GComp.DisplayMenu(Slots);
        bool IsFilled=true;
        foreach(var s in Slots){
            if(s=="[Empty]")
            IsFilled=false;
        }
        if(IsFilled){
            GComp.DisplayMenu(new string[1]{"Ready"});
        }
        GComp.DisplayMenu(new string[1]{"Back"});
        GComp.Update();
        int n=GComp.GetEvent();
        if(0<=n && n<GInt.CSlots){ 
            string s=ChooseCards();
            if(s==null){
               return ChooseSlot();
            }
            foreach(var a in Slots){
                if(s==a){
                    GComp.DisplayMessage("This Card Has Been Chosen Already");
                    GComp.Update();
                    Utils.Wait(2000);
                    return ChooseSlot();
                }
            }
            Slots[n]=s;
            return ChooseSlot();     
        }
        if(IsFilled){
            if(n==GInt.CSlots)
                return true;
            if(n==GInt.CSlots+1)
                return false;
            return ChooseSlot();
        }else{
            if(n==GInt.CSlots)
                return false;
            return ChooseSlot();
        }

    }
    private string ChooseCards(){
        GComp.DisplayMessage("Choose your Card Payer"+$"{PlayerNumber}");
        GComp.DisplayMenu(GInt.Catalogo.GetCards());
        GComp.DisplayMenu(new string[]{"Back"});
        GComp.Update();
        int n=GComp.GetEvent();   
        if(0<=n && n<GInt.Catalogo.Count)
        {
            if(!GInt.Catalogo.IsValid(GInt.Catalogo[n])){
                GComp.DisplayMessage("This Card has some Errors, please fix them before playing");
                GComp.Update();
                Utils.Wait(2500);  
                return ChooseCards();
            }
            if(CardChoosingMenu(GInt.Catalogo[n]))    
            return GInt.Catalogo[n];
            else
            return ChooseCards();
        }
        if(n==GInt.Catalogo.Count){
            return null;
        }
        return ChooseCards();
    }
    private bool CardChoosingMenu(string Name){
            GComp.DisplayMessage("Are you sure you want this Card?");
            GComp.DisplayMenu(new string[]{"Accept","CardInfo","Back"});
            GComp.Update();
            int n=GComp.GetEvent();
            switch(n){
                case 0:{return true;}
                case 1:{
                    ShowCardInfo(Name);
                    return CardChoosingMenu(Name);
                }
                case 2:{return false;}
                
                default: return CardChoosingMenu(Name);
            }
    }
    private void ShowCardInfo(string Name){
            GComp.DisplayMessage(GInt.Catalogo.GetInfo(Name));
            GComp.DisplayMenu(new string[]{"Back"});
            GComp.Update();
            int n=GComp.GetEvent();
            if(n!=0)
            ShowCardInfo(Name);
    }
   //Add the Cards of this player to the Board
    public void AddCards(){
        foreach(var a in Slots){
            GInt.Tablero.AddNewCard(GInt.Catalogo.GetCard(a),PlayerNumber);
        }
    }
    public void NextTurn(int pos)
    {
        GComp.DisplayMessage(GInt.CampInfo());
        GComp.DisplayMessage($"Is your turn Player {PlayerNumber}! Your {Slots[pos]} is Ready!");
        List<string> actions=GInt.Tablero.Actions(pos,PlayerNumber);
        GComp.DisplayMenu(actions);
        GComp.DisplayMenu(new string[]{"Surrender"});
        GComp.Update();
        int n=GComp.GetEvent();
        if(n<actions.Count() && n>=0){
           string a;
           List<string> b;
           (a,b)=GInt.Tablero.ActionTarget(actions[n],pos,PlayerNumber);
           GComp.DisplayMessage(a);
           GComp.DisplayMenu(b);
           GComp.Update();
           int n1=GComp.GetEvent();
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
public class HumanInterface:IPlayer{
    public int PlayerNumber{get;set;}
    string[] Slots=new string[6];
    public GComponent GComp;
    private GInterface GInt{get;set;}
    public HumanInterface(int n,GComponent g,GInterface interf){
        PlayerNumber=n;
        GComp=g;
        GInt=interf;
        for(int i=0;i<6;i++){
            Slots[i]="[Empty]";
        }
    }

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
        if(0<=n && n<6){ 
            string s=ChooseCards();
            if(s==null){
               return ChooseSlot();
            }
            foreach(var a in Slots){
                if(s==a){
                    GComp.DisplayMessage("This Card Has Been Chosen Already");
                    GComp.Update();
                    GInt.Wait(2000);
                    return ChooseSlot();
                }
            }
            Slots[n]=s;
            return ChooseSlot();     
        }
        if(IsFilled){
            if(n==6)
                return true;
            if(n==7)
                return false;
            return ChooseSlot();
        }else{
            if(n==6)
                return false;
            return ChooseSlot();
        }

    }

    public string ChooseCards(){
        GComp.DisplayMessage("Choose your Card Payer"+$"{PlayerNumber}");
        GComp.DisplayMenu(GInt.Catalogo.GetCards());
        GComp.DisplayMenu(new string[]{"Back"});
        GComp.Update();
        int n=GComp.GetEvent();   
        if(0<=n && n<GInt.Catalogo.Count)
        {
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

    public bool CardChoosingMenu(string Name){
            GComp.DisplayMessage("Are you sure you want this Card?");
            GComp.DisplayMenu(new string[]{"Accept","CardInfo","Back"});
            GComp.Update();
            int n=GComp.GetEvent();
            switch(n){
                case 0:return true;
                break;
                case 1:{
                    ShowCardInfo(Name);
                    return CardChoosingMenu(Name);
                }break;
                case 2:return false;
                break;
                default: return CardChoosingMenu(Name);
            }
    }

    public void ShowCardInfo(string Name){
            GComp.DisplayMessage(GInt.Catalogo.GetInfo(Name));
            GComp.DisplayMenu(new string[]{"Back"});
            GComp.Update();
            int n=GComp.GetEvent();
            if(n!=0)
            ShowCardInfo(Name);
    }
}

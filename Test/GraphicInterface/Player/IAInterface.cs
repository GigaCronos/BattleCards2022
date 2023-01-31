public class IAInterface:IPlayer{
    public int PlayerNumber{get;set;}
    private GComponent GComp{get;set;}
    private GInterface GInt{get;set;}
    public IAInterface(int n,GComponent g,GInterface i){
        PlayerNumber=n;
        GComp=g;            
        GInt=i;
    }
    public bool ChooseSlot(){
        return true; 
    }
    public string ChooseCards(){
                return "";
    }
    
}

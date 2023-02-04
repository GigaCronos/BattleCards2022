public class IAInterface:IPlayer{
    public int PlayerNumber{get;set;}
    private GComponent GComp{get;set;}//Graphic Component
    private GInterface GInt{get;set;}//Main Graphic Interface
    string[] Slots;// Slots for Cards
    public IAInterface(int n,GComponent g,GInterface i){
        PlayerNumber=n;
        GComp=g;            
        GInt=i;
        Slots=new string[GInt.CSlots];
    }
    //Menu for Slot to fill choosing
    public bool ChooseSlot(){
        int cont=0;
        for(int i=0;i<GInt.Catalogo.Count;i++){
            if(cont==GInt.CSlots){
            return true; 
            }
            if(GInt.Catalogo.IsValid(GInt.Catalogo[i])){
              Slots[cont]=GInt.Catalogo[i];
              cont++;  
            }
        }
        return false;
    }
    //Add the Cards of this player to the Board
    public void AddCards(){
        foreach(var a in Slots){
            GInt.Tablero.AddNewCard(GInt.Catalogo.GetCard(a),PlayerNumber);
        }
    }

    public void NextTurn(int pos){

    }
    
}

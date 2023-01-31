public partial class GInterface{
    public void StartGame(){
        G.DisplayMenu(new string[]{"StartGame","Back"});
        G.Update();
        int n=G.GetEvent();                     
    }

}
public partial class GInterface{

    private void MainMenu(){
        string[] Buttons=new string[3]{"Play","Options","Quit"};
        G.DisplayMessage("Main Menu");
        G.DisplayMenu(Buttons);
        G.Update();
        int n=G.GetEvent();
        switch(n){
            case 0:{
                PlayMenu();
            }break;
        
            case 1:{
                OptionsMenu();
            }break;
            
            case 2:{
                G.DisplayMessage("Thanks for Playing with Us!");
                G.Update();
                Wait(2500);
                Environment.Exit(0);
            }break;
            default:{
                   MainMenu();
            }break;
        }
    }

}
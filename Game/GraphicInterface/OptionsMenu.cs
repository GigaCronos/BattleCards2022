public partial class GInterface{
    public int CSlots=3;
    private void OptionsMenu(){
        G.DisplayMessage("Options");
        G.DisplayMenu(new string[]{$"Number of Players: {CSlots}",$"ForeGround Color: {G.ForeGround}",$"BackGround Color: {G.BackGround}","Back"});
        G.Update();
        int n=G.GetEvent();
        switch(n){
            case 0:{
                ChangeNumberOfPLayers();
            }break;
            case 1:{
                ChangeForeGroundColor();
            }break;
            case 2:{
                ChangeBackGroundColor();
            }break;
            case 3:{
                MainMenu();
            }break;
            default:{
                OptionsMenu();
            }break;
        }
    }

    private void ChangeNumberOfPLayers(){
        G.DisplayMessage("Write a Number from 1 to 6");
        G.Update();
        int n=G.GetEvent();
        if(n>=1 && n<=6){
            CSlots=n;
        }
        OptionsMenu();
    }
    private void ChangeBackGroundColor(){
        G.DisplayMessage("Select a Color for Background");
        G.DisplayMenu( new string[]{"Black","White","Red","Blue","Green","Yellow","Cyan"});
        G.Update();
        int n=G.GetEvent();
        switch(n){
            case 0: G.BackGround=ConsoleColor.Black;break;
            case 1: G.BackGround=ConsoleColor.White;break;
            case 2: G.BackGround=ConsoleColor.DarkRed;break;
            case 3: G.BackGround=ConsoleColor.DarkBlue;break;
            case 4: G.BackGround=ConsoleColor.DarkGreen;break;
            case 5: G.BackGround=ConsoleColor.DarkYellow;break;
            case 6: G.BackGround=ConsoleColor.DarkCyan;break;
            default:ChangeBackGroundColor();break;
        }
        OptionsMenu();
    }
    private void ChangeForeGroundColor(){
        G.DisplayMessage("Select a Color for Foreground");
        G.DisplayMenu( new string[]{"Black","White","Red","Blue","Green","Yellow","Cyan"});
        G.Update();
        int n=G.GetEvent();
        switch(n){
            case 0: G.ForeGround=ConsoleColor.Black;break;
            case 1: G.ForeGround=ConsoleColor.White;break;
            case 2: G.ForeGround=ConsoleColor.DarkRed;break;
            case 3: G.ForeGround=ConsoleColor.DarkBlue;break;
            case 4: G.ForeGround=ConsoleColor.DarkGreen;break;
            case 5: G.ForeGround=ConsoleColor.DarkYellow;break;
            case 6: G.ForeGround=ConsoleColor.DarkCyan;break;
            default:ChangeForeGroundColor();break;
        }
        OptionsMenu();
    }
}
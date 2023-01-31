public partial class GInterface{
        public void PlayMenu(int p=1){
                switch(p){
                        case 1:{
                                ChooseTypeOfPlayer(1);
                        }break;
                        case 2:{
                                ChooseTypeOfPlayer(2);
                        }break;
                        case 3:{
                                if(PlayerInterface[0].ChooseSlot()){
                                        PlayMenu(4);
                                }else{
                                        PlayMenu(2);
                                }
                        }break;
                        case 4:{
                                if(PlayerInterface[1].ChooseSlot()){
                                        PlayMenu(5);
                                }else{
                                        PlayMenu(3);
                                }                                
                        }break;
                        case 5:{
                                StartGame();
                        }break;
                        case 0:{
                                MainMenu();
                        }break;
                }
        }
        private void ChooseTypeOfPlayer(int p){
                G.DisplayMessage("Choose Player"+$"{p}");
                G.DisplayMenu(new string[3]{"Human","IA","Back"});
                G.Update();
                int n=G.GetEvent();
                switch(n){  
                        case 0:{
                                PlayerInterface[p-1]=new HumanInterface(p,G,this);
                                PlayMenu(p+1);
                        }break;
                        case 1:{
                                PlayerInterface[p-1]=new IAInterface(p,G,this);
                                PlayMenu(p+1);
                        }break;
                        case 2:{
                                PlayMenu(p-1);
                        }break;
                        default:{
                                PlayMenu(p);
                        }break;
                }
        }

}
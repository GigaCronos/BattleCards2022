 public class GComponent{
    private string Display{get;set;}
    private int CounterAction{get;set;}
    public ConsoleColor BackGround{get;set;}
    public ConsoleColor ForeGround{get;set;}


    public GComponent(){
       Reset();
    }
    
    public void DisplayMenu(IEnumerable<string> Args){
        foreach(var s in Args){
            Display+=($"{CounterAction}-"+s+"\r\n");
            CounterAction++;
        }
    }
    
    public void DisplayMessage(string S){
        Display+=S+"\n";
    }

    public void Update(){
        Console.Clear();
        Console.BackgroundColor=BackGround;
        Console.ForegroundColor=ForeGround;
        Console.Write(Display);
        Reset();
    }
    public int GetEvent(){
        string s=Console.ReadLine();
        int a=-1;
        try{
            a=Int32.Parse(s);
        }catch(System.Exception g){
            a=-1;
        }
        return a;
    }
    private void Reset(){
        Display="";
        CounterAction=0;
        BackGround=ConsoleColor.Black;
        ForeGround=ConsoleColor.White;
    }


 }
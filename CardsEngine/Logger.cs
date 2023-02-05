namespace CardsEngine;
public class Logger{

public string Display;
public Logger(){
    Reset();
}
public void Reset(){
    Display="";
}
public void Add(string m){
    Display+=m+'\n';
}    
public string GetMessage(){
    return Display;
}


} 
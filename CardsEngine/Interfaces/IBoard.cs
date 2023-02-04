namespace CardsEngine;

public interface IBoard{
    void Update();    
    IEnumerable<IMonsterCard> PlayerCards(int n);
    int NextCard();
    void AddNewCard(IMonsterCard card,int ty);
    IMonsterCard GetCard(int pos);
    string Log{get;}
    void Destroy(int P);
    List<string> Actions(int pos,int PLa);
    (string,List<string>) ActionTarget(string action,int pos,int Pla);
    void PerformAction(string action,int target,int pos,int Pla);
    int IsAWin();
}    
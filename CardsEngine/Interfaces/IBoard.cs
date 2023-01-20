namespace CardsEngine;

public interface IBoard{
    void Update();    
    IEnumerable<IMonsterCard> Player1Cards{get;}
    IEnumerable<IMonsterCard> Player2Cards{get;}
    int NextCard();
    void AddNewCard(string s,int ty,string txt);

    IMonsterCard GetCard(int pos);
}    
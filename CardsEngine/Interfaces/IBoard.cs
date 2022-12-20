namespace CardsEngine;

public interface IBoard{
    void Update();    
    IEnumerable<IMonsterCard> Player1Cards{get;}
    IEnumerable<IMonsterCard> Player2Cards{get;}
    IMonsterCard NextCard();
    void AddNewCard(string s,int da,int h,int de,int ty);
}    
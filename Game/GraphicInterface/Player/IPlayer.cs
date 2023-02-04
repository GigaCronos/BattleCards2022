public interface IPlayer
{
    int PlayerNumber{get;}
    bool ChooseSlot();
    void AddCards();
    void NextTurn(int pos);
}
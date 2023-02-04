public interface ICatalog{
    void AddCard(string Name,string Info,string Script);
    string GetInfo(string Name);
    IMonsterCard GetCard(string Name);
    IEnumerable<string> GetCards();
    string this[int index]{get;}
    int Count{get;}
    bool IsValid(string s);
}

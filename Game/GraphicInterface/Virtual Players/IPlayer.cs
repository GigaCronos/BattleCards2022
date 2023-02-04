
public interface IPlayer{
    int ChooseSlot(IEnumerable<string> Slots);
    int ChooseCards(IEnumerable<string> Cards);

    int Actions(IEnumerable<string> actions);
    int SelectTarget(IEnumerable<string> Cards,string action);
}
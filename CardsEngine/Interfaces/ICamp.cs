using System.Collections;
using System.Collections.Generic;
namespace CardsEngine;

public interface ICamp:IEnumerable<IMonsterCard>
{
    void Destroy();
    IMonsterCard this[int index]{get;}
    int AddCard(IMonsterCard C);
    void Update();
    bool Empty();
}
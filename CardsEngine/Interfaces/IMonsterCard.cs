using CardsEngine;
using Extensors;
public interface IMonsterCard{
    
    bool DealDamage(int D);

    string Name{get;}
    
    Properties Stats{get;}
}
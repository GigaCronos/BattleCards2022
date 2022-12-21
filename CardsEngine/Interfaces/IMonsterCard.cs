using CardsEngine;

public interface IMonsterCard{
    
    bool DealDamage(int D);

    string Name{get;}
    int Health{get;}
    int Damage{get;}
    int Speed{get;}
    int Player{get;}
    int Defense{get;}
}
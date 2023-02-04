using CardsEngine;
public interface IMonsterCard:ICloneable{
    int Health{get;}
    int Defense{get;}
    int Damage{get;}
    int Speed{get;}
    int Mana{get;}
    string Name{get;}
    string Info{get;}
    bool Validate();
    int Handle(string action,params int[] L);
    int Perform(string action,params int[] L);
    List<string> Actions();
    void TriggerPassive();
}
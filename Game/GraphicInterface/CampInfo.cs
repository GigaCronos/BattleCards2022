public partial class GInterface{
     public string CampInfo(){
        string R="";
        R+="Current Board: \n";
        R+="Player1\n";
        foreach(var a in Tablero.PlayerCards(1)){
            if(a==null){
                R+="[Empty]\n";
                continue;
            }
            R+=a.Name;
            R+="// Health:";R+=a.Health;
            R+=" Damage:";R+=a.Damage;
            R+=" Armor:";R+=a.Defense;
            R+="\n";
        }
        R+="\n";
        R+="Player2\n";
        foreach(var a in Tablero.PlayerCards(2)){
            if(a==null){
                R+="[Empty]\n";
                continue;
            }
            R+=a.Name;
            R+="// Health:";R+=a.Health;
            R+=" Mana: ";R+=a.Mana;
            R+=" Damage:";R+=a.Damage;
            R+=" Armor: ";R+=a.Defense;
            R+=" Speed ";R+=a.Speed;
            R+="\n";
        }
        return R;
    }

}
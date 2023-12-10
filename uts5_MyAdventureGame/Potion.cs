namespace uts5_MyAdventureGame;

class Potion
{
    public int Rage{get;set;}
    public int Heal{get;set;}
    public int RageEffect{get;set;}

    public Potion(int rage, int heal){
        Rage = rage;
        Heal = heal;
        RageEffect = 0;
    }

    public void Healing(Player player){
        Heal -= 1;
        player.Health += 50;
        if(player.Health > player.BaseHealth){
            player.Health = player.BaseHealth;
        }
    }

    public void Raging(){
        Rage -= 1;
        RageEffect += 2;
    }
}
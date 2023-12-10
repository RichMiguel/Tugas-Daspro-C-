namespace uts5_MyAdventureGame;

class Mage : Player
{
    public int BurnEffect{get;set;}

    public Mage(){
        BaseHealth = 180;
        Health = BaseHealth;
        Exp = 0.0f;
        BurnEffect = 0;
        Energy = 50 + Convert.ToInt32(Exp*50);
    }

    public override int Damage(){
        Random rng = new Random();
        int damage = rng.Next(10, 21);
        return damage + Convert.ToInt32(Exp*damage);
    }

    public override void Skill(Enemy enemy){
        if(Energy >= 10){
            Energy -= 10;
            enemy.StunEffect += 1;
            Console.WriteLine("FROST SHOCKK!!");
            enemy.GetHit(30 + Convert.ToInt32(Exp*10));
        }else{
            Console.WriteLine("You don't have any more Energy");
            Defend();
        }
    }

    public override void Ultimate(Enemy enemy){
        if(Energy >= 25){
            Energy -= 25;
            enemy.BurnEffect += 3;
            Console.WriteLine("BURST FIREBALL!!");
            enemy.GetHit(40 + Convert.ToInt32(Exp*20));
        }else{
            Console.WriteLine("You don't have any more Energy");
            Defend();
        }
    }

    public override void Defend(){
        Console.WriteLine($"{Name} Defending...");
        Console.WriteLine("Energy +40");
        Energy += 40;
        if(Energy > 50){
            Energy = 50;
        }
    }
}
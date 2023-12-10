using System;
namespace uts5_MyAdventureGame;

class Swordsman : Player
{
    public Swordsman(){
        BaseHealth = 250;
        Health = BaseHealth;
        Energy = 30;
        Exp = 0.0f;
    }

    public override int Damage(){
        Random rng = new Random();
        int damage = rng.Next(10, 21);
        return damage + Convert.ToInt32(Exp*damage);
    }

    public override void Skill(Enemy enemy){
        if(enemy.StunEffect == 0 && Energy > 0){
            Energy -= 10;
            enemy.StunEffect += 2;
            Console.WriteLine();
            Console.WriteLine("IMPERIAL STRIKEE!!");
            Console.WriteLine($"{enemy.Name} Stunned for 2 turns");
        }else if(enemy.StunEffect > 0 && Energy > 0){
            Console.WriteLine();
            Console.WriteLine("You Cant Use Skill");
            enemy.StunEffect += 1;
        }else if(Energy == 0){
            Console.WriteLine();
            Console.WriteLine("You don't have any more Energy");
            Defend();
        }
    }

    public override void Ultimate(Enemy enemy){
        int damage = 30 + Convert.ToInt32(Exp*30);
        if(Energy >= 20){
            Energy -= 20;
            Console.WriteLine("FORCE SWINGG!!");
            Console.WriteLine($"You get Lifesteal, Health +{Convert.ToInt32(0.4*damage)}");
            enemy.GetHit(damage);
            Health += Convert.ToInt32(0.5*damage);
        }else{
            Console.WriteLine();
            Console.WriteLine("You don't have any more Energy");
            Defend();
        }
    }

    public override void Defend(){
        Console.WriteLine($"{Name} Defending...");
        Console.WriteLine("Energy +30");
        Energy += 30;
        if(Energy > 30){
            Energy = 30;
        }
    }
}
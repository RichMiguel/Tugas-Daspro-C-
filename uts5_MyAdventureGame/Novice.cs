namespace uts5_MyAdventureGame;

class Novice : Player
{
    public Novice(){
        BaseHealth = 100;
        Health = BaseHealth;
        Energy = 20;
    }

    public override int Damage(){
        Random rng = new Random();
        int damage = rng.Next(10, 21);
        return damage;
    }

    public override void Skill(Enemy enemy){
        if(Energy > 0){
            Energy -= 10;
            Console.WriteLine("SLASHH!!!");
            enemy.GetHit(2*AttackPower);
        }else{
            Console.WriteLine("\nYou don't have any more Energy");
            Defend();
        }
        
    }

    public override void Ultimate(Enemy enemy){
        Console.WriteLine("Novice tidak memiliki Ultimate");
    }

    public override void Defend(){
        Console.WriteLine($"{Name} Defending...");
        Console.WriteLine("Energy +20");
        Energy += 20;
        if(Energy > 20){
            Energy = 20;
        }
    }
}
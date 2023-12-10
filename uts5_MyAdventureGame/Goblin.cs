namespace uts5_MyAdventureGame;

class Goblin : Enemy
{
    public Goblin(){
        Name = "Goblin";
        Health = 120;
        IsDead = false;
    }

    public override int Damage(){
        Random rng = new Random();
        int damage = rng.Next(5, 16);
        return damage;
    }
    public override void Skill(Player player){
        Console.WriteLine("STEAL ENERGY...");
        Console.WriteLine($"{player.Name} energy has been stolen");
        player.Energy -= Convert.ToInt32(player.Energy);
    }

    public override void GetHit(int hit){
        Console.WriteLine($"{Name} get hit by {hit}");
        Health -= hit;

        if(Health <= 0){
            Health = 0;
            Die();
        }
    }

    public override void Die(){
        Console.WriteLine($"{Name} is Dead");
        IsDead = true;
    }
}
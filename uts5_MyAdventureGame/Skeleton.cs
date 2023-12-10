namespace uts5_MyAdventureGame;

class Skeleton : Enemy
{
    public Skeleton(){
        Name = "Skeleton";
        Health = 100;
        IsDead = false;
    }

    public override int Damage(){
        Random rng = new Random();
        int damage = rng.Next(5, 11);
        return damage;
    }
    public override void Skill(Player player){
        Console.WriteLine("BONE SLASHH!!...");
        player.GetHit(AttackPower+7);
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
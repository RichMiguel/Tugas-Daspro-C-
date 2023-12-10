namespace uts5_MyAdventureGame;

class Witch : Enemy
{
    public Witch(){
        Name = "Witch";
        Health = 120;
        IsDead = false;
    }

    public override int Damage(){
        Random rng = new Random();
        int damage = rng.Next(5, 16);
        return damage;
    }
    public override void Skill(Player player){
        Console.WriteLine("POISONOUS SMOKEE!!...");
        player.GetHit(Convert.ToInt32(1.5*Damage()));
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
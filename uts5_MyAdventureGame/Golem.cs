namespace uts5_MyAdventureGame;

class Golem : Enemy
{
    public Golem(){
        Name = "Golem";
        Health = 200;
        IsDead = false;
    }

    public override int Damage(){
        Random rng = new Random();
        int damage = rng.Next(5, 16);
        return damage;
    }
    public override void Skill(Player player){
        Console.WriteLine("MOLTEN PUNCHH!!...");
        player.GetHit(Convert.ToInt32(2*Damage()));
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
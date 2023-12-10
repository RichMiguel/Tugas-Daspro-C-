namespace uts5_MyAdventureGame;

class Vampire : Enemy
{
    public Vampire(){
        Name = "Vampire";
        Health = 150;
        IsDead = false;
    }

    public override int Damage(){
        Random rng = new Random();
        int damage = rng.Next(10, 16);
        return damage;
    }
    public override void Skill(Player player){
        Console.WriteLine("BLOODY VAMPP!!...");
        Health += Convert.ToInt32(0.15*player.Health);

        Console.WriteLine($"{Name} Health +{Convert.ToInt32(0.15*player.Health)}");
        player.GetHit(Convert.ToInt32(0.15*player.Health));
        
        if(Health > 150){
            Health = 150;
        }
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
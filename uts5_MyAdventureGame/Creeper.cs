namespace uts5_MyAdventureGame;

class Creeper : Enemy
{
    public Creeper(){
        Name = "Creeper";
        Health = 100;
        IsDead = false;
    }

    public override int Damage(){
        Random rng = new Random();
        int damage = rng.Next(10, 21);
        return damage;
    }
    public override void Skill(Player player){
        Console.WriteLine("BRUTALL BITE!!...");
        player.GetHit(Convert.ToInt32(0.1*player.BaseHealth));
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
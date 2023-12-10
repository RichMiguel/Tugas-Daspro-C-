namespace uts5_MyAdventureGame;

class Ogre : Enemy
{
    public Ogre(){
        Name = "Ogre";
        Health = 150;
        IsDead = false;
    }

    public override int Damage(){
        Random rng = new Random();
        int damage = rng.Next(10, 16);
        return damage;
    }
    public override void Skill(Player player){
        Console.WriteLine("LETHAL COUNTER!!...");
        player.GetHit(Convert.ToInt32(0.2*player.Health));
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
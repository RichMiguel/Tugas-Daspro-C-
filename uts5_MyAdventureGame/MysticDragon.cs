namespace uts5_MyAdventureGame;

class MysticDragon : Enemy
{
    public int Energy{get;set;}
    public MysticDragon(){
        Name = "Mystic Dragon";
        Health = 500;
        Energy = 20;
        IsDead = false;
        IsBoss = true;
    }

    public override int Damage(){
        Random rng = new Random();
        int damage = rng.Next(15, 26);
        return damage;
    }
    public override void Skill(Player player){
        Console.WriteLine("FLAME BURST!!...");
        player.GetHit(Convert.ToInt32(1.5*Damage()));
    }

    public override void Ultimate(Player player){
        if(Energy > 0){
            Console.WriteLine("DRAGONS THOW!!...");
            player.StunEffect += 1;
            player.GetHit(20);
        }else{
            Console.WriteLine($"{Name} recovery Energy, the area becomes hot");
            player.GetHit(5);
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
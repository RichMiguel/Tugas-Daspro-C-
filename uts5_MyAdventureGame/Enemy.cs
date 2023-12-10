namespace uts5_MyAdventureGame;

class Enemy
{
    public int Health { get; set; }
    public string? Name { get; set; }
    public int AttackPower { get; set; }
    public bool IsDead { get; set; }
    public bool IsBoss{get;set;}
    public int StunEffect{get;set;}
    public int BurnEffect{get;set;}

    public Enemy(){
        Health = 100;
        IsDead = false;
        IsBoss = false;
    }

    public virtual string Status(){
        return Name + " | HP " + Health;
    }

    public virtual int Damage(){return 0;}
    public virtual void Skill(Player player){}
    public virtual void Ultimate(Player player){}
    
    public virtual void GetHit(int hit){
        Console.WriteLine($"{Name} get hit by {hit}");
        Health -= hit;

        if(Health <= 0){
            Health = 0;
            Die();
        }
    }

    public virtual void Die(){
        Console.WriteLine($"{Name} is Dead");
        BurnEffect = 0;
        StunEffect = 0;
        IsDead = true;
    }
}
namespace uts5_MyAdventureGame;

class Player
{
    public string? Name{get;set;}
    public int BaseHealth{get;set;}
    public int Health{get;set;}
    public int Energy{get;set;}
    public int AttackPower{get;set;}
    public int AddAttackPower{get;set;}
    public float Exp {get;set;}
    public bool IsDead {get;set;}
    public bool IsRunningAway {get;set;}
    public int StunEffect{get;set;}

    public Player(){
        BaseHealth = 100;
        Health = BaseHealth;
        Energy = 0;
        Exp = 0.0f;
        IsDead = false;
        IsRunningAway = false;
        StunEffect = 0;
    }

    public string Status(){
        return Name + " | HP : " + Health + " | Energy : " + Energy + " | Exp :" + Exp;
    }

    public virtual int Damage(){return 0;}
    public virtual void Skill(Enemy enemy){}
    public virtual void Ultimate(Enemy enemy){}
    public virtual void Defend(){}

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
        IsDead = true;
    }
}
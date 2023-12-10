using System.Net;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace uts4;

class Program
{
    static bool gameOver = false;
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Welcome to My RPG GAME!!\n");
        Console.WriteLine("What is your name, Warrior?");
        Console.Write("Name : ");
        string? playerName = Console.ReadLine();

        Console.WriteLine($"\nAlright {playerName}, now you will fight to defeat the monsters.");
        Console.WriteLine("Are you ready?");
        Console.Write("Choose [y/n] : ");
        string? input = Console.ReadLine();

        Potion potion = new Potion(5, 5);
        Warrior player = new Warrior(playerName, 200);
        Enemy enemy1 = new Enemy("Green Goblin", 50);
        Enemy enemy2 = new Enemy("Pebble Golem", 80);
        Enemy enemy3 = new Enemy("Raging Blaze", 120);
        Boss boss = new Boss("Gorgar the Ghoul King", 1000);
        if(input == "y"){
            while(!player.IsDead && !gameOver)
            {
                Console.Clear();
                Console.WriteLine("-----------------------------------");
                Console.WriteLine(enemy1.Name + " Attacking You!!");
                Console.WriteLine(player.Status());
                while(!enemy1.IsDead && !gameOver && !player.IsDead){
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine();
                    PlayerAction(player, enemy1, potion);
                    EnemyAction(player, enemy1, 5, 11);
                    Console.WriteLine();
                    Console.WriteLine(player.Status());
                    Console.WriteLine(enemy1.Status());
                }

                Console.Clear();
                Console.WriteLine("-----------------------------------");
                Console.WriteLine(enemy2.Name + " Attacking You!!");
                Console.WriteLine(player.Status());
                while(!enemy2.IsDead && !gameOver && !player.IsDead){
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine();
                    PlayerAction(player, enemy2, potion);
                    EnemyAction(player, enemy2, 8, 16);
                    Console.WriteLine();
                    Console.WriteLine(player.Status());
                    Console.WriteLine(enemy2.Status());
                }

                Console.Clear();
                Console.WriteLine("-----------------------------------");
                Console.WriteLine(enemy3.Name + " Attacking You!!");
                Console.WriteLine(player.Status());
                while(!enemy3.IsDead && !gameOver && !player.IsDead){
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine();
                    PlayerAction(player, enemy3, potion);
                    EnemyAction(player, enemy3, 10, 21);
                    Console.WriteLine();
                    Console.WriteLine(player.Status());
                    Console.WriteLine(enemy3.Status());
                }

                Console.Clear();
                Console.WriteLine("-----------------------------------");
                Console.WriteLine(boss.Name + " Attacking You!!");
                Console.WriteLine(player.Status());
                while(!boss.IsDead && !gameOver && !player.IsDead){
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine();
                    PlayerActionToBoss(player, boss, potion);
                    BossAction(player, boss);
                    Console.WriteLine();
                    Console.WriteLine(player.Status());
                    Console.WriteLine(boss.Status());
                }
                Console.Clear();
                gameOver = true;
            }
        }else{
            Console.WriteLine("\nYou Are A Loser!!\n");
        }
    }

    static void PlayerAction(Warrior player, Enemy enemy, Potion potion){
        Random rng = new Random();
        player.AttackPower = rng.Next(10,21) + player.Exp*10;
        int userInput = ReadInput();
        if(userInput == 1){
            if(potion.RageEffect > 0){
                Console.WriteLine();
                Console.WriteLine("FULL POWEERRR!!!!");
                enemy.GetHit(player.AttackPower + 50);
                potion.RageEffect -= 1;
            }else{
                Console.WriteLine();
                if(player.AttackPower > 15 + player.Exp*10){
                Console.WriteLine("CRITICAL DAMAGEE!!");
                }
                enemy.GetHit(player.AttackPower);
            }
        }else if(userInput == 2){
            player.SkillBash();
        }else if(userInput == 3){
            player.Rest();
        }else if(userInput == 4){
            UsePotion(player, potion);
        }else if(userInput == 5){
            Console.Clear();
            Console.WriteLine(player.Name+" running away...");
            Console.WriteLine("GAME OVER!!!");
            gameOver = true;
            Console.Write("\nPress ENTER");
            Console.ReadLine();
        }else{
            Console.WriteLine("Input not valid");
        }
    }

    static void EnemyAction(Warrior player, Enemy enemy, int min, int max){
        Random rng = new Random();
        enemy.AttackPower = rng.Next(min,max);
        if(player.StunEffect > 0){
            Console.WriteLine(enemy.Name+" cant turn.."+"("+player.StunEffect+")");
            player.StunEffect -= 1;
        }else{
            if(!enemy.IsDead){
                player.GetHit(enemy.AttackPower);
            }else{
                Console.WriteLine(player.Name + " win this FIGHT");
                player.Exp += 1;
                Console.ReadLine();
            }
        }
    }

    static void PlayerActionToBoss(Warrior player, Boss boss, Potion potion){
        Random rng = new Random();
        player.AttackPower = rng.Next(10,21) + player.Exp*10;
        int userInput = ReadInput();
        if(userInput == 1){
            if(potion.RageEffect > 0){
                Console.WriteLine();
                Console.WriteLine("FULL POWEERRR!!!!");
                boss.GetHit(player.AttackPower + 50);
                potion.RageEffect -= 1;
            }else{
                Console.WriteLine();
                if(player.AttackPower > 15 + player.Exp*10){
                Console.WriteLine("CRITICAL DAMAGEE!!");
                }
                boss.GetHit(player.AttackPower);
            }
        }else if(userInput == 2){
            player.SkillBash();
        }else if(userInput == 3){
            player.Rest();
        }else if(userInput == 4){
            UsePotion(player, potion);
        }else if(userInput == 5){
            Console.Clear();
            Console.WriteLine(player.Name+" running away...");
            Console.WriteLine("GAME OVER!!!");
            gameOver = true;
            Console.Write("\nPress ENTER");
            Console.ReadLine();
        }else{
            Console.WriteLine("Input not valid");
        }
    }

    static void BossAction(Warrior player, Boss boss){
        Random rng = new Random();
        int action = rng.Next(1,3);
        boss.AttackPower = rng.Next(10,21) * 3;
        if(player.StunEffect > 0){
            Console.WriteLine(boss.Name+" cant turn.."+"("+player.StunEffect+")");
            player.StunEffect -= 1;
        }else{
            if(boss.InstantDeathAttack()){
                Console.WriteLine();
                Console.WriteLine("FATALITYY!!!!");
                Console.WriteLine($"{boss.Name} attacks {player.Name} with Ultimate");
                player.Die();
            }else{
                if(action == 1){
                    player.GetHit(boss.AttackPower);
                }else if(action == 2){
                    Console.WriteLine($"{boss.Name} use Special Skill, NECROTIC STRIKEE!!");
                    boss.NecroticStrike(player);
                }else{
                    Console.WriteLine("Error");
                }
            }
        }
    }

    static int ReadInput(){
        try{
            Console.WriteLine("Choose Action :\n1.Normal Attack\n2.Imperial Strike(STUN)\n3.Rest\n4.Use Potion\n5.Run");
            Console.Write("Input : ");
            int input = Convert.ToInt32(Console.ReadLine());
            if(input > 0 && input <= 5){
                return input;
            }else{
                Console.WriteLine("Input not valid");
                return ReadInput();
            }
        }catch(FormatException ex1){
            Console.WriteLine($"Error : {ex1.Message}");
            return ReadInput();
        }catch(Exception ex2){
            Console.WriteLine($"Error : {ex2.Message}");
            return ReadInput(); 
        }
    }

    static void UsePotion(Warrior player, Potion potion){
        Console.WriteLine();
        Console.WriteLine($"Choose Potion:\n1.Rage Potion ({potion.Rage})\n2.Heal Potion ({potion.Heal})");
        Console.Write("Input : ");
        string? userInput = Console.ReadLine();
        if(userInput == "1"){
            if(potion.Rage > 0){
                Console.WriteLine($"\n{player.Name} use Rage Potion, +50 Attack Power");
                potion.Raging();
            }else{
                Console.WriteLine("\nYou don't have any more Rage Potion\n");
                ReadInput();
            }  
        }else if(userInput == "2"){
            if(potion.Heal > 0){
                Console.WriteLine($"\n{player.Name} use Heal Potion, +50 Health");
                potion.Healing(player);
            }else{
                Console.WriteLine("\nYou don't have any more Rage Potion\n");
                ReadInput();
            }
       }else{
            Console.WriteLine("Error");
        }
    }
}



class Warrior
{
    public string Name{get;set;}
    public int Health{get;set;}
    public int StaticHealth{get;set;}
    public int AttackPower{get;set;}
    public int Energy{get;set;}
    public bool IsDead{get;set;}
    public int Exp{get;set;}
    public int StunEffect{get;set;}

    public Warrior(string name, int health){
        Name = name;
        Health = health;
        StaticHealth = health;
        Energy = 40;
        IsDead = false;
        Exp = 0;
        StunEffect = 0;
    }
    public string Status(){
        return Name + " | HP " + Health + " | Energy " + Energy;
    }
    public void SkillBash(){
        if(StunEffect == 0 && Energy > 0){
            Energy -= 10;
            StunEffect += 2;
            Console.WriteLine();
            Console.WriteLine("IMPERIAL STRIKEE!!");
            Console.WriteLine("Stunned for 2 turns");
        }else if(StunEffect > 0 && Energy > 0){
            Console.WriteLine();
            Console.WriteLine("You Cant Use Skill");
            StunEffect += 1;
        }else if(Energy == 0){
            Console.WriteLine();
            Console.WriteLine("You don't have any more Energy\nRest... Energy +40");
            Rest();
        }
    }
    public void Rest(){
        Energy += 40;
        if(Energy > 40){
            Energy = 40;
        }
    }
    public void GetHit(int hit){
        Console.WriteLine($"{Name} get hit by {hit}");
        Health -= hit;

        if(Health <= 0){
            Health = 0;
            Die();
        }
    }
    public void Die(){
        Console.WriteLine($"\n{Name} is Dead");
        Console.WriteLine("GAME OVER!!!\n");
        Console.Write("Press ENTER");
        Console.ReadLine();
        IsDead = true;
    }
}

class Enemy
{
    public string Name{get;set;}
    public int Health{get;set;}
    public int AttackPower{get;set;}
    public bool IsDead{get;set;}
    public int Exp{get;set;}

    public Enemy(string name, int health){
        Name = name;
        Health = health;
        IsDead = false;
        Exp = 0;
    }
    public string Status(){
        return Name + " | HP " + Health;
    }
    public void GetHit(int hit){
        Console.WriteLine($"{Name} get hit by {hit}");
        Health -= hit;

        if(Health <= 0){
                Health = 0;
                Die();
            }
    }
    public void Die(){
        Console.WriteLine($"{Name} is Dead");
        IsDead = true;
    }
}

class Boss
{
    public string Name{get;set;}
    public int Health{get;set;}
    public int AttackPower{get;set;}
    public int Energy{get;set;}
    public bool IsDead{get;set;}
    
    public Boss(string name, int health){
        Name = name;
        Health = health;
        Energy = 20;
        IsDead = false;
    }

    public string Status(){
        return Name + " | HP " + Health + " | Energy " + Energy;
    }

    public void GetHit(int hit){
        Console.WriteLine($"{Name} get hit by {hit}");
        Health -= hit;

        if(Health <= 0){
                Health = 0;
                Die();
            }
    }

    public void NecroticStrike(Warrior player){
        int hit = Convert.ToInt32(0.33*player.Health);
        player.GetHit(hit);
    }

    public bool InstantDeathAttack(){
        Random rng = new Random();
        double chance = rng.NextDouble();
        if(chance <= 0.05)return true;
        else return false;
    }

    public void Die(){
        Console.WriteLine($"{Name} is Dead");
        IsDead = true;
    }
}

class Potion
{
    public int Rage{get;set;}
    public int Heal{get;set;}
    public int RageEffect{get;set;}

    public Potion(int rage, int heal){
        Rage = rage;
        Heal = heal;
        RageEffect = 0;
    }

    public void Healing(Warrior player){
        Heal -= 1;
        player.Health += 50;
        if(player.Health > player.StaticHealth){
            player.Health = player.StaticHealth;
        }
    }

    public void Raging(){
        Rage -= 1;
        RageEffect += 2;
    }
}

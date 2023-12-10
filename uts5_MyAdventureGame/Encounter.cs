using System.Runtime.CompilerServices;

namespace uts5_MyAdventureGame;

class Action
{
    public int Role{get;set;}

    //Default Encounter
    public void Encounter(Player player, Enemy enemy, Potion potion){
        player.IsRunningAway = false;
        Console.Clear();
        Console.WriteLine($"{enemy.Name} menghadang Anda!!, apakah anda ingin melawannya?");
        Console.Write("Pilih [y/n] : ");
        string? input = Console.ReadLine();

        if(input == "y"){
            while(!enemy.IsDead && !player.IsDead && !player.IsRunningAway){
                Console.WriteLine("--------------------------------------");
                Console.WriteLine(player.Status());
                Console.WriteLine(enemy.Status());
                Console.WriteLine();
                PlayerAction(player, enemy, potion);
                EnemyAction(player, enemy);
            }
        }else{
            Console.WriteLine("Anda Menghindari pertarungan...");
            player.IsRunningAway = true;
        }
    }


    public void PlayerAction(Player player, Enemy enemy, Potion potion){
        ActionChoiceText(Role);
        player.AttackPower = player.Damage();
        if(player.StunEffect > 0){
            Console.WriteLine($"You are Stunned({player.StunEffect})");
            player.StunEffect -= 1;
        }else{
            if(Role == 0){
            int input = ReadInput(5);
            Console.WriteLine();
            if(input == 1){
                if(potion.RageEffect > 0){
                Console.WriteLine();
                Console.WriteLine("FULL POWEERRR!!!!");
                potion.RageEffect -= 1;
                player.AttackPower += 50;
                }
                enemy.GetHit(player.AttackPower);
            }else if(input == 2){
                player.Skill(enemy);
            }else if(input == 3){
                player.Defend();
            }else if(input == 4){
                UsePotion(player, potion);
            }else if(input == 5){
                Console.WriteLine($"{player.Name} running away...");
                player.IsRunningAway = true;
            }
            }else{
                int input = ReadInput(6);
                Console.WriteLine();
                if(input == 1){
                    if(potion.RageEffect > 0){
                    Console.WriteLine();
                    Console.WriteLine("FULL POWEERRR!!!!");
                    potion.RageEffect -= 1;
                    player.AttackPower += 50;
                    }
                    enemy.GetHit(player.AttackPower + player.AddAttackPower);
                }else if(input == 2){
                    player.Skill(enemy);
                }else if(input == 3){
                    player.Ultimate(enemy);
                }else if(input == 4){
                    player.Defend();
                }else if(input == 5){
                    UsePotion(player, potion);
                }else if(input == 6){
                    Console.WriteLine($"{player.Name} running away...");
                    player.IsRunningAway = true;
                }
            }
        }
    }

    public void EnemyAction(Player player, Enemy enemy){
        Random rng = new Random();

        // Efek Terbakar
        if(enemy.BurnEffect > 0 && !enemy.IsDead){
            enemy.BurnEffect -= 1;
            enemy.Health -= 5 + Convert.ToInt32(player.Exp*10);
            Console.WriteLine($"{enemy.Name} is Burned, get hit by {5 + Convert.ToInt32(player.Exp*10)}");

            if(enemy.Health <= 0){
                enemy.Health = 0;
                enemy.Die();
            }
        }
                
        // Efek Stun
        if(enemy.StunEffect > 0){
            Console.WriteLine($"{enemy.Name} can't turn...({enemy.StunEffect})");
            enemy.StunEffect -= 1;
        }else{
            if(!enemy.IsBoss){
                int action = rng.Next(1,3);
                enemy.AttackPower = enemy.Damage();
                if(!enemy.IsDead){
                    if(action == 1){
                        player.GetHit(enemy.AttackPower);
                    }else if(action == 2){
                        enemy.Skill(player);
                    }
                }else{
                    Console.WriteLine(player.Name + " win this FIGHT\n");
                    player.Exp += 0.2f;
                    player.Health += Convert.ToInt32(0.3*player.BaseHealth);
                    Console.Write("Press ENTER");
                    Console.ReadLine();

                    if(player.Health > player.BaseHealth){
                        player.Health = player.BaseHealth;
                    }
                }
            }else{
                int action = rng.Next(1,4);
                enemy.AttackPower = enemy.Damage();
                if(!enemy.IsDead){
                    if(action == 1){
                        player.GetHit(enemy.AttackPower);
                    }else if(action == 2){
                        enemy.Skill(player);
                    }else if(action == 3){
                        enemy.Ultimate(player);
                    }
                }else{
                    Console.WriteLine(player.Name + " win this FIGHT\n");
                    player.Exp += 1.0f;
                    Console.Write("Press ENTER");
                    Console.ReadLine();
                }
            }
        }
    }

    public int ReadInput(int choiceLimit){
        try{
            Console.Write("Input : ");
            int input = Convert.ToInt32(Console.ReadLine());
            if(input > 0 && input <= choiceLimit){
                return input;
            }else{
                Console.WriteLine("Input not valid");
                return ReadInput(choiceLimit);
            }
        }catch(FormatException ex1){
            Console.WriteLine($"Error : {ex1.Message}");
            return ReadInput(choiceLimit);
        }catch(Exception ex2){
            Console.WriteLine($"Error : {ex2.Message}");
            return ReadInput(choiceLimit); 
        }
    }

    public void UsePotion(Player player, Potion potion){
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
                ActionChoiceText(Role);
                ReadInput(2);
            }  
        }else if(userInput == "2"){
            if(potion.Heal > 0){
                Console.WriteLine($"\n{player.Name} use Heal Potion, +50 Health");
                potion.Healing(player);
            }else{
                Console.WriteLine("\nYou don't have any more Rage Potion\n");
                ActionChoiceText(Role);
                ReadInput(2);
            }
       }else{
            Console.WriteLine("Error");
        }
    }

    public void ActionChoiceText(int role){
        if(role == 0){
            Console.WriteLine("Choose Action :\n1.Normal Attack\n2.Slash\n3.Defend\n4.Use Potion\n5.Run");
        }else if(role == 1){
            Console.WriteLine("Choose Action :\n1.Normal Attack\n2.Imperial Strike\n3.Ultimate\n4.Defend\n5.Use Potion\n6.Run");
        }else if(role == 2){
            Console.WriteLine("Choose Action :\n1.Normal Attack\n2.Moon Arrow\n3.Ultimate\n4.Defend\n5.Use Potion\n6.Run");
        }else if(role == 3){
            Console.WriteLine("Choose Action :\n1.Normal Attack\n2.Frost Shock\n3.Ultimate\n4.Defend\n5.Use Potion\n6.Run");
        }else if(role == 4){
            Console.WriteLine("Choose Action :\n1.Normal Attack\n2.Final Slash\n3.Ultimate\n4.Defend\n5.Use Potion\n6.Run");
        }
    }
}
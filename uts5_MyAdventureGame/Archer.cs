namespace uts5_MyAdventureGame;

class Archer : Player
{

    public Archer(){
        BaseHealth = 180;
        Health = BaseHealth;
        Exp = 0.0f;
        Energy = 30 + Convert.ToInt32(Exp*30);
    }

    public override int Damage(){
        Random rng = new Random();
        int damage = rng.Next(15, 31);
        return damage + Convert.ToInt32(Exp*25);
    }
    public override void Skill(Enemy enemy){
        if(Energy > 0){
            Energy -= 10;
            Console.WriteLine("MOON ARROW!..");
            enemy.GetHit(Convert.ToInt32(0.25*enemy.Health));
        }else{
            Console.WriteLine("You don't have any more Energy");
            Defend();
        }
    }

    public override void Ultimate(Enemy enemy){
        if(Energy > 0){
            Energy -= 20;
            int[] arrow = new int[3];
            Console.WriteLine("TRIPLE ARROW!!..");
            for(int i = 0; i < 3; i++){
                arrow[i] = Damage();
                enemy.Health -= arrow[i];
            }
            Console.WriteLine($"{enemy.Name} get hit by {arrow[0]}, {arrow[1]}, {arrow[2]}");

            if(enemy.Health < 0){
                enemy.Die();
            }
        }else{
            Console.WriteLine("You don't have any more Energy");
            Defend();
        }
    }

    public override void Defend(){
        Console.WriteLine($"{Name} Defending...");
        Console.WriteLine("Energy +30");
        Energy += 30;
        if(Energy > 30){
            Energy = 30;
        }
    }
}
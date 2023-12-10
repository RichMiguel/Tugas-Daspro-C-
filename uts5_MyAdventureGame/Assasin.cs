namespace uts5_MyAdventureGame;

class Assasin : Player
{
    public Assasin(){
        BaseHealth = 180;
        Health = BaseHealth;
        Energy = 30;
        Exp = 0.0f;
    }

    public override int Damage(){
        Random rng = new Random();
        int damage = rng.Next(20, 31);
        return damage + Convert.ToInt32(Exp*20);
    }

    public override void Skill(Enemy enemy){
        if(Energy >= 10){
            Energy -= 10;
            Console.WriteLine("FINAL SLASHH!!");
            enemy.GetHit(Convert.ToInt32(0.35*enemy.Health));
            
            Console.WriteLine($"{Name} health decreased, -10");
            Health -= 10;
        }else{
            Console.WriteLine("You don't have any more Energy");
            Defend();
        }
    }

    public override void Ultimate(Enemy enemy){
        Random rng = new Random();
        int HitNumber = rng.Next(3,6);
        if(Energy >= 20){
            Energy -= 20;
            int[] shadow = new int[HitNumber];
            for(int i = 0; i < shadow.Length; i++){
                shadow[i] = (5 + i*2) + Convert.ToInt32(Exp*10);
                enemy.Health -= shadow[i];
            }
            Console.WriteLine($"{enemy.Name} {UltimateText(HitNumber, shadow)}");

            if(enemy.Health < 0){
                enemy.Die();
            }
        }else{
            Console.WriteLine();
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

    private string UltimateText(int number, int[] array){
        if(number == 3){
            return $"get hit by {array[0]}, {array[1]}, {array[2]}";
        }else if(number == 4){
            return $"get hit by {array[0]}, {array[1]}, {array[2]}, {array[3]}";
        }else{
            return $"get hit by {array[0]}, {array[1]}, {array[2]}, {array[3]}, {array[4]}";
        }
    }
}
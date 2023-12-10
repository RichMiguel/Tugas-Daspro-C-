using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Xsl;

namespace uts5_MyAdventureGame;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Action Act = new Action();
        Story story = new Story();
        Enemy dummy1 = new Dummy();
        Enemy dummy2 = new Dummy();
        Potion potion = new Potion(0, 0);
        Player newPlayer = new Novice();
        
        
        story.Prolog();
        story.Beginning();
        Console.Write("........ : ");
        newPlayer.Name = Console.ReadLine();

        story.Training();
        Act.Encounter(newPlayer, dummy1, potion);
        Act.Encounter(newPlayer, dummy2, potion);
        newPlayer.Exp += 0.6f;

        Console.Clear();
        Console.WriteLine("Hebatt!!..\nAnda telah melewati Training Test\nSaatnya untuk memilih Role anda!!");
        Console.WriteLine("Choose Role : \n1.Swordsman\n2.Archer\n3.Mage\n4.Assasin");
        Console.Write("Input : ");
        int input = Convert.ToInt32(Console.ReadLine());

        if(input == 1){
            Swordsman player = new Swordsman();
            player.Name = newPlayer.Name;
            FightFlow(player, potion, input);
        }else if(input == 2){
            Archer player = new Archer();
            player.Name = newPlayer.Name;
            FightFlow(player, potion, input);
        }else if(input == 3){
            Mage player = new Mage();
            player.Name = newPlayer.Name;
            FightFlow(player, potion, input);
        }else if(input == 4){
            Assasin player = new Assasin();
            player.Name = newPlayer.Name;
            FightFlow(player, potion, input);
        }
    }

    static void FightFlow(Player player, Potion potion, int roleType){
        Action Act = new Action();
        Story story = new Story();
        Treasure box1 = new Treasure();
        Treasure box2 = new Treasure();

        //Fight Flow
        Enemy ogre = new Ogre();
        Enemy witch = new Witch();
        Enemy golem = new Golem();
        Enemy vamp = new Vampire();
        Enemy goblin = new Goblin();
        Enemy creeper = new Creeper();
        Enemy skeleton = new Skeleton();
        Enemy dragon = new MysticDragon();
        
        Act.Role = roleType;
        story.Combat(player);
        
        Console.Clear();
        Console.Write("------------AREA 1------------");Console.ReadLine();
        Act.Encounter(player, creeper, potion );
        Act.Encounter(player, skeleton, potion );
        box1.TreasureBoxCode(player, potion, 0.4f);

        Console.Clear();
        Console.Write("------------AREA 2------------");Console.ReadLine();
        Act.Encounter(player, vamp, potion );
        Act.Encounter(player, ogre, potion );
        Act.Encounter(player, golem, potion );
        box2.TreasureBoxMatrix(player, potion, 1.0f);

        Console.Clear();
        Console.Write("------------AREA 3------------");Console.ReadLine();
        Act.Encounter(player, goblin, potion );
        Act.Encounter(player, witch, potion );

        Console.Clear();
        Console.WriteLine("------------ BOSS ------------");Console.ReadLine();
        Act.Encounter(player, dragon, potion);

        if(dragon.IsDead){
            story.Ending(player);
            Console.ReadLine();
            story.Credit();
        }else{
            Console.WriteLine("Anda Gagal.");
            Console.WriteLine("-GAME OVER-");

            story.Credit();
        }
    }
}

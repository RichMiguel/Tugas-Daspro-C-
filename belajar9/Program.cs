// Richard Miquel Laia

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
namespace belajar9;
[System.Runtime.Versioning.SupportedOSPlatform("windows")]

class Program
{
    static int kiri = 0;
    static int kanan = 1;
    static int atas = 2;
    static int bawah = 3;


    //Pemain 1
    static int skorPemain1 = 0;
    static int arahPemain1 = kanan;
    static int kolomPemain1 = 0;
    static int barisPemain1 = 0;


    //Pemain 2
    static int skorPemain2 = 0;
    static int arahPemain2 = kiri;
    static int kolomPemain2 = 40;
    static int barisPemain2 = 5;

    static int speed;
    static bool[,]? isUsed;
    static int round = 1;
    static void Main(string[] args){
        AturLayarPermainan();
        LayarAwal();

        isUsed = new bool[Console.WindowHeight, Console.WindowWidth];

        while(round <= 5){
            if(Console.KeyAvailable){
                ConsoleKeyInfo key = Console.ReadKey(true);
                UbahGerakanPemain(key);
            }

            GerakanPemain();

            bool pemain1Kalah = CekKalah(barisPemain1, kolomPemain1);
            bool pemain2Kalah = CekKalah(barisPemain2, kolomPemain2);

            if(pemain1Kalah && pemain2Kalah){
                skorPemain1++;
                skorPemain2++;
                Console.Clear();
                Console.WriteLine("PERMAINAN BERAKHIR");
                Console.WriteLine("SERI!!");
                Console.WriteLine($"Skor : {skorPemain1} - {skorPemain2}");
                Console.ReadLine();
                ResetGame();
            }else if(pemain1Kalah){
                skorPemain2++;
                Console.Clear();
                Console.WriteLine("PERMAINAN BERAKHIR");
                Console.WriteLine("Pemain 2 Menang");
                Console.WriteLine($"Skor : {skorPemain1} - {skorPemain2}");
                Console.ReadLine();
                ResetGame();
            }else if(pemain2Kalah){
                skorPemain1++;
                Console.Clear();
                Console.WriteLine("PERMAINAN BERAKHIR");
                Console.WriteLine("Pemain 1 Menang");
                Console.WriteLine($"Skor : {skorPemain1} - {skorPemain2}");
                Console.ReadLine();
                ResetGame();
            }

            isUsed[barisPemain1, kolomPemain1] = true;
            isUsed[barisPemain2, kolomPemain2] = true;

            WriteOnPosition(kolomPemain2, barisPemain2,'*',ConsoleColor.DarkRed);
            WriteOnPosition(kolomPemain1, barisPemain1,'*',ConsoleColor.Cyan);

            Thread.Sleep(speed);
        }
    }

    static void WriteOnPosition(int kolom, int baris, char x,ConsoleColor color){
        Console.ForegroundColor = color;
        Console.SetCursorPosition(kolom, baris);
        Console.Write(x);
    }

    static void ResetGame(){
        round += 1;
        isUsed = new bool[Console.WindowHeight, Console.WindowWidth];
        AturLayarPermainan();
        arahPemain1 = kanan;
        arahPemain2 = kiri;
        Console.WriteLine("Tekan ENTER, untuk Mulai Kembali");
        Console.ReadKey();
        Console.Clear();
        GerakanPemain();
    }

    static bool CekKalah(int baris, int kolom){
        if(baris < 0){return true;}
        if(kolom < 0){return true;}
        if(baris >= Console.WindowHeight){return true;}
        if(kolom >= Console.WindowWidth){return true;}
        if(isUsed[baris, kolom]){
            return true;
        }

        return false;
    }

    static void GerakanPemain(){
        //Pemain 1
        if(arahPemain1 == atas){barisPemain1--;}
        if(arahPemain1 == bawah){barisPemain1++;}
        if(arahPemain1 == kanan){kolomPemain1++;}
        if(arahPemain1 == kiri){kolomPemain1--;}

        //Pemain 2
        if(arahPemain2 == atas){barisPemain2--;}
        if(arahPemain2 == bawah){barisPemain2++;}
        if(arahPemain2 == kanan){kolomPemain2++;}
        if(arahPemain2 == kiri){kolomPemain2--;}
    }

    static void UbahGerakanPemain(ConsoleKeyInfo key){
        //Pemain 1
        if(key.Key == ConsoleKey.W && arahPemain1 != bawah){ 
            arahPemain1 = atas;
        }
        if(key.Key == ConsoleKey.A && arahPemain1 != kanan){ 
            arahPemain1 = kiri;
        }
        if(key.Key == ConsoleKey.S && arahPemain1 != atas){ 
            arahPemain1 = bawah;
        }
        if(key.Key == ConsoleKey.D && arahPemain1 != kiri){ 
            arahPemain1 = kanan;
        }


        //Pemain 2
        if(key.Key == ConsoleKey.UpArrow && arahPemain2 != bawah){ 
            arahPemain2 = atas;
        }
        if(key.Key == ConsoleKey.LeftArrow && arahPemain2 != kanan){ 
            arahPemain2 = kiri;
        }
        if(key.Key == ConsoleKey.DownArrow && arahPemain2 != atas){ 
            arahPemain2 = bawah;
        }
        if(key.Key == ConsoleKey.RightArrow && arahPemain2 != kiri){ 
            arahPemain2 = kanan;
        }
    }

    static void AturLayarPermainan(){
        Console.WindowHeight = 30;
        Console.WindowWidth = 100;

        Console.BufferHeight = 30;
        Console.BufferWidth = 100;

        kolomPemain1 = 0;
        barisPemain1 = Console.WindowHeight/2;

        kolomPemain2 = Console.WindowWidth-1;
        barisPemain2 = Console.WindowHeight/2;
    }

    static void LayarAwal(){
        string heading = "Game TRON";
        Console.CursorLeft = Console.BufferWidth/2 - heading.Length / 2;
        Console.WriteLine(heading);

        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("Kontrol untuk PEMAIN 1 :\nW -> Atas \nA -> Kiri \nS -> Bawah \nD -> Kanan");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("-----------------------------");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Kontrol untuk PEMAIN 2 :");
        Console.WriteLine("Panah Atas -> Atas");
        Console.WriteLine("Panah Bawah -> Bawah");
        Console.WriteLine("Panah Kanan -> Kanan");
        Console.WriteLine("Panah Kiri -> Kiri");

        Console.Write("\nSpeed [1,2,3]: ");
        speed = 100 / Convert.ToInt32(Console.ReadLine());
        Console.Clear();
    }
}

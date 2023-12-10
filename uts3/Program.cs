using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace uts3;

class Program
{
    static void Main(string[] args)
    {
        char[,] Board = new char[5,5]; //Deklarasi Array 2 Dimensi
        int[][] tikus = new int[3][];  //Deklarasi Jagged Array
        int skor = 100;
        bool gameSelesai = false;
        Init(Board);                   //Inisialisasi Papan Permainan                           
        LokasiTikus(tikus);            //Generate Lokasi Tikus
        
        Console.WriteLine("SELAMAT DATANG DI MOUSE-SEARCH-GAME\nTerdapat 3 Tikus yang harus anda Temukan");
        Console.Write("Semoga Beruntung!!!");
        Console.ReadLine();

        while(!gameSelesai){
            Console.Clear();
            TampilkanLokasiTikus(tikus);
            ShowBoard(Board);

            //Input Pemain
            int baris = BacaInput("Baris");
            int kolom = BacaInput("Kolom");

            if(CekTikus(tikus, baris, kolom)){
                Board[baris-1,kolom-1]='$';
            }else{
                Board[baris-1,kolom-1]='X';
                skor -= 4;
            }
            
            /*
                try{
                    Console.Write("Baris (1-5) : ");
                    int baris = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Kolom (1-5) : ");
                    int kolom = Convert.ToInt32(Console.ReadLine());

                    if(CekTikus(tikus, baris, kolom)){
                        Board[baris-1,kolom-1]='$';
                    }else{
                        Board[baris-1,kolom-1]='X';
                    }
                }catch(FormatException ex1){
                    Console.WriteLine($"Error : {ex1.Message}");
                    Console.ReadLine();
                }catch(Exception ex2){
                    Console.WriteLine($"Error : {ex2.Message}");
                    Console.ReadLine();
                }
            */

            //Cek Kondisi Menang
            if(CekMenang(Board, tikus)){
                Console.Clear();
                ShowBoard(Board);
                Console.WriteLine("Permainan Selesai!!");
                Console.WriteLine($"Skor : {skor}");
                gameSelesai = true;
            }
        }
    }

    static void Init(char[,] board){
        for(int i = 0; i < 5; i++){
            for(int j = 0; j < 5; j++){
                board[i,j] = '~';
            }
        }
    }

    static void ShowBoard(char[,] board){
        Console.WriteLine("  | 1 | 2 | 3 | 4 | 5 |");
        for(int i = 0; i < 5; i++){
            Console.Write(i+1 +" | ");
            for(int j = 0; j < 5; j++){
                Console.Write(board[i,j]);
                Console.Write("   ");
            }
            Console.WriteLine();
        }
    }

    static void LokasiTikus(int[][] a){
        Random rng = new Random();
        for(int i = 0; i < 3; i++){
            a[i] = new int[2];
        }

        for(int i =0;i<3;i++){
            for(int j = 0; j < 2;j++){
                a[i][j] = rng.Next(1,6);
            }
        }
    }

    static int BacaInput(string pesan)
    {
        try{
            Console.Write($"{pesan} 1-5 : ");
            int angka = Convert.ToInt32(Console.ReadLine());
            return angka; // Jika berhasil, kembalikan nilai angka.
        }
        catch(FormatException ex1){
            Console.WriteLine($"Error : {ex1.Message}");
            return BacaInput(pesan); // Panggil fungsi lagi untuk meminta input kembali.
        }
        catch(Exception ex2){
            Console.WriteLine($"Error : {ex2.Message}");
            return BacaInput(pesan); // Panggil fungsi lagi untuk meminta input kembali.
        }
    }

    static void TampilkanLokasiTikus(int[][] a){
        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 2; j++) {
                Console.Write(a[i][j] + " ");
            }
            Console.WriteLine();
        }
    }

    static bool CekTikus(int[][] jagged, int a, int b){
        for(int i = 0; i < 3; i++){
            if(jagged[i][0] == a && jagged[i][1] == b)return true;
        }
        return false;
    }

    static bool CekMenang(char[,] board, int[][] jagged){
        if(board[jagged[0][0]-1,jagged[0][1]-1] == '$' && board[jagged[1][0]-1,jagged[1][1]-1] == '$' && board[jagged[2][0]-1,jagged[2][1]-1] == '$')return true;
        return false;
    }
}

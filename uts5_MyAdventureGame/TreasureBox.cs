using System.Configuration.Assemblies;

namespace uts5_MyAdventureGame;

class Treasure
{
    public char[,] Board = new char[4,4]; //Deklarasi Array 2 Dimensi
    public int[][] Key = new int[4][];  //Deklarasi Jagged Array
    public bool IsOpen{get;set;}

    public Treasure(){
        IsOpen = false;
    }

    public void TreasureBoxCode(Player player, Potion potion, float exp){
        IsOpen = false;
        if(player.Exp >= exp){
            Console.Clear();
            Random rng = new Random();
            int[] Code = new int[4];
            int[] TebakanAngka = new int[4];
            string[] CastTebakanAngka = {"_", "_", "_", "_"};
            for(int i = 0; i < Code.Length; i++){
                Code[i] = rng.Next(1, 4);
            }

            Console.WriteLine("Anda menemukan Treasure Box");
            Console.WriteLine("Tebak Serangkaian Kode untuk Membukanya!!!");
            Console.Write("\nPress ENTER");
            Console.ReadLine();
            Console.Clear();
            while(!IsOpen){
                Console.WriteLine("HINT : ");
                Console.WriteLine($"Jika Dikali Hasilnya {Code[0]*Code[1]*Code[2]*Code[3]}");
                Console.WriteLine($"Jika Dijumlah Hasilnya {Code[0]+Code[1]+Code[2]+Code[3]}");
                int input = ReadInput(3);

                for(int i = 0; i < Code.Length; i++){
                    if(input == Code[i] && CastTebakanAngka[i] == "_"){
                        TebakanAngka[i] = input;
                        CastTebakanAngka[i] = Convert.ToString(input);
                    }
                }

                foreach(var element in CastTebakanAngka){
                    Console.Write($" {element} ");
                }
                Console.WriteLine("\n");
                Console.ReadLine();

                if(TebakanAngka[0] == Code[0] &&
                   TebakanAngka[1] == Code[1] &&
                   TebakanAngka[2] == Code[2] &&
                   TebakanAngka[3] == Code[3] ){
                    player.Exp += 0.1f;
                    player.AddAttackPower += 15;
                    IsOpen = true;
                    Console.WriteLine("Anda Berhasil Menebaknya!!");
                    Console.WriteLine($"Anda mendapatkan Senjata Baru, Damage +15\nExp Anda +0.1");
                    Console.Write("\nPress Enter");
                    Console.ReadLine();
                }
            }
        }
    }

    public void TreasureBoxMatrix(Player player, Potion potion, float exp){
        IsOpen = false;
        if(player.Exp >= exp){
            Console.Clear();
            Init(Board);                   //Inisialisasi Papan Permainan                           
            LokasiKey(Key);            //Generate Lokasi Key
            Console.WriteLine("\nAnda menemukan Treasure Box");
            Console.WriteLine("Tebak Lokasi Kunci untuk Membukanya!!!");
            Console.Write("\nPress ENTER");
            Console.ReadLine();
            while(!IsOpen){
                Console.Clear();
                //TampilkanLokasiKey(Key);
                ShowBoard(Board);

                //Input Pemain
                int baris = BacaInput("Baris");
                int kolom = BacaInput("Kolom");

                if(CekKey(Key, baris, kolom)){
                    Board[baris-1,kolom-1]='O';
                }else{
                    Board[baris-1,kolom-1]='~';
                }

                //Cek Kondisi Terbuka
                if(CekMenang(Board, Key)){
                    Console.Clear();
                    ShowBoard(Board);
                    potion.Rage += 3;
                    potion.Heal += 3;
                    player.Exp += 0.1f;
                    IsOpen = true;
                    Console.WriteLine("Treasure Box terpecahkan...");
                    Console.WriteLine("Anda mendapat Rage Potion dan Heal Potion!!\nExp Anda +0.1");
                    Console.Write("\nPress Enter");
                    Console.ReadLine();
                }
            }
        }
    }

    public void Init(char[,] board){
        for(int i = 0; i < 4; i++){
            for(int j = 0; j < 4; j++){
                board[i,j] = ' ';
            }
        }
    }

    private void ShowBoard(char[,] board){
        Console.WriteLine("  | 1 | 2 | 3 | 4 |");
        for(int i = 0; i < 4; i++){
            Console.Write(i+1 +" | ");
            for(int j = 0; j < 4; j++){
                Console.Write(board[i,j]);
                Console.Write("   ");
            }
            Console.WriteLine();
        }
    }

    private void LokasiKey(int[][] a){
        Random rng = new Random();
        for(int i = 0; i < 4; i++){
            a[i] = new int[2];
        }

        for(int i =0;i<4;i++){
            for(int j = 0; j < 2;j++){
                a[i][j] = rng.Next(1,5);
            }
        }
    }

    private int BacaInput(string pesan)
    {
        try{
            Console.Write($"{pesan} 1-4 : ");
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

    private void TampilkanLokasiKey(int[][] a){
        for (int i = 0; i < 4; i++) {
            for (int j = 0; j < 2; j++) {
                Console.Write(a[i][j] + " ");
            }
            Console.WriteLine();
        }
    }

    private bool CekKey(int[][] jagged, int a, int b){
        for(int i = 0; i < 4; i++){
            if(jagged[i][0] == a && jagged[i][1] == b)return true;
        }
        return false;
    }

    private bool CekMenang(char[,] board, int[][] jagged){
        if(board[jagged[0][0]-1,jagged[0][1]-1] == 'O' && 
           board[jagged[1][0]-1,jagged[1][1]-1] == 'O' && 
           board[jagged[2][0]-1,jagged[2][1]-1] == 'O' && 
           board[jagged[3][0]-1,jagged[3][1]-1] == 'O')return true;
        return false;
    }

    private int ReadInput(int choiceLimit){
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
}
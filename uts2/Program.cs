using System.Reflection;
using System.Reflection.Metadata;

namespace uts2;

class Program
{
    /*
    HANGMAN GAMES
       ________
       |      |
       |     (_)
       |     /|\     
       |     / \
       |      
    ___|___
    */


    //Array untuk elemen render Hangman
    static string[] hangman = {
    @"       ________
       |      |
       |     (_)
       |     /|\
       |     / \
       |      
    ___|___", 
    @"       ________
       |      |
       |     (_)
       |     /|\
       |     / 
       |      
    ___|___",
    @"       ________
       |      |
       |     (_)
       |     /|\
       |     
       |      
    ___|___",
    @"       ________
       |      |
       |     (_)
       |     /|
       |     
       |      
    ___|___",
    @"       ________
       |      |
       |     (_)
       |      |
       |     
       |      
    ___|___",
    @"       ________
       |      |
       |     (_)
       |      
       |     
       |      
    ___|___",
    @"       ________
       |      |
       |
       |
       |
       |
    ___|___",
    @"       ________
       |
       |
       |
       |
       |
    ___|___",
    @"
       |
       |
       |
       |
       |
    ___|___",
    @"
       
       
       
       
       
    _______",
    @"
       
       
       
       
       
           "};
    
    static string[] prodiFakultasTeknik = {"informatika","arsitektur", "sipil", "elektro", "mesin", "kimia", "lingkungan"}; 
    static int kesempatan = 10;
    static string playerInput;
    static string kataRahasia = prodiFakultasTeknik[randomGenerator()];
    static int randomGenerator(){
        Random rng = new Random();
        int nomor = rng.Next(0, 5);
        return nomor;
    }

    //Fungsi yang bertugas sebagai pembukaan/intro Games
    static void Intro(){
        Console.WriteLine( "Selamat Datang di HANGMAN GAMES!!");
        Console.WriteLine($"Anda memiliki {kesempatan} kesempatan");
        Console.WriteLine( "Jika anda menebak dengan huruf vokal,\nKesempatan anda akan berkurang");
        Console.WriteLine( "Tebaklah dengan huruf A-Z.");
        Console.WriteLine($"HINT : - Terdiri dari {kataRahasia.Length} huruf");
        Console.WriteLine( "       - Salah satu Jurusan di Fakultas Teknik");
        Console.Write("\nTekan ENTER untuk Mulai!");
        Console.ReadLine();
    }

    static void Start(){
        bool statusPermainan = false;
        string userInputLower;
        char[] hurufTebakan = new char[kataRahasia.Length];
        bool cekHuruf;
        for(int i = 0; i < kataRahasia.Length; i++){
            hurufTebakan[i] = '_';
            Console.Write($" {hurufTebakan[i]} ");
        }

        Console.WriteLine(" ");
        while(kesempatan > 0 && statusPermainan == false){
            Console.Clear();
            cekHuruf = false;
            
            Console.Write("Masukkan Tebakan : ");

            //Handler apabila input user tidak sesuai
            try{
                playerInput = Console.ReadLine();

                if (string.IsNullOrEmpty(playerInput)){
                    throw new FormatException("Input tidak boleh kosong.");
                }

                foreach (char c in playerInput){
                    if (!char.IsLetter(c)){
                        throw new FormatException("Input tidak valid. Hanya huruf yang diperbolehkan.");
                    }
                }
            }catch(FormatException ex1){
                Console.WriteLine(ex1.Message);
            }catch(Exception ex2){
                Console.WriteLine(ex2.Message);
            }

            

            userInputLower = playerInput.ToLower();

            char[] charInput = userInputLower.ToCharArray();

            Console.WriteLine(" ");

            //Cek huruf per huruf
            for(int i = 0; i < kataRahasia.Length; i++){
                if(kataRahasia[i] == charInput[0] && hurufTebakan[i] == '_'){
                    hurufTebakan[i] = charInput[0];
                    cekHuruf = true;
                }
            }

            string str = "";
            foreach(var element in hurufTebakan){
                Console.Write($" {element} ");
                str += element;
            }
            
            Console.WriteLine(" ");
            if(cekHuruf){
                if("aiueo".Contains(charInput[0])){
                    kesempatan--;
                    Console.WriteLine("Benar! Namun kesempatan anda dikurangi");
                }else{
                Console.WriteLine("Benar! Silahkan masukkan lagi..");
                }
            }else{
                kesempatan--;
            }

            if(str == kataRahasia && kesempatan > 0){
                statusPermainan = true;
                Console.WriteLine("SELAMAT ANDA BERHASIL MENEBAKNYAA!!");
                Console.WriteLine($"Jawaban : {kataRahasia}");
            }else if(statusPermainan){
                Console.WriteLine("\n    ANDA GAGALL!!");
            }
            Console.WriteLine($"Kesempatan tersisa : {kesempatan}");
            Console.WriteLine(hangman[kesempatan]);

            Console.Write("Tekan ENTER untuk lanjut!");
            Console.ReadLine();

        }
    }
    
    
    static void Main(string[] args)
    {
        Intro();
        Start();
    }
}

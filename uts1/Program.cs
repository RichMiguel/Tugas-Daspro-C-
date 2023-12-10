namespace uts1;

class Program
{
    static void Intro(){
        string teks1;
        string teks2;
        string teks3;
        string teks4;

        teks1 = "Pada game ini anda dan komputer akan bermain 10 ronde.";
        teks2 = "Setiap putaran dadu akan dilempar menghasilkan nilai tertentu.";
        teks3 = "Nilai dadu tertinggi akan menjadi pemenang ronde tersebut";
        teks4 = "Siapa yang akan menang?! Selamat berjuang";
        Console.WriteLine(teks1);
        Console.WriteLine(teks2);
        Console.WriteLine(teks3);
        Console.WriteLine(teks4);
        Console.WriteLine("");
        Console.WriteLine("Mulai main...");
    }
    static void Main(string[] args)
    {
        Random rng = new Random();

        //Deklarasi Variabel
        int nilaiDaduPemain;
        int nilaiDaduKomputer;
        int skorPemain = 0;
        int skorKomputer = 0;
        int totalRonde = 10;
        int ronde = 1;

        //Memanggil fungsi "Intro"
        Intro();
        string inputUser;
        inputUser = Console.ReadLine();

        //Looping sebanyak 10x
        while(totalRonde > 0){
            nilaiDaduPemain = rng.Next(1,7);
            nilaiDaduKomputer = rng.Next(1,7);
            Console.WriteLine("Ronde " + ronde);
            Console.WriteLine("Nilai Komputer : " + nilaiDaduKomputer);
            Console.Write("Lempar dadu anda...");
            inputUser = Console.ReadLine();
            Console.WriteLine("Nilai anda : " + nilaiDaduPemain);
            
            //Penambahan Skor 
            if(nilaiDaduKomputer > nilaiDaduPemain){
                skorKomputer++;
                Console.WriteLine("Komputer memenangkan ronde ini!");
            }
            else if(nilaiDaduKomputer < nilaiDaduPemain){
                skorPemain++;
                Console.WriteLine("Anda memenangkan ronde ini!");
            }
            else{
                skorKomputer = skorKomputer + 0;
                skorPemain   = skorPemain + 0;
                Console.WriteLine("Anda seri dengan komputer pada ronde ini!");
            }

            Console.WriteLine("Skor - Anda : " + skorPemain + " | " + "Komputer : " + skorKomputer );
            Console.WriteLine("");
            ronde++;
            totalRonde--;
        }
        
        Console.WriteLine("Permainan Selesai!!");
        Console.WriteLine("Skor Akhir - Anda : " + skorPemain + " | " + "Komputer : " + skorKomputer );

        //Skor Akhir
        if(skorKomputer > skorPemain){
            Console.WriteLine("Sayang Sekali, Anda kalah!");
        }else if(skorKomputer < skorPemain){
            Console.WriteLine("Selamat, Anda Menang!");
        }else{
            Console.WriteLine("Anda Seri dengan Komputer, silahkan coba lagi..");
        }
        Console.WriteLine("Terima Kasih Sudah Bermain...");
    }
}

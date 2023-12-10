using System.Collections;

namespace belajar4._1;

class Program
{
    string kataRahasia = "informatika"; //Deklarasi Variabel pada Global Scoping

    static void Main(string[] args)
    {
        //Memanggil Fungsi Intro() dan MulaiMain()
        Program program = new Program();
        program.Intro();
        program.MulaiMain();
    }

    //Fungsi Intro()
    void Intro(){
        Console.WriteLine("Selamat Datang dalam Games Tebak Kata Rahasia");
        Console.WriteLine("Tebaklah huruf per huruf!");
        Console.WriteLine("HINT : " + kataRahasia.Length + " Huruf.\nMerupakan salah satu Prodi Universitas Riau");
    }

    //Fungsi MulaiMain();
    void MulaiMain(){
        ArrayList hurufTebakanPemain = new ArrayList();

        int kesempatan = 3;
        string userInput;

        //bool cekJawaban = false;
        //char[] hurufTebakan = (char[])hurufTebakanPemain.ToArray(typeof(char));

        //Menambah elemen ArrayList sebanyak panjangnya variabel "kataRahasia"
        for(int a = 0; a < kataRahasia.Length; a++){
            hurufTebakanPemain.Add('_');
            Console.Write($" {hurufTebakanPemain[a]} ");
        }
        
        Console.WriteLine("");
        while(kesempatan > 0){
            bool cekHuruf = false;
            
            Console.Write("Masukkan Tebakan Anda : ");

            userInput = Console.ReadLine();
            char charInput = char.ToLower(userInput[0]);
        
            //Memeriksa huruf per huruf
            for(int i = 0; i < kataRahasia.Length; i++){
                char castTebakanPemain = (char)hurufTebakanPemain[i];

                if(kataRahasia[i] == charInput && castTebakanPemain == '_'){
                    hurufTebakanPemain[i] = charInput;
                    cekHuruf = true;
                }
            }

            Console.WriteLine("");
            //Menyatukan input user yang benar
            string hasil = "";
            foreach(var element in hurufTebakanPemain){
                Console.Write($" {element} ");
                hasil += element;
            }

            Console.WriteLine("");

            if(cekHuruf){
                Console.WriteLine("Benar!, silahkan menebak lagi...");//apabila variabel "cekHuruf" bernilai true
            }else{
                kesempatan--;
                Console.WriteLine($"Maaf tebakan Anda salah!, kesempatan sisa {kesempatan} lagi..");//apabila variabel "cekHuruf" bernilai false
            }
            
            if(hasil == kataRahasia && kesempatan > 0){
                Console.WriteLine($"Selamat Anda berhasil menebaknya... Kata Rahasia adalah {kataRahasia}");
                Console.WriteLine(" ");
                kesempatan = 0;
            }else if(kesempatan == 0){
                Console.WriteLine("Kesempatan Anda telah habis.. Silahkan coba lagi");
            }
        }
    }
}

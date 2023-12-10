namespace belajar3;

class Program
{
    static void Intro(){
        //Deklarasi Variabel
        string userName;
        string teksBacaan1;
        string teksBacaan2;
        
        //Inisialisasi Variabel
        teksBacaan1 = "Masukkan Nama Anda : ";
        teksBacaan2 = " adalah agen rahasia yang bertugas mendapatkan data dari server.\nAnda diminta memasukkan 3 angka rahasia untuk membuka data server tersebut.";
        
        //Print ke Console atau Terminal
        Console.Write(teksBacaan1);
        userName = Console.ReadLine();
        Console.WriteLine(userName + teksBacaan2);
    }

    static void Main(string[] args)
    {
        //RNG
        Random rng = new Random();

        //Deklarasi Variabel
        int kesempatan = 3;
        int angkaPertama = rng.Next(1,4);
        int angkaKedua   = rng.Next(1,4);
        int angkaKetiga  = rng.Next(1,4);

        //tebakan pemain
        int tebakanPertama, tebakanKedua, tebakanKetiga, hasilTambah, hasilKali;

        //kondisi
        bool tebakanBerhasil, permainanSelesai;
        tebakanBerhasil = false;
        //perhitungan aritmatika
        hasilTambah = angkaPertama + angkaKedua + angkaKetiga;
        hasilKali = angkaPertama * angkaKedua * angkaKetiga;
        
        
        Intro();
        Console.WriteLine("---------------------------------------");
        Console.WriteLine("Hasil penjumlahan dari password adalah " + hasilTambah);
        Console.WriteLine("Hasil perkalian dari password adalah " + hasilKali);
        Console.WriteLine($"Anda mempunyai {kesempatan} Kali kesempatan");

        //user input
        while(kesempatan > 0 && tebakanBerhasil == false){
            kesempatan--;
            Console.WriteLine("Masukkan 3 digit password server : ");
            Console.Write("Input angka pertama : ");
            tebakanPertama = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input angka kedua   : ");
            tebakanKedua = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input angka ketiga  : ");
            tebakanKetiga = Convert.ToInt32(Console.ReadLine());

            //operasi logika
            if(tebakanPertama == angkaPertama && tebakanKedua == angkaKedua && tebakanKetiga == angkaKetiga){
                Console.WriteLine("");
                Console.WriteLine("Selamat, tebakan Anda benar!. \nServer berhasil diretas.");
                tebakanBerhasil = true;
            }
            else{
                Console.WriteLine("Sayang sekali, tebakan anda salah!");
                Console.WriteLine("");
                Console.WriteLine("Kesempatan anda tersisa : " + kesempatan);
            }
        }
        
        if(kesempatan==0 && tebakanBerhasil == false){
            Console.WriteLine("");
            Console.WriteLine("Sayang sekali, tebakan anda salah! **ALARM BERBUNYI**");
            Console.WriteLine($"Kode yang benar adalah {angkaPertama},{angkaKedua},{angkaKetiga}" );
        }
        //Console.WriteLine("Hasil pengurangan adalah " + (angkaPertama - angkaKedua));
        //Console.WriteLine("Hasil pembagian adalah " + (angkaPertama/angkaKedua));
        //Console.WriteLine("Hasil modulus anngkaKetiga oleh angkaPertama adalah " + (angkaKetiga % angkaPertama));
    }
}

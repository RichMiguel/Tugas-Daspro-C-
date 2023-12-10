namespace belajar2;

class Program
{
    static void Main(string[] args)
    {
        //RNG
        Random rng = new Random();

        //Deklarasi Variabel
        string teksBacaan;
        int angkaPertama = rng.Next(1,6);
        int angkaKedua   = rng.Next(1,6);
        int angkaKetiga  = rng.Next(1,6);

        //tebakan pemain
        int tebakanPertama, tebakanKedua, tebakanKetiga, hasilTambah, hasilKali;

        //kondisi
        bool tebakanBerhasil, permainanSelesai;

        //perhitungan aritmatika
        hasilTambah = angkaPertama + angkaKedua + angkaKetiga;
        hasilKali = angkaPertama * angkaKedua * angkaKetiga;
        

        //Inisialisasi Variabel
        teksBacaan= "Anda adalah agen rahasia yang bertugas mendapatkan data dari server.\nAnda diminta memasukkan 3 angka rahasia untuk membuka data server tersebut.";
        
        Console.WriteLine(teksBacaan);
        Console.WriteLine("---------------------------------------");
        Console.WriteLine("Hasil penjumlahan dari password adalah " + hasilTambah);
        Console.WriteLine("Hasil perkalian dari password adalah " + hasilKali);

        //user input
        Console.WriteLine("Masukkan 3 digit password server : ");
        Console.Write("Input angka pertama : ");
        tebakanPertama = Convert.ToInt32(Console.ReadLine());
        Console.Write("Input angka kedua   : ");
        tebakanKedua = Convert.ToInt32(Console.ReadLine());
        Console.Write("Input angka ketiga  : ");
        tebakanKetiga = Convert.ToInt32(Console.ReadLine());

        //operasi logika
        if((tebakanPertama == angkaPertama) && (tebakanKedua == angkaKedua) && (tebakanKetiga == angkaKetiga)){
            Console.WriteLine("Selamat, tebakan Anda benar!. \nServer berhasil diretas.");
        }
        else{
            Console.WriteLine("Sayang sekali, tebakan anda salah! **ALARM BERBUNYI**");
            Console.WriteLine($"Kode yang benar adalah {angkaPertama},{angkaKedua},{angkaKetiga}" );
        }
        //Console.WriteLine("Hasil pengurangan adalah " + (angkaPertama - angkaKedua));
        //Console.WriteLine("Hasil pembagian adalah " + (angkaPertama/angkaKedua));
        //Console.WriteLine("Hasil modulus anngkaKetiga oleh angkaPertama adalah " + (angkaKetiga % angkaPertama));
    }
}

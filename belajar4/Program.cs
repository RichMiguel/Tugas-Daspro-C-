using System.Collections;

namespace belajar4;

class Program
{
    static void Main(string[] args)
    {
        string teks = "  Hello World  ";

        //Array String
        string[] namaSiswa = {"Gideon","Hans","Aqul","Syachrul","Richard"};

        Console.WriteLine("Array");
        for(int i = 0; i < namaSiswa.Length; i++){
            Console.WriteLine("Nama mahasiswa : " + namaSiswa[i]);
        }
        Console.WriteLine("----------------------------");

        //ArrayList
        Console.WriteLine("Arraylist");

        ArrayList namaMahasiswa = new ArrayList();

        //Menambah elemen ArrayList sebanyak 5 
        namaMahasiswa.Add("Ichwan");
        namaMahasiswa.Add("Raissa");
        namaMahasiswa.Add("Jeff");
        namaMahasiswa.Add("Abid");
        namaMahasiswa.Add("Jovany");
        
        foreach(string mahasiswa in namaMahasiswa){
            Console.WriteLine("Nama mahasiswa : " + mahasiswa);
        }

        Console.WriteLine("--------------------------");
        Console.WriteLine("Semester 2");

        //Menambah elemen ArrayList
        namaMahasiswa.Add("Hans");
        namaMahasiswa.Add("Gideon");
        namaMahasiswa.Add("Rizki");

        //Menghapus elemen ArrayList
        namaMahasiswa.Remove("Ichwan");
        namaMahasiswa.Remove("Abid");
        namaMahasiswa.Remove("Jovany");


        foreach(string mahasiswa in namaMahasiswa){
            Console.WriteLine("Nama mahasiswa : " + mahasiswa);
        }

        Console.WriteLine("--------------------------");
        string trimTeks    = teks.Trim();
        bool containTeks   = teks.Contains("Hello");
        int lengthTeks     = teks.Length;
        string replaceTeks = teks.Replace("World", "Friend");

        Console.WriteLine("Fungsi-fungsi string  :");
        Console.WriteLine($"Hasil dari Trim()    : {trimTeks}");
        Console.WriteLine($"Hasil dari Contains(): {containTeks}");
        Console.WriteLine($"Hasil dari Length    : {lengthTeks}");
        Console.WriteLine($"Hasil dari Replace() : {replaceTeks}");

    }
}

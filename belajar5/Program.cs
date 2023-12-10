using System.Threading.Tasks.Dataflow;

namespace belajar5;

class Program
{
    
    static double hasil;
    static double Divide(int[] angka){ //Fungsi membagi indeks[i]/indeks[i+1]
        
        for(int i = 0;i < angka.Length; i++){
            try{
                hasil = angka[i]/angka[i+1];
                Console.WriteLine($"Hasil dari {angka[i]}/{angka[i+1]} = {hasil}");
            }
            catch(DivideByZeroException){
                Console.WriteLine("Tidak dapat dibagi dengan 0");
            }
            catch(IndexOutOfRangeException){
                Console.WriteLine("Index array tidak valid");
            }
            catch(Exception ex){
                Console.WriteLine($"{ex.Message}");
            }
        }
        return hasil;
    }

    static double userDivide(int[] angka, int pembagi){//Fungsi membagi indeks[i] dengan input user
        try{
            for(int i = 0; i < angka.Length; i++){
                double hasil = angka[i]/pembagi;
                Console.WriteLine($"Hasil dari {angka[i]}/{pembagi} = {hasil}");
            }
        }
        catch(DivideByZeroException){
            Console.WriteLine("Tidak dapat dibagi dengan Nol");
        }
        catch(Exception ex){
            Console.WriteLine($"{ex.Message}");
        }
        return hasil;
    }
    static void Main(string[] args)
    {
        int input;
        double hasilBagi, hasilBagiUser;

        //Deklarasi Array
        int[] array = {20, 12, 2, 13, 14, 5, 6, 0, 8, 9};
        hasilBagi = Divide(array);
        Console.WriteLine("----------------------------------");
        Console.WriteLine("Input wajib Angka!!");

        //Handler input user
        try{
        Console.Write("Masukkan Nilai pembagi : ");
        input = Convert.ToInt32(Console.ReadLine());
        hasilBagiUser = userDivide(array, input);
        }
        catch(FormatException){
            Console.WriteLine("Anda hanya bisa memasukkan Angka, Contoh : 5");
        }
        catch(Exception ex){
            Console.WriteLine($"{ex}");
        }
    }
}

namespace belajar6;

class Program
{
    static void Main(string[] args)
    {
        //Inisialisasi dan Deklarasi variabel serta Array 2 dimensi
        char player = 'X';
        bool gameSelesai = false;
        char[,] papan = new char[3,3];
        Init(papan);


        //Looping Permainan
        while(!gameSelesai){
            Console.Clear();
            TampilkanPapan(papan);
            
            try{
                Console.Write("Baris (1-3) : ");
                int baris = Convert.ToInt32(Console.ReadLine()) - 1;
                Console.Write("Kolom (1-3) : ");
                int kolom = Convert.ToInt32(Console.ReadLine()) - 1;

                papan[baris, kolom] = player;
            }catch(Exception ex){
                Console.WriteLine($"Error :{ex.Message}");
            }

            if(CekMenang(papan, player)){
                TampilkanPapan(papan);
                Console.WriteLine(player + " Menang!!, Terima Kasih sudah Bermain");
                Console.Read();
                gameSelesai = true;
            }else if(CekSeri(papan)){
                TampilkanPapan(papan);
                Console.WriteLine("Permainan Seri!!");
                Console.Read();
                gameSelesai = true;
            }

            //Ganti Posisi Player
            player = gantiPemain(player);
        }
        /*
        int[,] matriks1 = new int[3,3]; 
        int[,] matriks2 = new int[3,3];

        for(int i = 0; i < 3; i++){
            for(int j = 0; j < 3 ;j++){
                matriks1[i,j] = i * 3 + j + 1;
                matriks2[i,j] = 10 - j - i*3 - 1;
            }
        }

        for(int i = 0; i < 3; i++){
            for(int j = 0; j < 3 ;j++){
                Console.Write(matriks1[i,j] + "\t");
            }
            Console.WriteLine();
        }

        Console.WriteLine("-----------------------------");
        int[,] hasilMatriks = PenambahanMatriks(matriks1, matriks2);


        for(int i = 0; i < 3; i++){
            for(int j = 0; j < 3 ;j++){
                Console.Write(hasilMatriks[i,j] + "\t");
            }
            Console.WriteLine();
        }
        */
       
    }

    static void Init(char[,] papan){
        for(int baris = 0; baris < 3; baris++){
            for(int kolom = 0; kolom < 3; kolom++){
                papan[baris, kolom] = ' ';
            }
        }
    }

    static void TampilkanPapan(char[,] papan){
        Console.WriteLine("  | 1 | 2 | 3 |");
        for(int i = 0; i < 3;i++){
            Console.Write(i+1 +" | ");
            for(int j = 0; j < 3;j++){
                Console.Write(papan[i,j]);
                Console.Write(" | ");
            }
            Console.WriteLine();
        }
    }

    static bool CekMenang(char[,] papan, char pemain){

        for(int i = 0; i < 3; i++){
            if(papan[i,0]==pemain && papan[i,1]==pemain && papan[i,2]==pemain)return true;
            if(papan[0,i]==pemain && papan[1,i]==pemain && papan[2,1]==pemain)return true;
        }

        if(papan[0,0]==pemain && papan[1,1]==pemain && papan[2,2]==pemain)return true;
        if(papan[0,2]==pemain && papan[1,1]==pemain && papan[2,0]==pemain)return true;
        
        return false;
    }

    static bool CekSeri(char[,] papan){
        for(int i = 0; i <3; i++){
            for(int j = 0; j < 3;j++){
                    if(papan[i,j] == ' ')return false;
            }
        }
        return true;
    }

    static char gantiPemain(char player){
        if(player == 'X'){
            return 'O';
        }else{
            return 'X';
        }
    }
    /*
    static int[,] PenambahanMatriks(int[,] matriks1, int[,] matriks2){
        int[,] hasil = new int[3,3];
        for(int i = 0; i < 3; i++){
            for(int j = 0; j < 3;j++ ){
                hasil[i,j] = matriks1[i,j] + matriks2[i,j];
            }
        }
        return hasil;
    }
    */
}

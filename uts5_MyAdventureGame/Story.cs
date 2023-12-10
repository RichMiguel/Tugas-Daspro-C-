namespace uts5_MyAdventureGame;

class Story
{
    private bool storyTell{get;set;}

    public Story(){
        storyTell = false;
    }

    public void Prolog(){
        bool end = false;
        while(!storyTell && !end){
            Console.WriteLine("Alkisah...\nDi suatu Kerajaan yang dikenal dengan Technologia");Thread.Sleep(1000);
            Console.WriteLine("Hiduplah seorang Putri Kerajaan bernama Raissa(Fiktif)");Thread.Sleep(1000);
            Console.WriteLine("Ia adalah Putri yang sangat di Cintai oleh Rakyat Technologia");Thread.Sleep(1000);
            Console.WriteLine("Ia merupakan Putri dari seorang Raja Abid yang Baik dan Bijaksana");Thread.Sleep(1500);
            Console.WriteLine("Kerajaan Technologia Hidup Makmur pada masa itu..");Thread.Sleep(1000);
            Console.Write("Namun... ");Thread.Sleep(1500);
            Console.Write("Suatu Ketika...");
            Input();
            end = true;}

        end = false;
        while(!storyTell && !end){
            Console.Clear();
            Console.WriteLine("Mystic Dragon datang menyerang Kerajaan Technologia");Thread.Sleep(1000);
            Console.WriteLine("Mystic Dragon datang dengan membawa Undead Army");Thread.Sleep(1000);
            Console.WriteLine("Dan terjadilah Pertempuran yang sangat besar");Thread.Sleep(1000);
            Console.WriteLine("Saat pertempuran itu terjadi, Mystic Dragon diam-diam Menculik Putri Raissa");
            Input();
            end = true;}
        
        end = false;
        while(!storyTell && !end){
            Console.Clear();
            Console.WriteLine("Beberapa Jam Kemudian...");Thread.Sleep(3000);
            Console.WriteLine("Kerajaan Technologia memenangkan pertempuran tersebut");Thread.Sleep(2000);
            Console.Write("Namun.. Putri Raissa berhasil diculik");
            Input();
            end = true;}
        
        end = false;
        while(!storyTell && !end){
            Console.Clear();
            Console.WriteLine("Setelah Kejadian tersebut...");Thread.Sleep(1000);
            Console.WriteLine("Raja Abid segera mengadakan Sayembara untuk Menyelamatkan Putri Raissa");Thread.Sleep(1000);
            Console.WriteLine("\nRaja Abid : Siapapun yang dapat menyelamatkan Putri Raissa\n            Ia dapat menikahi Putri Saya\n");Thread.Sleep(1000);
            Console.WriteLine("Kabar tersebut tersebar hingga ke penjuru dunia");Thread.Sleep(1000);
            Console.WriteLine("Banyak Petarung serta Prajurit yang mengikuti Sayembara tersebut");Thread.Sleep(1000);
            Console.WriteLine("dan diantaranya terdapat seorang Pemuda");Thread.Sleep(1000);
            Console.Write("Yang ingin...");Thread.Sleep(1000);
            Console.Write("MEMBUKTIKAN DIRINYA");
            Input();
            end = true;
        }
    }

    public void Beginning(){
        bool end = false;
        Console.Clear();
        while(!storyTell && !end){
            Console.WriteLine("Prajurit : Apa yang kau lakukan disini anak muda, Taman bermain di sebelah sana!");Thread.Sleep(1500);
            Console.WriteLine("........ : Aku ingin mengikuti Sayembara..");Thread.Sleep(1500);
            Console.WriteLine("Prajurit : HAHAHAH.. Apakah Kau Yakin?");Thread.Sleep(1500);
            Console.WriteLine("........ : Ya, aku ingin membuktikan diriku");Thread.Sleep(1500);
            Console.WriteLine("Prajurit : (Menatap) Lebih baik kau pulang saja anak muda, ini tidak seperti yg kau pikirkan");Thread.Sleep(1500);
            Console.WriteLine("........ : Tolong berikan aku kesempatan!");Thread.Sleep(1500);
            Console.WriteLine("Prajurit : HMMM.. Baiklah. Ambillah Zirah dan Perlengkapanmu di Barack Senjata");
            Input();

            Console.Clear();
            Console.WriteLine("Prajurit : Heii.. Siapa namamu Anak Muda?");Thread.Sleep(1500);
            end = true;
        }
    }

    public void Training(){
        Console.WriteLine("COMBAT GUIDE");
        Console.WriteLine("1.Normal Attack(Serangan Biasa)");
        Console.WriteLine("2.Skill        (Serangan Special yang menggunakan Energi)");
        Console.WriteLine("3.Ultimate     (Serangan Super Special yang memiliki Ability, mengurangi Energi)");
        Console.WriteLine("4.Defend       (Mengisi Energi)");
        Console.WriteLine("5.Use Potion   (Ramuan yang dapat menambah Stat)");
        Console.WriteLine("6.Run          (Menghindari Pertarungan)");
        Input();

        Console.Clear();
        Console.WriteLine("Kalahkan 2 Dummy yang Menghadang!!");
        Console.Write("\nPress ENTER");
        Input();
    }

    public void Combat(Player player){
        Console.Clear();
        Console.WriteLine($"{player.Name} : Baiklah, aku sudah siap mengalahkan Mystic Dragon");Thread.Sleep(2000);
        Console.WriteLine($"{player.Name} : Sudah saatnya Petualanganku DIMULAI!!\n");Thread.Sleep(2000);
        Console.WriteLine($"{player.Name} Memasuki Undead Forest");Thread.Sleep(2000);
        Console.WriteLine($"Berdasarkan informasi yang beredar, Putri Raissa berada di Mystic Tower");Thread.Sleep(2000);
        Console.WriteLine($"Untuk sampai ke Undead Tower, Para Prajurit perlu mengalahkan Undead Army");Thread.Sleep(2000);
        Console.Write($"PERTARUNGAN DIMAULAI...");
        Input();

        Console.Clear();
    }

    public void Ending(Player player){
        Console.Clear();
        Console.WriteLine("Anda berhasil mengalahkan Mystic Dragon.");
        Console.WriteLine("Putri Raissa kembali ke Kerajaan Technologia");
        Console.WriteLine($"Kemudian, {player.Name} menikah dengan Putri Raissa");
        Console.WriteLine("----------------GAME OVER---------------");
    }

    public void Credit(){
        string name = "RICHARD MIQUEL LAIA";
        string text = "Thanks for Playing";
        Console.Clear();
        Console.WriteLine("---- DEVELOPER ----");

        for(int i = 0; i < name.Length; i++ ){
            Console.Write($"{name[i]}");Thread.Sleep(300);
        }

        Console.WriteLine("\n");
        for(int i = 0; i < text.Length; i++ ){
            Console.Write($"{text[i]}");Thread.Sleep(150);
        }
    }

    private void Input(){
        string? input = Console.ReadLine();
        if(input == "skip" || input == "Skip" || input == "SKIP"){
            storyTell = true;
        }
    }
}
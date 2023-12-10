namespace belajar8;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Manusia human = new Manusia("Richard Miquel", 18);
        Manusia dsn = new Dosen("Rahmat Rizal", 40, 1000);
        Manusia mhs = new Mahasiswa("Richard Miquel", 18, 2307113452); // Penerapan Polimorfisme
        Console.WriteLine($"{human.PrintKeterangan()}");
        // Output berupa Nama dan Umur

        Console.WriteLine($"{dsn.PrintKeterangan(12345678)/* Parameter NIK */}");
        // Output berupa Nama, Umur, dan Gaji

        Console.WriteLine($"{mhs.PrintKeterangan(90)/* Parameter Nilai */}"); 
        // Output berupa Nama, Umur, NIM, dan Nilai

        
    }
}


class Manusia
{
    public string Nama{get;set;}
    public int Umur{get;set;}

    public Manusia(string nama, int umur){
        Nama = nama;
        Umur = umur;
    }

    public virtual string PrintKeterangan(){
        return $"Nama : {Nama} | Umur : {Umur}";
    }

    public virtual string PrintKeterangan(uint x){
        return $"Nama : {Nama} | Umur : {Umur}";
    }
}

class Mahasiswa : Manusia
{
    public uint NIM{get;set;}
    public Mahasiswa(string nama, int umur, uint nim) : base(nama, umur){
        Nama = nama;
        Umur = umur;
        NIM = nim;
    }
    public override string PrintKeterangan(){
        return $"(Mahasiswa) Nama : {Nama} | Umur : {Umur} | NIM : {NIM}";
    }

    public override string PrintKeterangan(uint nilai){
        return $"(Mahasiswa) Nama : {Nama}| Umur : {Umur} | NIM : {NIM} | Nilai : {nilai}"; // Penerapan Overloading
    }
}

class Dosen : Manusia
{
    public int Gaji{get;set;}
    public Dosen(string nama, int umur, int gaji) : base(nama, umur){
        Nama = nama;
        Umur = umur;
        Gaji = gaji;
    }
    public override string PrintKeterangan(){
        return $"(Dosen)     Nama : {Nama} | Umur : {Umur} | Gaji : {Gaji}";
    }

    public override string PrintKeterangan(uint nik){
        return $"(Dosen)     Nama : {Nama}| Umur : {Umur} | NIK : {nik} | Gaji : {Gaji}"; // Penerapan Overloading
    }
}

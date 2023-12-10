namespace belajar7;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine();
        Mahasiswa mhs1 = new Mahasiswa();
        mhs1.Nama       = "Richard Miquel Laia";
        mhs1.NIM        = "2307113452";
        mhs1.Absen      = true;
        mhs1.NilaiAngka = 85;
        mhs1.Pengenalan();
        mhs1.HitungNilai(mhs1.Nama, mhs1.NIM, mhs1.NilaiAngka, mhs1.Absen);

        Console.WriteLine();
        Mahasiswa mhs2 = new Mahasiswa();
        mhs2.Nama       = "Jeff Clarence";
        mhs2.NIM        = "2307113123";
        mhs2.Absen      = true;
        mhs2.NilaiAngka = 70;
        mhs2.Pengenalan();
        mhs2.HitungNilai(mhs2.Nama, mhs2.NIM, mhs2.NilaiAngka, mhs2.Absen);
    }
}

class Mahasiswa
{
    public string Nama;
    public string NIM;
    public bool Absen;
    public int NilaiAngka;
    public string NilaiHuruf;

    public void Pengenalan(){
        Console.WriteLine($"Haloo, Nama Saya {Nama} dengan NIM {NIM}");
    }

    public void HitungNilai(string nama,string nim,int nilaiAngka, bool absen){
        if(nilaiAngka >= 85){
            NilaiHuruf = "A";
        }else if(nilaiAngka < 85 && nilaiAngka >= 80){
            NilaiHuruf = "A-";
        }else if(nilaiAngka < 80 && nilaiAngka >= 75){
            NilaiHuruf = "B+";
        }else if(nilaiAngka < 75 && nilaiAngka >= 70){
            NilaiHuruf = "B";
        }else if(nilaiAngka < 70 && nilaiAngka >= 65){
            NilaiHuruf = "B-";
        }else if(nilaiAngka < 65 && nilaiAngka >= 60){
            NilaiHuruf = "C+";
        }else if(nilaiAngka < 60 && nilaiAngka >= 55){
            NilaiHuruf = "C";
        }else if(nilaiAngka < 55 && nilaiAngka >= 40){
            NilaiHuruf = "D";
        }else if(nilaiAngka < 40 && nilaiAngka >= 0){
            NilaiHuruf = "E";
        }else{
            Console.WriteLine("Out of Value");
        }

        if(!absen || NilaiHuruf == "E"){
            Console.WriteLine("Mohon Maaf, anda tidak lulus");
        }else{
            Console.WriteLine($"Nama Mahasiswa : {nama}, NIM : {nim} berhasil lulus dengan Nilai : {NilaiHuruf}");
        }
    }
}
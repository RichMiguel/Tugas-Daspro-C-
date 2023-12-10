namespace Bin2Dec;

class Program
{
    static void Main(string[] args)
    {
        double dec = 0;
        string Input = CheckInput();
        string binaryInput = Reverse(Input);
        for(int i = 0; i < binaryInput.Length; i++){
            if(binaryInput[i] == '1'){
                dec += Math.Pow(2, i);
            }else{
                dec += 0;
            }
        }

        Console.WriteLine($"Result : {dec}");
    }

    static string Reverse(string input){
        string reversed = "";

        for(int i = input.Length-1;i >= 0;i--){
            reversed += input[i];
        }

        return reversed;
    }

    static string CheckInput(){
        Console.Clear();
        Console.Write("Binary : ");
        string? input = Console.ReadLine();
        if(input.Length > 8){
            Console.WriteLine("User can enter up to 8 binary digits");
            Console.ReadLine();
            return CheckInput();
        }else{
            for(int i=0;i<input.Length;i++){
                if(input[i]=='1' || input[i]=='0'){
                    
                }else{
                    Console.WriteLine("Input only 1 or 0");
                    Console.ReadLine();
                    return CheckInput();
                }
            }
        }
        return input;
    }
}

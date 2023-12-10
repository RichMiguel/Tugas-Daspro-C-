using System.Security.Cryptography;

namespace belajar11;

class Program
{
    static string[] runAnimation = {
    // 0
    @"       " + "\n" +
    @"       " + "\n" +
    @"  __o  " + "\n" +
    @" / /\_," + "\n" +
    @"__/\   " + "\n" +
    @"    \  " + "\n",
    // 1
    @"       " + "\n" +
    @"       " + "\n" +
    @"   _o  " + "\n" +
    @"  |/|_ " + "\n" +
    @"  /\   " + "\n" +
    @" /  |  " + "\n",
    // 2
    @"       " + "\n" +
    @"       " + "\n" +
    @"    o  " + "\n" +
    @"  </L  " + "\n" +
    @"   \   " + "\n" +
    @"   /|  " + "\n",
    // 3
    @"       " + "\n" +
    @"       " + "\n" +
    @"   o   " + "\n" +
    @"   |_  " + "\n" +
    @"   |>  " + "\n" +
    @"  /|   " + "\n",
    // 4
    @"       " + "\n" +
    @"       " + "\n" +
    @"   o   " + "\n" +
    @"  <|L  " + "\n" +
    @"   |_  " + "\n" +
    @"   |/  " + "\n",
    // 5
    @"       " + "\n" +
    @"       " + "\n" +
    @"   o   " + "\n" +
    @"  L|L  " + "\n" +
    @"   |_  " + "\n" +
    @"  /| | " + "\n",
    // 6
    @"       " + "\n" +
    @"       " + "\n" +
    @"  _o   " + "\n" +
    @" | |L  " + "\n" +
    @"   /-- " + "\n" +
    @"  /   |" + "\n",
  };

  static string[] jumpAnimation = {
    // 0
    @"       " + "\n" +
    @"       " + "\n" +
    @"   _o  " + "\n" +
    @"  |/|_ " + "\n" +
    @"  /\   " + "\n" +
    @" /  |  " + "\n",
    // 1
    @"       " + "\n" +
    @"       " + "\n" +
    @"       " + "\n" +
    @"    o  " + "\n" +
    @"  </L  " + "\n" +
    @"   /|  " + "\n",
    // 2
    @"       " + "\n" +
    @"    /o/" + "\n" +
    @"    /  " + "\n" +
    @"   //  " + "\n" +
    @"  //   " + "\n" +
    @"       " + "\n",
    // 3
    @"  __o__" + "\n" +
    @" /     " + "\n" +
    @"//     " + "\n" +
    @"       " + "\n" +
    @"       " + "\n" +
    @"       " + "\n",
    // 4
    @"  __   " + "\n" +
    @" // \o " + "\n" +
    @"     \\" + "\n" +
    @"       " + "\n" +
    @"       " + "\n" +
    @"       " + "\n",
    // 5
    @"  __   " + "\n" +
    @" //_o\ " + "\n" +
    @"       " + "\n" +
    @"       " + "\n" +
    @"       " + "\n" +
    @"       " + "\n",
    // 6
    @"  __\  " + "\n" +
    @" _o/   " + "\n" +
    @"       " + "\n" +
    @"       " + "\n" +
    @"       " + "\n" +
    @"       " + "\n",
    // 7
    @" \o\__ " + "\n" +
    @"     \\" + "\n" +
    @"       " + "\n" +
    @"       " + "\n" +
    @"       " + "\n" +
    @"       " + "\n",
    // 8
    @"       " + "\n" +
    @"       " + "\n" +
    @"   o   " + "\n" +
    @"  L|L  " + "\n" +
    @"   |_  " + "\n" +
    @"  /  | " + "\n",
  };

  static int position = 0;
  static int? runFrame = 0;
  static int? jumpFrame = null;
  static string obstacle =
    @"  ___  " + "\n" +
    @" |   | " + "\n" +
    @" | . | ";


    static void Main(string[] args)
    {
        Console.CursorVisible = false;
        Console.ForegroundColor = ConsoleColor.Green;
        if(OperatingSystem.IsWindows()){
            Console.WindowHeight = 20;
            Console.WindowWidth = 120;
        }
        Console.Clear();

        while(position < 10000){
            if(Console.KeyAvailable){
                switch(Console.ReadKey(true).Key){
                    case ConsoleKey.Escape:
                        Console.Clear();
                        Console.Write("GAME OVER");
                        return;
                    case ConsoleKey.UpArrow or ConsoleKey.W:
                        if(!jumpFrame.HasValue){
                            jumpFrame = 0;
                            runFrame = null;
                        }
                        break;
                }
            }

            if(position >= 100 && position % 50 == 0 &&
               (!jumpFrame.HasValue || !(2 <= jumpFrame && jumpFrame <= 7))){
                Console.Clear();
                Console.Write("GAME OVER. Score " + position + ".");
                Console.WriteLine("\nRestart Game? Y/N : ");
                string? input = Console.ReadLine();
                if(input == "Y" || input == "y"){
                    Console.Clear();
                    position = 0;
                }else{
                    return;
                }
            }

            string playerFrame =
                jumpFrame.HasValue ? jumpAnimation[jumpFrame.Value]:
                runAnimation[runFrame!.Value];

            Console.SetCursorPosition(4, 10);
            Render(playerFrame, true);
            ShowObstacle(true);

            if(position % 50 == 5){
                Console.SetCursorPosition(0, 13);
                Render(
                    @"       " + "\n" +
                    @"       " + "\n" +
                    @"       ", true);
            }

            if(position % 50 < 3){
                Console.SetCursorPosition(4, 10);
                Render(playerFrame, false);
                ShowObstacle(false);
            }else{
                ShowObstacle(false);
                Console.SetCursorPosition(4, 10);
                Render(playerFrame, false);
            }

            runFrame = runFrame.HasValue ? (runFrame + 1) % runAnimation.Length : runFrame;
            jumpFrame = jumpFrame.HasValue ? jumpFrame + 1 : jumpFrame;

            if(jumpFrame >= jumpAnimation.Length){
                jumpFrame = null;
                runFrame = 2;
            }

            position++;
            Thread.Sleep(TimeSpan.FromMilliseconds(33));
        }

        Console.Clear();
        Console.Write("CONGRATULATION. YOU WIN");
    }

    static void Render(string @string, bool renderSpace){
        int x = Console.CursorLeft;
        int y = Console.CursorTop;

        foreach(char c in @string)
            if(c is '\n') Console.SetCursorPosition(x, ++y);
            else if(c is not ' ' || renderSpace) Console.Write(c);
            else Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop);
    }

    static void ShowObstacle(bool renderSpace)
    {
        for (int i = 5; i < Console.WindowWidth - 5; i++)
        {
            if (position + i >= 100 && (position + i - 7) % 50 == 0){
                Console.SetCursorPosition(i - 3, 13);
                Render(obstacle, renderSpace);
            }
    }
  }
}

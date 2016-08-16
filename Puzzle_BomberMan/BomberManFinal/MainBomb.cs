using System;
using BomberManFinal.Map;
using BomberManFinal.Log;

namespace BomberManFinal
{
    class MainBomb
    {
        const int ITEM_LIMIT_CNT = 15; //item Limit

        static void Main(string[] args)
        {
            GameInstance instance = new GameInstance();
            instance.InitializefromFile("../../Map/Map1.txt");
            Renderer map = new Renderer();
            Logger log = new Logger();
            Console.Clear();
            instance.ItemMode(ITEM_LIMIT_CNT, 100);
            map.Draw();
            while (true)
            {
                instance.ReadInput();
                Console.Clear();
                map.Draw();
                Common.GLOBAL_FRAME++;
                instance.ItemMode(ITEM_LIMIT_CNT, 5);
                log.state();
                if (Common.IsOVERED == 1)
                {
                    Console.WriteLine("**********");
                    Console.WriteLine("You lose...");
                    Console.WriteLine("**********");
                    break;
                }
                else if(Common.IsOVERED == 2)
                {
                    Console.WriteLine("**********");
                    Console.WriteLine("You Win...");
                    Console.WriteLine("**********");
                    break;
                }
            }
            do { } while (true);
                return;
        }
    }
}

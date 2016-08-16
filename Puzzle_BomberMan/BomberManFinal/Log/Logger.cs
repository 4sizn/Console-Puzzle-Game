using System;
namespace BomberManFinal.Log
{
    class Logger
    {
        public Logger()
        {
        }

        public void state()
        {
            //Global Frame Cnt...
            Console.WriteLine("Frame = {0}", Common.GLOBAL_FRAME);

            //Player has Bombs
            Console.WriteLine("Player has Bombs = {0}", ObjectMgr.GetSingleTon().PLAYER.Hasbomb);
            //Boss Lift Left Cnt...
            Console.Write("BossLife ♡/♥ = ");
            for (int i = 1; i <= ObjectMgr.GetSingleTon().BOSS.BossLife; i++)
                Console.Write('♥');
            Console.WriteLine("");
            //Enemy Left Cnt...
            Console.WriteLine("Enemy Left Cnt ○/● = {0}", ObjectMgr.GetSingleTon().EnemyLeftCnt);
            //Item Left Cnt...
            Console.WriteLine("Item Left Cnt ☆/★= {0}", Common.Item_CNT);    
        }
    }
}

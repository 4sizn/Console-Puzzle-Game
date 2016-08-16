using System;
using System.IO;
using BomberManFinal.Objects;
using System.Collections.Generic;

namespace BomberManFinal
{
    class GameInstance
    {
        Player _player;
        List<Object> _Objects = new List<Object>();

        public void InitializefromFile(string file)
        {
            string[] str;
            str = File.ReadAllLines(file);
            Common.HEIGHT = str.Length;
            Common.WIDTH = str[0].Length;
   
            for (int i = 0; i < Common.HEIGHT; i++)
            {
                for (int j = 0; j < Common.WIDTH; j++)
                {
                    switch (str[i][j])
                    {
                        case '▶':
                            ObjectMgr.GetSingleTon().AddObject(_player = new Player(i, j, Common.GLOBAL_FRAME, 0));
                            break;
                        case '■':
                            ObjectMgr.GetSingleTon().AddObject(new Wall(i, j, Common.GLOBAL_FRAME, 0));
                            break;
                        case '□':
                            ObjectMgr.GetSingleTon().AddObject(new Box(i, j, Common.GLOBAL_FRAME, 0));
                            break;
                        case '●':
                            ObjectMgr.GetSingleTon().AddObject(new Enemy(i, j, Common.GLOBAL_FRAME, 3, ++ObjectMgr.GetSingleTon().EnemyLeftCnt));
                            break;
                        case '♥':
                            ObjectMgr.GetSingleTon().AddObject(new Boss(i, j, Common.GLOBAL_FRAME, 0));
                            break;
                    }
                }
            }
        }

        public void ItemMode(int item_limit_cnt, int percent)
        {
            if (_Objects == null)
                return;
            else
            {
                _Objects = ObjectMgr.GetSingleTon().GetObjects();
                int rnd = GameHelper.GetRand(1, 100);

                while (item_limit_cnt != Common.Item_CNT)
                {
                    rnd = GameHelper.GetRand(1, 100);
                    if (rnd <= percent)
                    {
                        int randx = GameHelper.GetRand(0, 28);
                        int randy = GameHelper.GetRand(0, 16);

                        if (ObjectMgr.GetSingleTon().GetAt(randy, randx) == null)
                        {
                            ObjectMgr.GetSingleTon().AddObject(new Item(randy, randx, Common.GLOBAL_FRAME, 4));
                            ++Common.Item_CNT;
                        }
                    }
                    else
                        break;
                }
                return;
            }
        }

        public void ReadInput()
        {
            Console.WriteLine("==========================================================");
            Console.WriteLine("help : w , a, s, d , 1, 2 (UP, LEFT, DOWN, RIGHT, BOMB, STAY)");
            Console.Write("Insert Text : ");
            string s = Console.ReadLine();

            int x = _player.X;
            int y = _player.Y;
            switch (s)
            {
                case "w":
                    {
                        _player.SetDirection(Common.Direction.UP);
                        --y;
                        break;
                    }
                case "a":
                    {
                        _player.SetDirection(Common.Direction.Left);
                        --x;
                        break;
                    }
                case "s":
                    {
                        _player.SetDirection(Common.Direction.Down);
                        ++y;
                        break;
                    }
                case "d":
                    {
                        _player.SetDirection(Common.Direction.Right);
                        ++x;
                        break;
                    }
                case "1":
                    {
                        if (_player.GetDirection() == 1) // UP
                            --y;
                        else if (_player.GetDirection() == 2) // Left
                            --x;
                        else if (_player.GetDirection() == 3) // Down
                            ++y;
                        else if (_player.GetDirection() == 4) // Right
                            ++x;
                        Object newobj = ObjectMgr.GetSingleTon().GetAt(y, x);
                        if (newobj == null)
                            if (ObjectMgr.GetSingleTon().PLAYER.Hasbomb > 0)
                            {
                                ObjectMgr.GetSingleTon().PLAYER.Hasbomb--;
                                ObjectMgr.GetSingleTon().AddObject(new Bomb(y, x, Common.GLOBAL_FRAME, 2, Common.PALYER));
                            }
                            else
                            {
                                x = _player.X;
                                y = _player.Y;
                            }
                        break;
                    }
            }
            Object obj = ObjectMgr.GetSingleTon().GetAt(y, x);
            if (null == obj || obj is Item)
            {
                // 사용자 폭탄 개수를 증가시켜라
                _player.X = x;
                _player.Y = y;
                if (obj is Item)
                {
                    ++ObjectMgr.GetSingleTon().PLAYER.Hasbomb;
                    obj.SendMessage(obj, Common.Message.MsgDestroy, 0);
                }
            }
            ObjectMgr.GetSingleTon().Update(Common.GLOBAL_FRAME);
        }
    }
}

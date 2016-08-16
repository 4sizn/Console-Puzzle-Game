using System.Collections.Generic;
using BomberManFinal.Objects;

namespace BomberManFinal
{
    public class ObjectMgr
    {
        public List<Object> _objects = new List<Object>();
        
        private int _playerLeftCnt = 1;
        private int _bossLeftCnt = 1;
        private int _enermyLeftCnt = 1; //boss + monster 
        private Player _player;
        private Boss _boss;
        private List<Enemy> _Enemys = new List<Enemy>();
        private static ObjectMgr _mgr;
        public static ObjectMgr GetSingleTon()
        {
            if (_mgr == null)
                _mgr = new ObjectMgr();
            return _mgr;
        }

        public Object GetAt(int y, int x)
        {
            foreach (var obj in _objects)
            {
                if ((obj.X == x) && (obj.Y == y))
                    return obj;
            }
            return null;
        }

        public void AddObject(Object obj)
        {
            _objects.Add(obj);

            if (obj is Player)
                _player = obj as Player;
            else if (obj is Boss)
                _boss = obj as Boss;
            else if (obj is Enemy)
                _Enemys.Add(obj as Enemy);
        
            _objects.Sort(delegate(Object x, Object y)//list Sorting()
            {
                if (x._level == y._level) return 0;
                else return x._level.CompareTo(y._level);
            });
        }

        public Enemy GetEnemyById(int i)
        {
            foreach(var m in _Enemys)
            {
                if (m.Id == i)
                    return m;    
            }
            return null;
        }

        public List<Object> GetObjects()
        {
            return _objects;
        }

        public int IsOvered()
        {
            return Common.IsOVERED;
        }

        public void Update(int global_frame)// 각 object에 맞는 object data 갱신
        {
            if (_objects == null)
                return;
            else
            {
                for (int i = _objects.Count - 1; i >= 0; i--)
                {
                    Object obj = _objects[i];
                    obj.Update(global_frame);
                }

                for (int i = _objects.Count - 1; i >= 0; i--)
                {
                    Object obj = _objects[i];
                    if(obj.CheckDes())
                    {
                        _objects.Remove(obj);
                        if (obj is Enemy)
                            --_enermyLeftCnt;
                        if (obj is Player)
                            --_playerLeftCnt;
                        if (obj is Boss)
                            --_bossLeftCnt;
                        if (obj is Bomb)
                        {
                            Bomb target = obj as Bomb;
                            if (target.Whos == Common.PALYER)
                                ++ObjectMgr.GetSingleTon().PLAYER.Hasbomb;
                            else if (target.Whos == Common.BOSS)
                                ++ObjectMgr.GetSingleTon().BOSS.Hasbomb;
                            else
                            {
                                Enemy enemy = GetEnemyById(target.Whos);
                                ++enemy.Hasbomb;
                            }  
                        }
                    }
                }
            }
            if(GetBossLeftCnt() == 0) //Game Over Check
                Common.IsOVERED = 2;  //Win
            else if(GetPlayerLeftCnt() == 0) // Game Over Check
                Common.IsOVERED = 1; //Lose
        }

    
        public int EnemyLeftCnt
        {
            get { return _enermyLeftCnt; }
            set { _enermyLeftCnt = value; }
        }
        public int GetPlayerLeftCnt()
        {
            return _playerLeftCnt;
        }
        public int GetBossLeftCnt()
        {
            return _bossLeftCnt;
        }
        
        public Boss BOSS
        {
            get { return _boss; }
            set { _boss = (Boss)value; }
        }
        public Player PLAYER
        {
            get { return _player; }
            set { _player = (Player)value; }
        }
    }
}

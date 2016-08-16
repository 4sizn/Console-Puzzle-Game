namespace BomberManFinal.Objects
{
    public class Boss : Enemy
    {
        private const int BOSS_LIFE = 3;
        private int _bossLife;

        public Boss(int y, int x, int frame, int level) : base(y, x, frame, level)
        {
            this._img = '♥';
            _bossLife = BOSS_LIFE;
            Hasbomb = 1;
        }

        public override void ChangeImage()
        {
            if (this._img == '♥')
                this._img = '♡';
            else
                this._img = '♥';
        }

        public override void Update(int globalframe)
        {
            int x = this.X;
            int y = this.Y;

            if (this.CheckDes())
            {
                Destroy();
                return;
            }

            int rnd = GameHelper.GetRand(1, 7);
            switch (rnd)
            {
                case 1: // up
                    --y;
                    break;
                case 2: // left
                    --x;
                    break;
                case 3: // down
                    ++y;
                    break;
                case 4: //right
                    ++x;
                    break;
            }
            Object obj;
            obj = ObjectMgr.GetSingleTon().GetAt(y, x);
            if ((obj == null) || (obj is Item))
            {
                this.X = x;
                this.Y = y;
                if (obj is Item)
                    SendMessage(obj, Common.Message.MsgDestroy, 0);
            }
            if ((Hasbomb > 0) && (rnd > 5))
                CanBomb(Common.BOSS);
            if (_bossLife == 0)
                Destroy();
        }

        public override void OnMessage(Object sender, int msg1, int msg2)
        {
            switch (msg1)
            {
                case Common.Message.MsgDestroy:
                    --this._bossLife;
                    break;
            }
            return;
        }

        public int BossLife
        {
            get { return _bossLife; }
            set { _bossLife = value; }
        }
    }
}

namespace BomberManFinal.Objects
{
    public class Enemy : Object
    {
        private int _id;

        public Enemy(int y, int x, int frame, int level) : base(y, x, frame, level)
        {
            this._img = '●';
        }

        public Enemy(int y, int x, int frame, int level, int id) : base(y, x, frame, level)
        {
            this._img = '●';
            _id = id;
        }

        public override char GetImage()
        {
            ChangeImage();
            return this._img;
        }

        public override void ChangeImage()
        {
            if (this._img == '●')
                this._img = '○';
            else
                this._img = '●';
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
            Object obj = ObjectMgr.GetSingleTon().GetAt(y, x);

            if (obj == null || obj is Item)
            {
                this.X = x;
                this.Y = y;

                if (obj is Item)
                {
                    Hasbomb = 1; // Hasbomb++;
                    SendMessage(obj, Common.Message.MsgDestroy, 0);
                }
            }
            if (Hasbomb > 0 && rnd > 4)
                CanBomb(Id);

            obj = ObjectMgr.GetSingleTon().GetAt(Y, X + 1);
            SendMessage(obj, Common.Message.PlayerKill, 0);
            obj = ObjectMgr.GetSingleTon().GetAt(Y + 1, X);
            SendMessage(obj, Common.Message.PlayerKill, 0);
            obj = ObjectMgr.GetSingleTon().GetAt(Y, X - 1);
            SendMessage(obj, Common.Message.PlayerKill, 0);
            obj = ObjectMgr.GetSingleTon().GetAt(Y - 1, X);
            SendMessage(obj, Common.Message.PlayerKill, 0);
        }

        public override void OnMessage(Object sender, int msg1, int msg2)
        {
            switch (msg1)
            {
                case Common.Message.MsgDestroy:
                    Destroy();
                    break;
            }
            return;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
    }
}

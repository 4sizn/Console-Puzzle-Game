namespace BomberManFinal.Objects
{
    class Bomb : Object
    {
       private const int FIRE_CNT = 5;
       protected int _msg2 = 0;
       private bool _firechain = false;
       private int _whos;

        public Bomb(int y, int x, int frame, int level, int whos) : base(y, x, frame, level)
        {
            this._img = '◆';
            _whos = whos;
        }

        public override void ChangeImage()
        {
            if (this._img == '◆')
                this._img = '◇';
            else
                this._img = '◆';
        }

        public override char GetImage()
        {
            ChangeImage();
            return _img;
        }

        public override void Update(int globalframe)
        {
            if (_firechain==true || globalframe - Frame == FIRE_CNT)
            {
                int x = this.X;
                int y = this.Y;

                if (!(_firechain == true && _msg2 == (int)Common.Direction.UP))
                {
                    Object obj = ObjectMgr.GetSingleTon().GetAt(y - 1, x);
                    SendMessage(obj, Common.Message.MsgDestroy, (int)Common.Direction.Down); // boom up
                }
                if (!(_firechain == true && _msg2 == (int)Common.Direction.Left))
                {
                    Object obj = ObjectMgr.GetSingleTon().GetAt(y, x - 1);
                    SendMessage(obj, Common.Message.MsgDestroy, (int)Common.Direction.Right); // boom left
                }
                if (!(_firechain == true && _msg2 == (int)Common.Direction.Down))
                {
                    Object obj = ObjectMgr.GetSingleTon().GetAt(y + 1, x);
                    SendMessage(obj, Common.Message.MsgDestroy, (int)Common.Direction.UP); // boom down
                }
                if (!(_firechain == true && _msg2 == (int)Common.Direction.Right))
                {
                    Object obj = ObjectMgr.GetSingleTon().GetAt(y, x + 1);
                    SendMessage(obj, Common.Message.MsgDestroy, (int)Common.Direction.Left); // boom right
                }
                Destroy();                
            }
        }

        public override void OnMessage(Object sender, int msg1, int msg2)
        {
            switch (msg1)
            {
                case Common.Message.MsgDestroy:
                    {
                        this._firechain = true;
                        this._msg2 = msg2;
                        this.Update(-1);
                    }
                    break;
            }
        }
        public int Whos
        {
            get { return _whos; }
            set { _whos = value; }
        }
    }
}

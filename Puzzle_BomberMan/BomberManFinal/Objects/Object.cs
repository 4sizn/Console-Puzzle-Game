using BomberManFinal.Objects;

namespace BomberManFinal
{
    public abstract class Object
    {
        private int _x;
        private int _y;
        private int _frame;
        private int _hasBombs;
        private bool _desCheck;
        protected char _img;
        public int _level;

        public Object()
        { }
        public Object(int y, int x, int frame, int level)
        {
            Hasbomb = 0;
            _desCheck = false;
            X = x;
            Y = y;
            Frame = frame;
            _level = level;
        }

        public virtual void Update(int globalframe) { }

        public virtual char GetImage()
        {
            return _img;
        }
        public virtual void ChangeImage() { }

        public void Destroy()
        {
            _desCheck = true;
        }
        public bool CheckDes()
        {
            return _desCheck;
        }

        public void SendMessage(Object obj, int msg1, int msg2)
        {
            if (obj != null)
                obj.OnMessage(this, msg1, msg2);
        }
        public virtual void OnMessage(Object sender, int msg1, int msg2) { }

        public int X
        {
            get { return _x; }
            set { this._x = value; }
        }

        public int Y
        {
            get { return _y; }
            set { this._y = value; }
        }

        public int Frame
        {
            get { return _frame; }
            set { this._frame = value; }
        }

        public int Hasbomb
        {
            get { return _hasBombs; }
            set { _hasBombs = value; }
        }

        public void CanBomb(int whos)
        {
            int x = X;
            int y = Y;
            if (Hasbomb >= 0)
            {
                int rnd = GameHelper.GetRand(1, 4);
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
                if (ObjectMgr.GetSingleTon().GetAt(y, x) == null)
                {
                    --this.Hasbomb;
                    ObjectMgr.GetSingleTon().AddObject(new Bomb(y, x, Common.GLOBAL_FRAME, 2, whos));
                }
            }
        }

    }


}

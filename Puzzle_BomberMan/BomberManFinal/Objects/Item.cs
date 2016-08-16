namespace BomberManFinal.Objects
{
    class Item : Object
    {
        public Item(int y, int x, int frame, int level) : base(y, x, frame, level)
        {
            this._img = '★';
        }

        public override char GetImage()
        {
            ChangeImage();
            return this._img;
        }

        public override void ChangeImage()
        {
            if (this._img == '★')
                this._img = '☆';
            else
                this._img = '★';
        }

        public override void OnMessage(Object sender, int msg1, int msg2)
        {
            switch (msg1)
            {
                case Common.Message.MsgDestroy:
                    --Common.Item_CNT;
                    Destroy();
                    break;
            }
        }
    }
}

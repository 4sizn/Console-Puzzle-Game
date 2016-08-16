namespace BomberManFinal
{
    class Box : Object
    {
        public Box(int y, int x, int frame, int level) : base(y, x, frame, level)
        {
            _img = '□';
        }

        public override void OnMessage(Object sender, int msg1, int msg2)
        {
            switch (msg1)
            {
                case Common.Message.MsgDestroy:
                    Destroy();
                    break;
            }
        }
    }
}

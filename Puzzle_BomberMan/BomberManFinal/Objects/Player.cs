namespace BomberManFinal.Objects
{
    public class Player : Object
    {
        public Player(int y, int x, int frame, int level) : base(y, x, frame, level)
        {
            this._img = '▶';
            Hasbomb = 1;
        }

        public void SetDirection(Common.Direction d)
        {
            switch (d)
            {
                case Common.Direction.UP:
                    this._img = '▲';
                    break;
                case Common.Direction.Down:
                    this._img = '▼';
                    break;
                case Common.Direction.Left:
                    this._img = '◀';
                    break;
                case Common.Direction.Right:
                    this._img = '▶';
                    break;
            }
        }
        public int GetDirection()
        {
            int result = 0;
            switch (_img)
            {
                case '▲':
                    result = 1;
                    break;
                case '◀':
                    result = 2;
                    break;
                case '▼':
                    result = 3;
                    break;
                case '▶':
                    result = 4;
                    break;
            }
            return result;
        }

        public override void OnMessage(Object sender, int msg1, int msg2)
        {
            switch (msg1)
            {
                case Common.Message.MsgDestroy:
                    Destroy();
                    break;
                case Common.Message.PlayerKill:
                    Destroy();
                    break;
            }
            return;
        }
    }
}

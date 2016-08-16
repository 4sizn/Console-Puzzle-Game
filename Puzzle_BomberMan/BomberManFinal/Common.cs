namespace BomberManFinal
{
    public static class Common
    {
        public static int HEIGHT = 0;
        public static int WIDTH = 0;
        public static int GLOBAL_FRAME = 0;
        public static int IsOVERED = 0;
        public static int Item_CNT;
        public const int PALYER = 1000;
        public const int BOSS = 2000;
  
        public enum Direction
        {
            UP = 1,
            Left = 2,
            Down = 3,
            Right = 4,
            Middle = 5,
        };
       
        public static class Message
        {
            public const int MsgDestroy = 0;
            public const int PlayerKill = 1;
        }

    }

}

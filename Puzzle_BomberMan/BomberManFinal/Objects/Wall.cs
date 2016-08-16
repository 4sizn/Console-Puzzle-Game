namespace BomberManFinal.Objects
{
    class Wall : Object
    {
        public Wall(int y, int x, int frame, int level) :base(y, x, frame, level)
        {
            _img = '■';
        }
    }
}

using System;

static class GameHelper
{
    public static Random _rand = new Random((int)DateTime.Now.Ticks);
    public static int GetRand(int min, int max)
    {
        return _rand.Next(min, max);
    }
}

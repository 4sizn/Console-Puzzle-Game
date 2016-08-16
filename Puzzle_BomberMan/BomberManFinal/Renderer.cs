using System;

namespace BomberManFinal.Map
{
    class Renderer
    {
        public void Draw()
        {
            for (int i = 0; i <Common.HEIGHT; i++)
            {
                for (int j = 0; j < Common.WIDTH; j++)
                {
                    Object obj = ObjectMgr.GetSingleTon().GetAt(i, j);

                    if (obj == null)
                        Console.Write("　");
                    else
                    {
                        char img = new char();
                        img = obj.GetImage();
                        Console.Write(img);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}

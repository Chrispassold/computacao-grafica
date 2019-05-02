using System;

namespace exercicio
{
    class Program
    {
        static void Main(string[] args)
        {
            Render render = new Render(500, 500);
            render.Run(1.0 / 60.0);
        }
    }
}

using System;

namespace TrabalhoFinal
{
    class Program
    {
        static void Main(string[] args)
        {
            Render render = new Render(600, 600, 600);
            render.Run();
            render.Run(1.0 / 60.0);
        }
    }
}

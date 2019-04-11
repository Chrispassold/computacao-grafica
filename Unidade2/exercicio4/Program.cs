using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
namespace exercicio4
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("[1] .. Main");

            Render window = new Render(400, 400);
            window.Run();
            window.Run(1.0 / 60.0);
        }
    }
}
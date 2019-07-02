using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;

namespace TrabalhoFinal3D
{
    /// <summary>
    /// Classe que define o mundo virtual
    /// Padrão Singleton
    /// </summary>
    /// 

    class Mundo: Commands.CommandsListener
    {
        private static Mundo instance = null;
        private Commands commands;
        private Driver driver;

        public static Mundo getInstance()
        {
            if (instance == null)
                instance = new Mundo();
            return instance;
        }

        private Mundo()
        {
            commands = Commands.Instance();
            commands.ListenCommands(this);

            driver = new Driver();
        }

        public void Desenha()
        {
            // SRU3D();

            driver.Desenhar();
        }

        private void SRU3D()
        {
            GL.LineWidth(1);
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Red);
            GL.Vertex3(0, 0, 0); GL.Vertex3(200, 0, 0);
            GL.Color3(Color.Green);
            GL.Vertex3(0, 0, 0); GL.Vertex3(0, 200, 0);
            GL.Color3(Color.Blue);
            GL.Vertex3(0, 0, 0); GL.Vertex3(0, 0, 200);
            GL.End();
        }

        public void OnLeft()
        {
            Console.WriteLine("LEFT");
            driver.MoveToLeft();
        }

        public void OnRight()
        {
            Console.WriteLine("RIGHT");
            driver.MoveToRight();
        }

        public void OnEscape()
        {
            Console.WriteLine("ESCAPE");
            driver = new Driver();
        }
    }
}

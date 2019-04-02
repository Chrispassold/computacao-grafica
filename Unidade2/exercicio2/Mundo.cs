using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace exercicio2
{
    class Mundo
    {
        private Ponto4D ptoDirCim = new Ponto4D(100, 100);
        private Ponto4D ptoOrigem = new Ponto4D(0, 0);
        public void Desenha()
        {
            Console.WriteLine("[6] .. Desenha");

            // GL.LineWidth(5);
            // GL.PointSize(10);
            // GL.Color3(Color.Black);

            // GL.Begin(PrimitiveType.Points);
            //     GL.Vertex2(ptoDirCim.X, ptoDirCim.Y);
            // GL.End();

            // GL.Color3(Color.Yellow);
            // GL.Begin(PrimitiveType.Lines);
            //     GL.Vertex2(ptoOrigem.X, ptoOrigem.Y);
            //     GL.Vertex2(ptoDirCim.X, ptoDirCim.Y);
            // GL.End();

            GL.PointSize(5);
            GL.Color3(Color.Yellow);

            int pontos = 72;
            int raio = 100;
            double anguloParte = 360 / pontos;
            GL.Begin(PrimitiveType.Points);
                for (int i = 0; i <= 360; i++)
                {
                    Ponto4D pto = ptoCirculo(anguloParte * i, raio);
                    GL.Vertex2(pto.X, pto.Y);
                }
            GL.End();
        }

        public void SRU3D()
        {
            Console.WriteLine("[5] .. SRU3D");

            GL.LineWidth(1);
            GL.Begin(PrimitiveType.Lines);
                GL.Color3(Color.Red);
                GL.Vertex3(0, 0, 0); GL.Vertex3(150, 0, 0);//x
                GL.Color3(Color.Green);
                GL.Vertex3(0, 0, 0); GL.Vertex3(0, 150, 0);//y
            GL.End();
        }

        public Ponto4D ptoCirculo(double angulo, double raio)
        {
            Ponto4D pto = new Ponto4D();
            pto.X = (raio * Math.Cos(Math.PI * angulo / 180.0));
            pto.Y = (raio * Math.Sin(Math.PI * angulo / 180.0));
            pto.Z = 0;
            return (pto);
        }
    }

}
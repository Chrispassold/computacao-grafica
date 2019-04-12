using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace exercicio5
{
    class Mundo
    {

        Ponto4D ponto1 = new Ponto4D(0, 0);
        Ponto4D ponto2 = new Ponto4D(100, 100);

        public void Desenha()
        {
            GL.LineWidth(1);
            GL.Color3(Color.Blue);

            GL.Begin(PrimitiveType.Lines);
                GL.Vertex2(ponto1.X, ponto1.Y);
                GL.Vertex2(ponto2.X, ponto2.Y);
            GL.End();
        }

        public void SRU3D()
        {
            GL.LineWidth(1);
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Red);
            GL.Vertex3(0, 0, 0); GL.Vertex3(200, 0, 0);//x
            GL.Vertex3(0, 0, 0); GL.Vertex3(-200, 0, 0);//x
            GL.Color3(Color.Green);
            GL.Vertex3(0, 0, 0); GL.Vertex3(0, 200, 0);//y
            GL.Vertex3(0, 0, 0); GL.Vertex3(0, -200, 0);//y
            GL.End();
        }
    }

}
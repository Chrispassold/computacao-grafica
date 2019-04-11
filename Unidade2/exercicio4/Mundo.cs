using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace exercicio4
{
    class Mundo
    {
        private static PrimitiveType primitiva = PrimitiveType.Points;
        private static int count = 0;

        private static PrimitiveType[] types = {
            PrimitiveType.Points,
            PrimitiveType.Lines,
            PrimitiveType.LineLoop,
            PrimitiveType.LineStrip,
            PrimitiveType.Triangles,
            PrimitiveType.TriangleFan,
            PrimitiveType.TriangleStrip,
            PrimitiveType.Quads,
            PrimitiveType.QuadStrip,
            PrimitiveType.Polygon,
        };

        Ponto4D tleft = new Ponto4D(-200, 200);
        Ponto4D tright = new Ponto4D(200, 200);
        Ponto4D bleft = new Ponto4D(-200, -200);
        Ponto4D bright = new Ponto4D(200, -200);

        public static void TogglePrimitive()
        {
            count++;

            if (count >= types.Length)
            {
                count = 0;
            }

            Console.WriteLine(types[count].ToString());

            primitiva = types[count];
        }

        public void Desenha()
        {
            GL.PointSize(5);
            GL.Begin(primitiva);
            GL.Color3(Color.Blue);
            GL.Vertex2(tleft.X, tleft.Y);
            GL.Color3(Color.Green);
            GL.Vertex2(tright.X, tright.Y);
            GL.Color3(Color.Pink);
            GL.Vertex2(bright.X, bright.Y);
            GL.Color3(Color.Red);
            GL.Vertex2(bleft.X, bleft.Y);
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
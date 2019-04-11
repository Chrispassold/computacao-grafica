using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace exercicio3
{
    class Mundo
    {
        private Ponto4D ptoDirCim = new Ponto4D(100, 100);
        private Ponto4D ptoOrigem = new Ponto4D(0, 0);
        public void Desenha()
        {
            GL.PointSize(5);
            GL.Color3(Color.Yellow);

            int altura = 200;
            int size = altura / 2;

            GL.LineWidth(5);
            GL.PointSize(10);
            GL.Color3(Color.Black);

            Ponto4D pntTriangle1 = new Ponto4D(0, size, 0);
            Ponto4D pntTriangle2 = new Ponto4D((-1) * size, (-1) * size, 0);
            Ponto4D pntTriangle3 = new Ponto4D(size, (-1) * size, 0);

            Ponto4D[][] triangles = new Ponto4D[][]{
                new Ponto4D[]{pntTriangle1, pntTriangle2},
                new Ponto4D[]{pntTriangle2, pntTriangle3},
                new Ponto4D[]{pntTriangle3, pntTriangle1},
            };

            for (int i = 0; i < triangles.Length; i++)
            {
                GL.Color3(Color.Blue);
                GL.Begin(PrimitiveType.Lines);
                GL.Vertex2(triangles[i][0].X, triangles[i][0].Y);
                GL.Vertex2(triangles[i][1].X, triangles[i][1].Y);
                GL.End();

                GL.Color3(Color.Red);
                createCircle(triangles[i][0]);
            }
        }

        public void SRU3D()
        {
            GL.LineWidth(1);
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Red);
            GL.Vertex3(0, 0, 0); GL.Vertex3(150, 0, 0);//x
            GL.Color3(Color.Green);
            GL.Vertex3(0, 0, 0); GL.Vertex3(0, 150, 0);//y
            GL.End();
        }

        public void createCircle(Ponto4D center)
        {
            int pontos = 72;
            int raio = 100;
            double anguloParte = 360 / pontos;
            GL.Begin(PrimitiveType.Points);
            for (int i = 0; i <= 360; i++)
            {
                Ponto4D pto = ptoCirculo(anguloParte * i, raio);
                GL.Vertex2(center.X + pto.X, center.Y + pto.Y);
            }
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
using System.Collections.Generic;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System;

namespace exercicio
{
    class Helper
    {

        public static void Draw(PrimitiveType primitiveType, List<Ponto4D> pontos)
        {
            Draw(primitiveType, pontos, Color.Black);
        }

        public static void Draw(PrimitiveType primitiveType, List<Ponto4D> pontos, Color color, Ponto4D pontoSelecionado = null)
        {
            GL.LineWidth(3);
            GL.PointSize(3);
            GL.Color3(color);
            GL.Begin(primitiveType);
            pontos.ForEach(it =>
            {
                GL.Vertex2(it.X, it.Y);
            });
            GL.End();

            if (pontoSelecionado != null)
            {
                CreateCircle(pontoSelecionado);
            }
        }

        public static void Draw(Ponto4D ponto, Color color)
        {
            GL.LineWidth(3);
            GL.PointSize(3);
            GL.Color3(color);
            GL.Begin(PrimitiveType.Points);
            GL.Vertex2(ponto.X, ponto.Y);
            GL.End();
        }

        public static Color color(int red, int green, int blue)
        {
            return Color.FromArgb(red, green, blue);
        }

        private static void CreateCircle(Ponto4D center)
        {
            int pontos = 360;
            int raio = 5;
            double anguloParte = 360 / pontos;
            GL.Begin(PrimitiveType.Points);
            for (int i = 0; i <= 360; i++)
            {
                Ponto4D pto = PtoCirculo(anguloParte * i, raio);
                GL.Vertex2(center.X + pto.X, center.Y + pto.Y);
            }
            GL.End();
        }

        private static Ponto4D PtoCirculo(double angulo, double raio)
        {
            Ponto4D pto = new Ponto4D();
            pto.X = (raio * Math.Cos(Math.PI * angulo / 180.0));
            pto.Y = (raio * Math.Sin(Math.PI * angulo / 180.0));
            pto.Z = 0;
            return (pto);
        }

    }
}

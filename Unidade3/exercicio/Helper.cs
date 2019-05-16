using System.Collections.Generic;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace exercicio
{
    class Helper
    {

        public static void Draw(PrimitiveType primitiveType, List<Ponto4D> pontos)
        {
            Draw(primitiveType, pontos, Color.Black);
        }

        public static void Draw(PrimitiveType primitiveType, List<Ponto4D> pontos, Color color)
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
        }

        public static void Draw(Ponto4D ponto)
        {
            GL.LineWidth(3);
            GL.PointSize(3);
            GL.Color3(Color.Black);
            GL.Begin(PrimitiveType.Points);
            GL.Vertex2(ponto.X, ponto.Y);
            GL.End();
        }

        public static Color color(int red, int green, int blue)
        {
            return Color.FromArgb(red, green, blue);
        }

    }
}

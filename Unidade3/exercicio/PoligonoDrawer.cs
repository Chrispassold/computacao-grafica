using System.Collections.Generic;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace exercicio
{
    class PoligonoDrawer
    {

        private readonly List<Ponto4D> pontos = new List<Ponto4D>();

        private Ponto4D ultimoPonto = null;

        public void Desenha()
        {
            GL.LineWidth(3);
            GL.Color3(Color.Black);
            GL.Begin(PrimitiveType.LineLoop);
            pontos.ForEach(it =>
            {
                GL.Vertex2(it.X, it.Y);
            });
            GL.End();
        }

        public void AddVertice(int x, int y)
        {
            Ponto4D p1 = new Ponto4D(x, y);
            Ponto4D p2 = new Ponto4D(x, y);

            pontos.Add(p1);
            pontos.Add(p2);

            ultimoPonto = p2;
        }

        public void MoveToMouse(int x, int y)
        {
            ultimoPonto.X = x;
            ultimoPonto.Y = y;
        }

    }
}

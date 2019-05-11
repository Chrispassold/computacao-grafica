using System.Collections.Generic;
using OpenTK.Graphics.OpenGL;

namespace exercicio
{
    class PoligonoDrawer
    {

        private readonly List<Ponto4D> pontos = new List<Ponto4D>();

        private Ponto4D ultimoPonto = null;

        public void Draw()
        {
            Helper.Draw(PrimitiveType.LineLoop, pontos);
        }

        public int Count()
        {
            return pontos.Count;
        }

        public void AddVertice(int x, int y)
        {
            Ponto4D p1 = new Ponto4D(x, y);
            Ponto4D p2 = p1.Clone();

            pontos.Add(p1);
            pontos.Add(p2);

            ultimoPonto = p2;
        }

        public void MoveToMouse(int x, int y)
        {
            ultimoPonto.X = x;
            ultimoPonto.Y = y;
        }

        public Poligono Complete()
        {
            return new Poligono(pontos);
        }

    }
}

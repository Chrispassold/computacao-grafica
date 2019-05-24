using System.Collections.Generic;
using OpenTK.Graphics.OpenGL;

namespace exercicio
{
    class PoligonoDrawer
    {

        private readonly List<Ponto4D> pontos = new List<Ponto4D>();
        private readonly List<Ponto4D> aux = new List<Ponto4D>();
        private Ponto4D ultimoPonto = null;
        PrimitiveType primitiva = PrimitiveType.LineLoop;

        public void Draw()
        {
            Helper.Draw(primitiva, pontos);
        }

        /// <summary>
        /// Metodo para adicionar vertices
        /// </summary>
        public void AddVertice(int x, int y)
        {
            Ponto4D p1 = new Ponto4D(x, y);
            Ponto4D p2 = p1.Clone();
            ultimoPonto = p2;

            pontos.Add(p1);
            pontos.Add(p2);
            aux.Add(ultimoPonto);
        }

        /// <summary>
        /// Metodo para mover o ultimo ponto para onde o mouse está
        /// </summary>
        public void MoveToMouse(int x, int y)
        {
            ultimoPonto.X = x;
            ultimoPonto.Y = y;
        }

        /// <summary>
        /// Metodo para retornar o poligono desenhado
        /// </summary>
        public Poligono Complete()
        {
            aux.ForEach(it => pontos.Remove(it));

            return new Poligono(pontos);
        }

        /// <summary>
        /// Metodo para alteração da primitiva atual do poligono
        /// </summary>
        public void ChangePrimitive() => 
            primitiva = primitiva.Equals(PrimitiveType.LineLoop) ? PrimitiveType.LineStrip : PrimitiveType.LineLoop;

        /// <summary>
        /// Metodo para retornar quantidade de pontos
        /// </summary>
        public int Count() => pontos.Count;

    }
}

using System.Collections.Generic;
using OpenTK.Graphics.OpenGL;
using System;

namespace exercicio
{
    public class Poligono
    {

        readonly List<Ponto4D> vertices = new List<Ponto4D>();
        readonly List<Poligono> children = new List<Poligono>();

        readonly BBox bbox = new BBox();
        readonly Transformacao transformacao = new Transformacao();

        PrimitiveType primitiva = PrimitiveType.LineLoop;
        Ponto4D verticeSelecionado;

        //R G B
        int[] cor = new int[3] { 0, 0, 0 };

        public Poligono(List<Ponto4D> pontos)
        {
            AddVertices(pontos);
        }

        /// <summary>
        /// Metodo para adicionar vertices e atualizar a bbox
        /// </summary>
        private void AddVertices(List<Ponto4D> pontos)
        {
            pontos.ForEach(it =>
            {
                vertices.Add(it);
                bbox.atualizarBBox(it);
            });
        }

        /// <summary>
        /// Metodo para alteração da primitiva atual do poligono
        /// </summary>
        void ChangePrimitive()
        {
            primitiva = primitiva.Equals(PrimitiveType.LineLoop) ? PrimitiveType.LineStrip : PrimitiveType.LineLoop;
        }

        /// <summary>
        /// Metodo para desenhar o poligono
        /// </summary>
        public void Draw()
        {
            Helper.Draw(primitiva, vertices);
        }

        public void DrawBBox() => bbox.desenhaBBox();

        public void SelectVertice(Ponto4D ponto)
        {
            verticeSelecionado = DistanceManhattan(ponto);
        }

        
        private Ponto4D DistanceManhattan(Ponto4D ponto)
        {
            Ponto4D selectedPoint = null;
            double minValue = double.MaxValue;
            foreach (var vertice in vertices)
            {
                double distanceX = vertice.X - ponto.X;
                double distanceY = vertice.Y - ponto.Y;
                double distanceManhattan = Math.Abs(distanceX) + Math.Abs(distanceY);
                if (minValue > distanceManhattan)
                {
                    minValue = distanceManhattan;
                    selectedPoint = vertice;
                }
            }

            return selectedPoint;
        }

    }
}
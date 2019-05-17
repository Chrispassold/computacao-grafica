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
        readonly Transformacao4D transformacao = new Transformacao4D();

        Ponto4D verticeSelecionado = null;

        //R G B
        public readonly Cor cor = new Cor();

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
        /// Metodo para desenhar o poligono
        /// </summary>
        public void Draw()
        {
            Helper.Draw(PrimitiveType.LineLoop, vertices, cor.GetColor());
            //Console.WriteLine(verticeSelecionado?.ToString());
        }

        public void DrawBBox() => bbox.desenhaBBox();

        public bool estaNaBBox(Ponto4D pto)
        {
            return bbox.estaDentro(pto);
        }

        public void SelectVertice(Ponto4D ponto)
        {
            if (bbox.estaDentro(ponto))
            {
                verticeSelecionado = DistanceManhattan(ponto);
            }
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
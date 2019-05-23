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


        /// <summary>
        /// Testa se o ponto enviado esta dentro do poligono ou não
        /// </summary>
        /// <example>
        /// Se BBox ok
        ///     paridade =0;
        ///     calcula se ha intersecção esse poligono
        ///     calcula o ti
        ///     se o ti entre 0..1
        ///         calcula o x = x1 + (x2 - x1)*ti
        ///         se x > x1
        ///             paridade++;
        ///     se paridade == impar > DENTRO
        ///     se paridade == par > FORA
        /// </example>
        /// <param name="pto">Ponto a ser testado</param>
        /// <returns></returns>
        public bool clicouDentro(Ponto4D pto)
        {
            if (bbox.estaDentro(pto))
            {
                int countVertices = vertices.Count;
                int paridade = 0;
                for (int i = 0; i < countVertices; i++)
                {
                    Ponto4D ponto1 = vertices[i];
                    int next = (i + 1) > countVertices - 1 ? 0 : i + 1;
                    Ponto4D ponto2 = vertices[next];

                    double ti = (pto.Y - ponto1.Y) / (ponto2.Y - ponto1.Y);

                    if (ti > 0 && ti < 1)
                    {
                        double x = ponto1.X + (ponto2.X - ponto1.X) * ti;
                        if (x > pto.X)
                            paridade++;

                    }
                }
                //par = fora
                //impar = dentro
                return (paridade % 2) != 0;
            }

            return false;
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
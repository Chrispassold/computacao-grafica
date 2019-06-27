using System.Collections.Generic;
using OpenTK.Graphics.OpenGL;
using System;
using OpenTK.Input;

namespace exercicio
{
    public class Poligono
    {

        readonly List<Ponto4D> vertices = new List<Ponto4D>();
        readonly List<Poligono> filhos = new List<Poligono>();

        readonly BBox bbox = new BBox();
        private Transformacao4D transformacao = new Transformacao4D();
        private PrimitiveType primitiva = PrimitiveType.LineLoop;

        Ponto4D verticeSelecionado = null;

        /// Matrizes temporarias que sempre sao inicializadas com matriz Identidade entao podem ser "static".
        private static Transformacao4D matrizTmpTranslacao = new Transformacao4D();
        private static Transformacao4D matrizTmpTranslacaoInversa = new Transformacao4D();
        private static Transformacao4D matrizTmpEscala = new Transformacao4D();
        private static Transformacao4D matrizTmpRotacao = new Transformacao4D();
        private static Transformacao4D matrizGlobal = new Transformacao4D();

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

            GL.PushMatrix();
            GL.MultMatrix(transformacao.GetDate());

            Helper.Draw(primitiva, vertices, cor.GetColor(), verticeSelecionado);
            filhos.ForEach(it => it.Draw());

            GL.PopMatrix();
        }

        public void DrawBBox() => bbox.desenhaBBox();

        internal List<Poligono> GetFilhos()
        {
            return filhos;
        }

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
        public bool ClicouDentro(Ponto4D pto)
        {
            if (bbox.estaDentro(pto))
            {
                bool inside = ScanLine(pto);

                if (inside)
                    SelectVertice(pto);

                return inside;
            }

            return false;
        }

        private void SelectVertice(Ponto4D ponto)
        {
            verticeSelecionado = DistanceManhattan(ponto);
        }

        /// <summary>
        /// Calcula e retorna a posicao do ponto mais proximo
        /// </summary>
        /// <param name="ponto">ponto clicado</param>
        /// <returns>index vertice selecionado</returns>
        private Ponto4D DistanceManhattan(Ponto4D ponto)
        {
            Ponto4D selectedPoint = null;
            double minValue = double.MaxValue;

            foreach (Ponto4D vertice in vertices)
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
        private bool ScanLine(Ponto4D pto)
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

        /// <summary>
        /// Metodo para alteração da primitiva atual do poligono
        /// </summary>
        public void ChangePrimitive() =>
            primitiva = primitiva.Equals(PrimitiveType.LineLoop) ? PrimitiveType.LineStrip : PrimitiveType.LineLoop;

        /// <summary>
        /// Mover o vertice selecionado de acordo com a direcao informada
        /// </summary>
        /// <param name="key">Direcao</param>
        public void MoverVerticeSelecionado(Key key)
        {
            if (verticeSelecionado == null) return;

            switch (key)
            {
                case Key.Up:
                    verticeSelecionado.MoverCima(2);
                    break;
                case Key.Down:
                    verticeSelecionado.MoverBaixo(2);
                    break;
                case Key.Left:
                    verticeSelecionado.MoverEsquerda(2);
                    break;
                case Key.Right:
                    verticeSelecionado.MoverDireita(2);
                    break;
            }

            bbox.atualizarBBox(vertices);
        }
        /// <summary>
        /// Remove o vertice selecionado
        /// </summary>
        public void RemoverVerticeSelecionado()
        {
            if (verticeSelecionado != null)
            {
                Ponto4D aux = verticeSelecionado.Clone();
                vertices.Remove(verticeSelecionado);
                SelectVertice(aux);
            }
        }

        /// <summary>
        /// Adicionar um filho
        /// </summary>
        /// <param name="filho">Filho a ser adicionado</param>
        public void AddFilho(Poligono filho)
        {
            if (!filhos.Contains(filho))
                filhos.Add(filho);
        }

        /// <summary>
        /// Remove seleção do vertice do pai e dos filhos
        /// </summary>
        public void UnselectVerticeSelecionado()
        {
            verticeSelecionado = null;
            filhos.ForEach(it => it.UnselectVerticeSelecionado());
        }


        /// <summary>
        /// Atribui a identidade a matriz, resetando-a
        /// </summary>
        public void atribuirIdentidade()
        {
            transformacao.atribuirIdentidade();
        }

        /// <summary>
        /// Efetua a translação do objeto de acordo com os parametros
        /// </summary>
        /// <param name="tx">Eixo X</param>
        /// <param name="ty">Eixo Y</param>
        /// <param name="tz">Eixo Z</param>
        public void translacaoXYZ(double tx, double ty, double tz)
        {
            Transformacao4D matrizTranslate = new Transformacao4D();
            matrizTranslate.atribuirTranslacao(tx, ty, tz);
            transformacao = matrizTranslate.transformMatrix(transformacao);
        }

        /// <summary>
        /// Efetua a escala, aumentando ou diminuindo a dimensão a partir de um ponto fixo e um fator
        /// </summary>
        /// <param name="escala">Fator</param>
        /// <param name="ptoFixo">Ponto fixo</param>
        public void escalaXYZ(double escala)
        {

            Ponto4D ptoFixo = bbox.obterCentro;
            Console.WriteLine(ptoFixo.ToString());
            matrizGlobal.atribuirIdentidade();

            ptoFixo.inverterSinal();
            matrizTmpTranslacao.atribuirTranslacao(ptoFixo.X, ptoFixo.Y, ptoFixo.Z);
            matrizGlobal = matrizTmpTranslacao.transformMatrix(matrizGlobal);

            matrizTmpEscala.atribuirEscala(escala, escala, 1.0);
            matrizGlobal = matrizTmpEscala.transformMatrix(matrizGlobal);

            ptoFixo.inverterSinal();
            matrizTmpTranslacaoInversa.atribuirTranslacao(ptoFixo.X, ptoFixo.Y, ptoFixo.Z);
            matrizGlobal = matrizTmpTranslacaoInversa.transformMatrix(matrizGlobal);

            transformacao = transformacao.transformMatrix(matrizGlobal);
        }

        /// <summary>
        /// Efetua rotação a partir do angulo eum ponto fixo
        /// </summary>
        /// <param name="angulo">Angulo de rotação</param>
        /// <param name="ptoFixo">Ponto fixo</param>
        public void rotacaoZ(double angulo)
        {

            Ponto4D ptoFixo = bbox.obterCentro;

            matrizGlobal.atribuirIdentidade();

            ptoFixo.inverterSinal();
            matrizTmpTranslacao.atribuirTranslacao(ptoFixo.X, ptoFixo.Y, ptoFixo.Z);
            matrizGlobal = matrizTmpTranslacao.transformMatrix(matrizGlobal);

            matrizTmpRotacao.atribuirRotacaoZ(Transformacao4D.DEG_TO_RAD * angulo);
            matrizGlobal = matrizTmpRotacao.transformMatrix(matrizGlobal);

            ptoFixo.inverterSinal();
            matrizTmpTranslacaoInversa.atribuirTranslacao(ptoFixo.X, ptoFixo.Y, ptoFixo.Z);
            matrizGlobal = matrizTmpTranslacaoInversa.transformMatrix(matrizGlobal);
            
            transformacao = transformacao.transformMatrix(matrizGlobal);
        }

        public int CountVertices()
        {
            return vertices.Count;
        }
    }
}
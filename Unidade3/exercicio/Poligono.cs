using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

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


        /// <summary>
        /// Metodo para alteração da primitiva atual do poligono
        /// </summary>
        void MudarPrimitiva()
        {
            primitiva = primitiva.Equals(PrimitiveType.LineLoop) ? PrimitiveType.LineStrip : PrimitiveType.LineLoop;
        }

        /// <summary>
        /// Metodo para desenhar o poligono
        /// </summary>
        public void Desenha()
        {
            
        }

    }
}
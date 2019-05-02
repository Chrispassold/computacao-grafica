using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace exercicio
{
    public class Poligono
    {

        /// <summary>
        /// Vertices do poligono
        /// </summary>
        readonly List<Ponto4D> vertices = new List<Ponto4D>();

        /// <summary>
        /// Atual primitiva do poligono
        /// </summary>
        PrimitiveType primitiva = PrimitiveType.LineLoop;

        /// <summary>
        /// Atual cor do poligono
        /// </summary>
        int[] cor = new int[3] { 0, 0, 0 };

        /// <summary>
        /// BBox do poligono
        /// </summary>
        readonly BBox bbox = new BBox();

        /// <summary>
        /// Atual transformacao do poligono
        /// </summary>
        readonly Transformacao transformacao = new Transformacao();


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
        void Desenha()
        {

        }

    }
}
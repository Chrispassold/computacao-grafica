using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace TrabalhoFinal3D
{
    internal class BBox
    {
        private double menorX, menorY, menorZ, maiorX, maiorY, maiorZ;
        private Ponto4D centro = new Ponto4D();
        public BBox(double menorX = double.MaxValue, double menorY = double.MaxValue, double menorZ = double.MaxValue, double maiorX = 0, double maiorY = 0, double maiorZ = 0)
        {
            this.menorX = menorX; this.menorY = menorY; this.menorZ = menorZ;
            this.maiorX = maiorX; this.maiorY = maiorY; this.maiorZ = maiorZ;
        }

        /// <summary>
        /// Iniciar a bbox com o ponto informado
        /// </summary>
        /// <param name="pto">Ponto</param>
        public void atribuirBBox(Ponto4D pto)
        {
            menorX = pto.X; menorY = pto.Y; menorZ = pto.Z;
            maiorX = pto.X; maiorY = pto.Y; maiorZ = pto.Z;
            processarCentroBBox();
        }

        public bool estaDentro(Ponto4D pto)
        {
            if(pto.X >= menorX && pto.X <= maiorX)
            {
                if (pto.Y >= menorY && pto.Y <= maiorY)
                {
                    if (pto.Z >= menorZ && pto.Z <= maiorZ)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Reseta a bbox
        /// </summary>
        private void reset()
        {
            menorX = double.MaxValue;
            menorY = double.MaxValue;
            menorZ = double.MaxValue;
            maiorX = 0;
            maiorY = 0;
            maiorZ = 0;
        }

        /// <summary>
        /// Atualizar a Bbox inteira, resetando ela e atribuindo novamente
        /// </summary>
        /// <param name="ptos"></param>
        public void atualizarBBox(List<Ponto4D> ptos)
        {
            reset();
            ptos.ForEach(it => atualizarBBox(it));
        }

        /// <summary>
        /// Atualizar a Bbox adicionando um ponto
        /// </summary>
        /// <param name="pto"></param>
        public void atualizarBBox(Ponto4D pto)
        {
            atualizarBBox(pto.X, pto.Y, pto.Z);
            processarCentroBBox();
        }

        /// <summary>
        /// Atualizar a BBox
        /// </summary>
        /// <param name="x">valor em X</param>
        /// <param name="y">Valor em Y</param>
        /// <param name="z">Valor em Z</param>
        public void atualizarBBox(double x, double y, double z)
        {
            if (x < menorX)
                menorX = x;

            if (x > maiorX)
                maiorX = x;

            if (y < menorY)
                menorY = y;

            if (y > maiorY)
                maiorY = y;

            if (z < menorZ)
                menorZ = z;

            if (z > maiorZ)
                maiorZ = z;
        }

        /// <summary>
        /// Atualiza o centro da bbox
        /// </summary>
        public void processarCentroBBox()
        {
            centro.X = (maiorX + menorX) / 2;
            centro.Y = (maiorY + menorY) / 2;
            centro.Z = (maiorZ + menorZ) / 2;
        }

        /// <summary>
        /// Desenha a bbox
        /// </summary>
        public void desenhaBBox()
        {
            GL.Color3(Color.Brown);

            GL.PointSize(5);
            GL.Begin(PrimitiveType.Points);
            GL.Vertex2(centro.X, centro.Y);
            GL.End();

            GL.LineWidth(1);
            GL.Begin(PrimitiveType.LineLoop);
            GL.Vertex3(menorX, maiorY, menorZ);
            GL.Vertex3(maiorX, maiorY, menorZ);
            GL.Vertex3(maiorX, menorY, menorZ);
            GL.Vertex3(menorX, menorY, menorZ);
            GL.End();
            GL.Begin(PrimitiveType.LineLoop);
            GL.Vertex3(menorX, menorY, menorZ);
            GL.Vertex3(menorX, menorY, maiorZ);
            GL.Vertex3(menorX, maiorY, maiorZ);
            GL.Vertex3(menorX, maiorY, menorZ);
            GL.End();
            GL.Begin(PrimitiveType.LineLoop);
            GL.Vertex3(maiorX, maiorY, maiorZ);
            GL.Vertex3(menorX, maiorY, maiorZ);
            GL.Vertex3(menorX, menorY, maiorZ);
            GL.Vertex3(maiorX, menorY, maiorZ);
            GL.End();
            GL.Begin(PrimitiveType.LineLoop);
            GL.Vertex3(maiorX, menorY, menorZ);
            GL.Vertex3(maiorX, maiorY, menorZ);
            GL.Vertex3(maiorX, maiorY, maiorZ);
            GL.Vertex3(maiorX, menorY, maiorZ);
            GL.End();
        }

        /// Obter menor valor X da BBox.
        public double obterMenorX => menorX;

        /// Obter menor valor Y da BBox.
        public double obterMenorY => menorY;

        /// Obter menor valor Z da BBox.
        public double obterMenorZ => menorZ;

        /// Obter maior valor X da BBox.
        public double obterMaiorX => maiorX;

        /// Obter maior valor Y da BBox.
        public double obterMaiorY => maiorY;

        /// Obter maior valor Z da BBox.
        public double obterMaiorZ => maiorZ;

        /// Obter ponto do centro da BBox.
        public Ponto4D obterCentro => centro;

    }
}
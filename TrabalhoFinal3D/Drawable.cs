using System;
using System.Collections.Generic;
using OpenTK.Graphics.OpenGL;

namespace TrabalhoFinal3D
{
    internal abstract class Drawable
    {
        private bool exibeVetorNormal = false;
        protected List<Ponto4D> listaPto = new List<Ponto4D>();
        private BBox bBox = new BBox();

        protected abstract void Desenha();

        public void Desenhar()
        {
            Desenha();

            if (exibeVetorNormal)
                AjudaExibirVetorNormal();
        }

        public void AdicionaPto(Ponto4D pto, bool updateBbox = true)
        {
            listaPto.Remove(pto);
            listaPto.Add(pto);

            if (updateBbox)
                AtualizarBBox();
        }

        protected void AtualizarBBox()
        {
            if (listaPto.Count > 0)
            {
                bBox.atribuirBBox(listaPto[0]);             // inicializa BBox
                for (int i = 1; i < listaPto.Count; i++)
                {
                    bBox.atualizarBBox(listaPto[i]);
                }
                bBox.processarCentroBBox();
            }
        }

        public void ExibePontos()
        {
            Console.WriteLine("P0[" + listaPto[0].X + "," + listaPto[0].Y + "," + listaPto[0].Z + "," + listaPto[0].W + "]");
            Console.WriteLine("P1[" + listaPto[1].X + "," + listaPto[1].Y + "," + listaPto[1].Z + "," + listaPto[1].W + "]");
        }

        private void AjudaExibirVetorNormal()
        {
            GL.LineWidth(3);
            GL.Color3(1.0, 1.0, 1.0);
            GL.Begin(PrimitiveType.Lines);
            // Face da frente
            GL.Vertex3(0, 0, 0); GL.Vertex3(0, 0, 5);
            // Face do fundo
            GL.Vertex3(0, 0, 0); GL.Vertex3(0, 0, -5);
            // Face de cima
            GL.Vertex3(0, 0, 0); GL.Vertex3(0, 5, 0);
            // Face de baixo
            GL.Vertex3(0, 0, 0); GL.Vertex3(0, -5, 0);
            // Face da direita
            GL.Vertex3(0, 0, 0); GL.Vertex3(5, 0, 0);
            // Face da esquerda
            GL.Vertex3(0, 0, 0); GL.Vertex3(-5, 0, 0);
            GL.End();
        }

        public void TrocaExibeVetorNormal() => exibeVetorNormal = !exibeVetorNormal;
    }
}

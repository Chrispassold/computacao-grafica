using OpenTK.Graphics.OpenGL;
using System;

namespace TrabalhoFinal3D
{
    abstract class Cubo : Drawable
    {
        private float tamanhoAresta;

        private Ponto4D center;

        protected Ponto4D Center
        {
            set
            {
                center = value;
                UpdatePoints();
            }
            get
            {
                return center;
            }
        }

        public Ponto4D CloneCenter() => center.Clone();

        public void TamahoAresta(float size)
        {
            tamanhoAresta = size;
            UpdatePoints();
        }

        private void UpdatePoints()
        {

            listaPto.Clear();

            var aresta = tamanhoAresta;

            if (Center == null)
            {
                AdicionaPto(new Ponto4D(-aresta, -aresta, aresta), false); // PtoA listaPto[0]
                AdicionaPto(new Ponto4D(aresta, -aresta, aresta), false); // PtoB listaPto[1]
                AdicionaPto(new Ponto4D(aresta, aresta, aresta), false); // PtoC listaPto[2]
                AdicionaPto(new Ponto4D(-aresta, aresta, aresta), false); // PtoD listaPto[3]
                AdicionaPto(new Ponto4D(-aresta, -aresta, -aresta), false); // PtoE listaPto[4]
                AdicionaPto(new Ponto4D(aresta, -aresta, -aresta), false); // PtoF listaPto[5]
                AdicionaPto(new Ponto4D(aresta, aresta, -aresta), false); // PtoG listaPto[6]
                AdicionaPto(new Ponto4D(-aresta, aresta, -aresta), false); // PtoH listaPto[7]
            }
            else
            {
                AdicionaPto(new Ponto4D(center.X + -aresta, center.Y + -aresta, center.Z + aresta), false); // PtoA listaPto[0]
                AdicionaPto(new Ponto4D(center.X + aresta, center.Y + -aresta, center.Z + aresta), false); // PtoB listaPto[1]
                AdicionaPto(new Ponto4D(center.X + aresta, center.Y + aresta, center.Z + aresta), false); // PtoC listaPto[2]
                AdicionaPto(new Ponto4D(center.X + -aresta, center.Y + aresta, center.Z + aresta), false); // PtoD listaPto[3]
                AdicionaPto(new Ponto4D(center.X + -aresta, center.Y + -aresta, center.Z + -aresta), false); // PtoE listaPto[4]
                AdicionaPto(new Ponto4D(center.X + aresta, center.Y + -aresta, center.Z + -aresta), false); // PtoF listaPto[5]
                AdicionaPto(new Ponto4D(center.X + aresta, center.Y + aresta, center.Z + -aresta), false); // PtoG listaPto[6]
                AdicionaPto(new Ponto4D(center.X + -aresta, center.Y + aresta, center.Z + -aresta), false); // PtoH listaPto[7]
            }

            AtualizarBBox();
        }


        protected override void Desenha()
        {
            lock (listaPto)
            {
                if (listaPto.Count == 0) return;

                try
                {
                    GL.Begin(PrimitiveType.Quads);
                    // // Face da frente
                    GL.Color3(1.0, 0.0, 0.0);
                    GL.Normal3(0, 0, 0.5);
                    GL.Vertex3(listaPto[0].X, listaPto[0].Y, listaPto[0].Z);    // PtoA
                    GL.Vertex3(listaPto[1].X, listaPto[1].Y, listaPto[1].Z);    // PtoB
                    GL.Vertex3(listaPto[2].X, listaPto[2].Y, listaPto[2].Z);    // PtoC
                    GL.Vertex3(listaPto[3].X, listaPto[3].Y, listaPto[3].Z);    // PtoD
                                                                                // Face do fundo
                    GL.Color3(0.0, 1.0, 0.0);
                    //GL.Normal3(0, 0, -size);
                    GL.Vertex3(listaPto[4].X, listaPto[4].Y, listaPto[4].Z);    // PtoE
                    GL.Vertex3(listaPto[7].X, listaPto[7].Y, listaPto[7].Z);    // PtoH
                    GL.Vertex3(listaPto[6].X, listaPto[6].Y, listaPto[6].Z);    // PtoG
                    GL.Vertex3(listaPto[5].X, listaPto[5].Y, listaPto[5].Z);    // PtoF
                                                                                // Face de cima
                    GL.Color3(0.0, 0.0, 1.0);
                    GL.Normal3(0, 0.5, 0);
                    GL.Vertex3(listaPto[3].X, listaPto[3].Y, listaPto[3].Z);    // PtoD
                    GL.Vertex3(listaPto[2].X, listaPto[2].Y, listaPto[2].Z);    // PtoC
                    GL.Vertex3(listaPto[6].X, listaPto[6].Y, listaPto[6].Z);    // PtoG
                    GL.Vertex3(listaPto[7].X, listaPto[7].Y, listaPto[7].Z);    // PtoH
                                                                                // Face de baixo
                    GL.Color3(1.0, 1.0, 0.0);
                    GL.Normal3(0, -0.5, 0);
                    GL.Vertex3(listaPto[0].X, listaPto[0].Y, listaPto[0].Z);    // PtoA
                    GL.Vertex3(listaPto[4].X, listaPto[4].Y, listaPto[4].Z);    // PtoE
                    GL.Vertex3(listaPto[5].X, listaPto[5].Y, listaPto[5].Z);    // PtoF
                    GL.Vertex3(listaPto[1].X, listaPto[1].Y, listaPto[1].Z);    // PtoB
                                                                                // Face da direita
                    GL.Color3(0.0, 1.0, 1.0);
                    GL.Normal3(0.5, 0, 0);
                    GL.Vertex3(listaPto[1].X, listaPto[1].Y, listaPto[1].Z);    // PtoB
                    GL.Vertex3(listaPto[5].X, listaPto[5].Y, listaPto[5].Z);    // PtoF
                    GL.Vertex3(listaPto[6].X, listaPto[6].Y, listaPto[6].Z);    // PtoG
                    GL.Vertex3(listaPto[2].X, listaPto[2].Y, listaPto[2].Z);    // PtoC
                                                                                // Face da esquerda
                    GL.Color3(1.0, 0.0, 1.0);
                    GL.Normal3(-0.5, 0, 0);
                    GL.Vertex3(listaPto[0].X, listaPto[0].Y, listaPto[0].Z);    // PtoA
                    GL.Vertex3(listaPto[3].X, listaPto[3].Y, listaPto[3].Z);    // PtoD
                    GL.Vertex3(listaPto[7].X, listaPto[7].Y, listaPto[7].Z);    // PtoH
                    GL.Vertex3(listaPto[4].X, listaPto[4].Y, listaPto[4].Z);    // PtoE
                    GL.End();
                }catch(Exception)
                {
                    //ignore
                }
            }


        }
    }
}

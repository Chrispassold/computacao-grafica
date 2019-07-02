using OpenTK.Graphics.OpenGL;
using System;
namespace TrabalhoFinal3D
{
    class Car : Drawable
    {
        private int currentLine;
        public int CurrentLine { set => Instance.currentLine = value; get => Instance.currentLine; }

        private Ponto4D position;
        private Ponto4D Position { set => Instance.position = value; get => Instance.position; }

        private static Car instance = null;

        public static Car Instance
        {
            get
            {
                if (instance == null)
                    instance = new Car();

                return instance;
            }
            private set { instance = value; }
        }

        private Car()
        {
            AdicionaPto(new Ponto4D(-0.5f, -0.5f, 0.5f), false); // PtoA listaPto[0]
            AdicionaPto(new Ponto4D(0.5f, -0.5f, 0.5f), false); // PtoB listaPto[1]
            AdicionaPto(new Ponto4D(0.5f, 0.5f, 0.5f), false); // PtoC listaPto[2]
            AdicionaPto(new Ponto4D(-0.5f, 0.5f, 0.5f), false); // PtoD listaPto[3]
            AdicionaPto(new Ponto4D(-0.5f, -0.5f, -0.5f), false); // PtoE listaPto[4]
            AdicionaPto(new Ponto4D(0.5f, -0.5f, -0.5f), false); // PtoF listaPto[5]
            AdicionaPto(new Ponto4D(0.5f, 0.5f, -0.5f), false); // PtoG listaPto[6]
            AdicionaPto(new Ponto4D(-0.5f, 0.5f, -0.5f), false); // PtoH listaPto[7]

            AtualizarBBox();
        }

        protected override void Desenha()
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
            //GL.Normal3(0, 0, -0.5f);
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
        }

        public void SetPosition(int line, double x)
        {
            CurrentLine = line;

            Position = new Ponto4D(x, 0, 0);
        }

        public void Reset()
        {
            instance = new Car();
        }


    }
}

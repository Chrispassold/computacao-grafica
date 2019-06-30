
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace TrabalhoFinal
{
    class Car : Drawable
    {
        private int currentLine;
        private Point4D position;

        private Point4D Position { set => Instance.position = value; get => Instance.position; }
        public int CurrentLine { set => Instance.currentLine = value; get => Instance.currentLine; }

        public const int POSITION_YAXIS = 50;

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

        private Car() {
            AddPoint(new Point4D(-1, -1, 1)); // PtoA points[0]
            AddPoint(new Point4D(1, -1, 1)); // PtoB points[1]
            AddPoint(new Point4D(1, 1, 1)); // PtoC points[2]
            AddPoint(new Point4D(-1, 1, 1)); // PtoD points[3]
            AddPoint(new Point4D(-1, -1, -1)); // PtoE points[4]
            AddPoint(new Point4D(1, -1, -1)); // PtoF points[5]
            AddPoint(new Point4D(1, 1, -1)); // PtoG points[6]
            AddPoint(new Point4D(-1, 1, -1)); // PtoH points[7]
            AtualizarBBox();
        }

        public new void Draw()
        {


            GL.PointSize(10);
            GL.Color3(Color.Blue);

            GL.Begin(PrimitiveType.Quads);
            // // Face da frente
            GL.Color3(1.0, 0.0, 0.0);
            GL.Normal3(0, 0, 1);
            GL.Vertex3(points[0].X, points[0].Y, points[0].Z);    // PtoA
            GL.Vertex3(points[1].X, points[1].Y, points[1].Z);    // PtoB
            GL.Vertex3(points[2].X, points[2].Y, points[2].Z);    // PtoC
            GL.Vertex3(points[3].X, points[3].Y, points[3].Z);    // PtoD
                                                                        // Face do fundo
            GL.Color3(0.0, 1.0, 0.0);
            // GL.Normal3(0, 0, -1);
            GL.Vertex3(points[4].X, points[4].Y, points[4].Z);    // PtoE
            GL.Vertex3(points[7].X, points[7].Y, points[7].Z);    // PtoH
            GL.Vertex3(points[6].X, points[6].Y, points[6].Z);    // PtoG
            GL.Vertex3(points[5].X, points[5].Y, points[5].Z);    // PtoF
                                                                        // Face de cima
            GL.Color3(0.0, 0.0, 1.0);
            GL.Normal3(0, 1, 0);
            GL.Vertex3(points[3].X, points[3].Y, points[3].Z);    // PtoD
            GL.Vertex3(points[2].X, points[2].Y, points[2].Z);    // PtoC
            GL.Vertex3(points[6].X, points[6].Y, points[6].Z);    // PtoG
            GL.Vertex3(points[7].X, points[7].Y, points[7].Z);    // PtoH
                                                                        // Face de baixo
            GL.Color3(1.0, 1.0, 0.0);
            GL.Normal3(0, -1, 0);
            GL.Vertex3(points[0].X, points[0].Y, points[0].Z);    // PtoA
            GL.Vertex3(points[4].X, points[4].Y, points[4].Z);    // PtoE
            GL.Vertex3(points[5].X, points[5].Y, points[5].Z);    // PtoF
            GL.Vertex3(points[1].X, points[1].Y, points[1].Z);    // PtoB
                                                                        // Face da direita
            GL.Color3(0.0, 1.0, 1.0);
            GL.Normal3(1, 0, 0);
            GL.Vertex3(points[1].X, points[1].Y, points[1].Z);    // PtoB
            GL.Vertex3(points[5].X, points[5].Y, points[5].Z);    // PtoF
            GL.Vertex3(points[6].X, points[6].Y, points[6].Z);    // PtoG
            GL.Vertex3(points[2].X, points[2].Y, points[2].Z);    // PtoC
                                                                        // Face da esquerda
            GL.Color3(1.0, 0.0, 1.0);
            GL.Normal3(-1, 0, 0);
            GL.Vertex3(points[0].X, points[0].Y, points[0].Z);    // PtoA
            GL.Vertex3(points[3].X, points[3].Y, points[3].Z);    // PtoD
            GL.Vertex3(points[7].X, points[7].Y, points[7].Z);    // PtoH
            GL.Vertex3(points[4].X, points[4].Y, points[4].Z);    // PtoE
            GL.End();

        }

        public void SetPosition(int line, double x)
        {
            CurrentLine = line;

            Position = new Point4D(x, 10, POSITION_YAXIS);
        }

        public Point4D GetPosition() => Position.Clone();

        public void Reset()
        {
            instance = new Car();
        }

    }
}

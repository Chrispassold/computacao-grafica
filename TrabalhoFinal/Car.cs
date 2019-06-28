
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace TrabalhoFinal
{
    class Car : Drawable
    {
        private Point4D position = null;
        private int currentLine;

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

        private Car() { }

        public void Draw()
        {
            if (position == null) return;

            GL.PointSize(10);
            GL.Color3(Color.Blue);
            GL.Begin(PrimitiveType.Points);
            GL.Vertex2(position.X, position.Y);
            GL.End();
        }

        public void SetPosition(int line, double x)
        {
            currentLine = line;
            position = new Point4D(x, POSITION_YAXIS);
        }

        public Point4D GetPosition() => position.Clone();

        public int GetLine() => currentLine;

        public void Reset()
        {
            instance = new Car();
        }

    }
}

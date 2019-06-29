
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;

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

        private Car() { }

        public void Draw()
        {
            if (Position == null) return;

            GL.PointSize(10);
            GL.Color3(Color.Blue);
            GL.Begin(PrimitiveType.Points);
            GL.Vertex3(Position.X, Position.Y, Position.Z);
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

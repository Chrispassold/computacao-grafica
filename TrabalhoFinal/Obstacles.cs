using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;

namespace TrabalhoFinal
{
    class Obstacle : Drawable
    {

        private Point4D position = null;
        private int line;

        public Obstacle(int line, Point4D startPoint)
        {
            position = startPoint;
            this.line = line;
        }

        public new void Draw()
        {
            if (position == null) return;

            GL.PointSize(10);
            GL.Color3(Color.Orange);
            GL.Begin(PrimitiveType.Points);
            GL.Vertex3(position.X, position.Y, position.Z);
            GL.End();
        }

        public void Move(int speed)
        {
            position = new Point4D(position.X, position.Y - speed, position.Z);
            OccursColision();
        }

        public void OccursColision()
        {
            if (position.Y == Car.POSITION_YAXIS)
                if (Car.Instance.CurrentLine == line)
                    throw new ColisionException();

        }

        public bool IsOutOfScreen() => position.Y < -10;

    }
}

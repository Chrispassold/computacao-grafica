using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace TrabalhoFinal3D
{
    class Obstacle : Drawable
    {

        private Ponto4D position = null;
        private readonly int line;


        public Obstacle(int line, Ponto4D startPoint)
        {
            position = startPoint;
            this.line = line;
        }

        protected override void Desenha()
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
            OccursColision();
            position = new Ponto4D(position.X, position.Y, position.Z - speed);
        }

        public void OccursColision()
        {
            if (position.Y == 0)
                if (Car.Instance.CurrentLine == line)
                    throw new ColisionException();

        }

        public bool IsOutOfScreen() => position.Z < -10;

    }
}

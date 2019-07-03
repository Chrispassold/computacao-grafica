using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace TrabalhoFinal3D
{
    class Obstacle : Cubo
    {

        private Ponto4D position = null;
        private readonly int line;


        public Obstacle(int line, Ponto4D startPoint)
        {
            TamahoAresta(0.5f);
            position = startPoint;
            this.line = line;
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

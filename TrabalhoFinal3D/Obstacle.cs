using System;

namespace TrabalhoFinal3D
{
    class Obstacle : Cubo
    {

        private readonly int line;

        public Obstacle(int line, Ponto4D startPoint)
        {
            this.line = line;
            Center = startPoint;
            TamahoAresta(0.5f);
        }

        public void Move(int speed)
        {
            lock (Center)
            {
                OccursColision(speed);
                Center = new Ponto4D(Center.X, Center.Y, Center.Z - speed);
            }
        }

        private void OccursColision(int speed)
        {
            if ((Center.Z - speed) == 0)
            {
                if (Car.Instance.CurrentLine == line)
                {
                    throw new ColisionException();
                }
            }

        }

        public bool IsOutOfScreen() => Center.Z < -2;

    }
}

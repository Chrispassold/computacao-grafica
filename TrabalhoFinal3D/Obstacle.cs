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

        public void Move(double speed)
        {
            lock (Center)
            {
                OccursColision(speed);
                Center = new Ponto4D(Center.X, Center.Y, Center.Z - speed);
            }
        }

        private void OccursColision(double speed)
        {

            if(speed == Constants.DRIVER_MAX_SPEED)
                Console.WriteLine(Center.Z - speed);

            if (Center.Z > 0 && (Center.Z - speed) <= 0)
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

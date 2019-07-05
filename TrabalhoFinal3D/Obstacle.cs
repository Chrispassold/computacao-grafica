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
                OccursColision();
                Center = new Ponto4D(Center.X, Center.Y, Center.Z - speed);
                Console.WriteLine("Line OBSTACULO: " + Center.ToString());
            }
        }

        public void OccursColision()
        {
            if (Center.Z <= 2)
                if (Car.Instance.CurrentLine == line)
                {
                    Console.WriteLine(Center.ToString());
                    throw new ColisionException();
                }
        }

        public bool IsOutOfScreen() => Center.Z < -2;

    }
}

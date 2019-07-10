using System;
using System.Runtime.CompilerServices;
using System.Timers;

namespace TrabalhoFinal3D
{
    class Driver : Drawable, Street.StreetListener
    {

        private Car car = Car.Instance;
        private Street street = Street.Instance;
        private Timer timer = new Timer();

        private int currentLine;
        private double speed;

        private int qtdObstaclesPassed = 0;

        public Driver()
        {
            currentLine = (int)Math.Ceiling(Constants.STREET_QTD_LINES / 2d);
            speed = Constants.DRIVER_INITIAL_SPEED;

            car.Reset();
            street.Reset();

            street.AddStreetListener(this);

            double xAxios = street.GetXAxiosByLine(currentLine);
            car.SetPosition(currentLine, xAxios);

            StartMove();
        }

        protected override void Desenha()
        {
            car.Desenhar();
            street.Desenhar();
        }

        private void StartMove()
        {
            timer.Interval = Constants.DRIVER_INTERVAL_MOVE;
            timer.Elapsed += Move;
            timer.Enabled = true;
        }


        public void MoveToRight()
        {
            try
            {
                currentLine -= 1;
                double xAxios = street.GetXAxiosByLine(currentLine);
                car.SetPosition(currentLine, xAxios);
            }
            catch (Exception)
            {
                currentLine += 1;
            }
        }

        public void MoveToLeft()
        {
            try
            {
                currentLine += 1;
                double xAxios = street.GetXAxiosByLine(currentLine);
                car.SetPosition(currentLine, xAxios);
            }
            catch (Exception)
            {
                currentLine -= 1;
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void Move(object source, ElapsedEventArgs e)
        {
            try
            {
                street.Move(speed);
            }
            catch (ColisionException)
            {
                Console.WriteLine("COLISÃO");
                Stop();
            }
        }

        private void IncreaseSpeed()
        {
            speed += Constants.DRIVER_INC_SPEED_RATE;
        }

        private void Stop()
        {
            timer.Enabled = false;
            street.Stop();
        }

        public void OnObstacleRemoved()
        {
            qtdObstaclesPassed++;
            if (qtdObstaclesPassed == Constants.DRIVER_OBSTACLES_INC_SPEED)
            {
                qtdObstaclesPassed = 0;
                if (speed < Constants.DRIVER_MAX_SPEED)
                {
                    IncreaseSpeed();

                    if (speed == Constants.DRIVER_MAX_SPEED)
                        Console.WriteLine("MAX SPEED");
                    else
                        Console.WriteLine("Speed = " + speed);
                }
            }
        }
    }
}

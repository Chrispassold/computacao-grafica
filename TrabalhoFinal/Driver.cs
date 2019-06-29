using System;
using System.Timers;

namespace TrabalhoFinal
{
    class Driver : Drawable
    {
        public const int DRIVER_INTERVAL_MOVE = 10;

        private Car car = Car.Instance;
        private Street street = Street.Instance;
        private Timer timer = new Timer();

        private int currentLine;
        private int speed;

        public Driver()
        {
            currentLine = (int)Math.Ceiling(Street.STREET_QTD_LINES / 2d);
            speed = 2;

            car.Reset();
            street.Reset();

            double xAxios = street.GetXAxiosByLine(currentLine);
            car.SetPosition(currentLine, xAxios);

            StartMove();
        }

        private void StartMove()
        {
            timer.Interval = DRIVER_INTERVAL_MOVE;
            timer.Elapsed += Move;
            timer.Enabled = true;
        }

        public void MoveToRight()
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

        public void MoveToLeft()
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

        public void Draw()
        {
            car.Draw();
            street.Draw();
        }

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
            speed += 1;
        }

        private void Stop()
        {
            timer.Enabled = false;
        }
    }
}

using System;

namespace TrabalhoFinal
{
    class Driver
    {

        private Car car;
        private Street street;

        private int currentLine = 1;

        public Driver(Car car, Street street)
        {
            this.car = car;
            this.street = street;

            double xAxios = street.GetXAxiosByLine(currentLine);
            car.SetPosition(xAxios);
        }

        public void MoveToRight()
        {
            try
            {
                currentLine += 1;
                double xAxios = street.GetXAxiosByLine(currentLine);
                car.SetPosition(xAxios);
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
                car.SetPosition(xAxios);
            }
            catch (Exception)
            {
                currentLine += 1;
            }
        }

    }
}

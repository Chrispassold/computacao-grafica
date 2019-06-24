using System;

namespace TrabalhoFinal
{
    class Mundo : Commands.CommandsListener
    {

        Commands commands;
        Street street;
        Car car;
        Driver driver;

        public Mundo()
        {
            commands = Commands.Instance();
            commands.ListenCommands(this);

            street = new Street();
            car = new Car();
            driver = new Driver(car, street);
        }

        private void Reset()
        {
        }

        public void Draw()
        {
            street.Draw();
            car.Draw();
        }

        public void OnEscape()
        {
            Console.WriteLine("ESCAPE");
            driver = new Driver(car, street);
        }

        public void OnLeft()
        {
            Console.WriteLine("LEFT");
            driver.MoveToLeft();
        }

        public void OnRight()
        {
            Console.WriteLine("RIGHT");
            driver.MoveToRight();
        }
    }
}

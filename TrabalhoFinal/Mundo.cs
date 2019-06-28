using System;

namespace TrabalhoFinal
{
    class Mundo : Commands.CommandsListener
    {

        Commands commands;
        Driver driver;

        public Mundo()
        {
            commands = Commands.Instance();
            commands.ListenCommands(this);

            driver = new Driver();
        }

        public void Draw()
        {
            driver.Draw();
        }

        public void OnEscape()
        {
            Console.WriteLine("ESCAPE");
            driver = new Driver();
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

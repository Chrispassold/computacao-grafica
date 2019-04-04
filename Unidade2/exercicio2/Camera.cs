using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
namespace exercicio2
{
    public class Camera
    {
        GameWindow window;

        private double panX = 0.0;
        private double panY = 0.0;
        private double panZ = 0.0;

        private double zoomX = 0.0;
        private double zoomY = 0.0;

        public Camera(GameWindow window)
        {
            this.window = window;
            window.KeyDown += KeyDown;
        }


        private void KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            Console.WriteLine("KeyDown: {0}, {1}", e.Key, sender);
        }

        /*
                private void HandleKeyboard()
                {
                //var keyState = Keyboard.GetState();

                }

        */
    }
}
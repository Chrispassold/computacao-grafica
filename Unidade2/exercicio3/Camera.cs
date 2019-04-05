using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
namespace exercicio3
{
    public class Camera
    {
        GameWindow window;

        private double left = 0.0;
        private double right = 0.0;
        private double top = 0.0;
        private double bottom = 0.0;

        private double panFactor = 1.0;
        private double zoomFactor = 0.9;

        public Camera(GameWindow window)
        {
            this.window = window;
            //window.KeyDown += KeyDown;
        }

        public void Ortho()
        {
            GL.Ortho(this.left, this.right, this.bottom, this.top, -1, 1);//camera
        }

        public void InitOrtho(double left, double right, double bottom, double top)
        {
            this.left = left;
            this.right = right;
            this.bottom = bottom;
            this.top = top;
        }



        private void KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            Console.WriteLine("KeyDown: {0} - {1}", e.Key, sender);
            switch (e.Key)
            {
                case Key.E:
                    Esquerda();
                    break;
                case Key.D:
                    Direita();
                    break;
                case Key.C:
                    Cima();
                    break;
                case Key.B:
                    Baixo();
                    break;
                case Key.I:
                    ZoomIn();
                    break;
                case Key.O:
                    ZoomOut();
                    break;
            }

        }

        private void Esquerda()
        {
            this.right = this.right - panFactor;
            this.left = this.left - panFactor;
        }

        private void Direita()
        {
            this.right = this.right + panFactor;
            this.left = this.left + panFactor;
        }

        private void Cima()
        {
            this.top = this.top - panFactor;
            this.bottom = this.bottom - panFactor;
        }

        private void Baixo()
        {
            this.top = this.top + panFactor;
            this.bottom = this.bottom + panFactor;
        }

        private void ZoomIn()
        {
            this.top = this.top / zoomFactor;
            this.bottom = this.bottom / zoomFactor;
            this.right = this.right / zoomFactor;
            this.left = this.left / zoomFactor;
        }

        private void ZoomOut()
        {
            this.top = this.top * zoomFactor;
            this.bottom = this.bottom * zoomFactor;
            this.right = this.right * zoomFactor;
            this.left = this.left * zoomFactor;
        }
    }
}
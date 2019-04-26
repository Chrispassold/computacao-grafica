using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using OpenTK.Input;
using System.Collections.Generic;

namespace exercicio7
{
    class Mundo : IKeyDownListener, IMouseEventListener
    {

        /*
E por fim, esta aplicação tem o objetivo de fazer um joystick virtual. Basicamente deve-se desenhar dois círculos (um menor e outro maior) 
e poder usar o mouse para mover o círculo menor, mas sem deixar ele (o centro do círculo menor) sair dos limites do círculo maior.
Para controlar o movimento do centro do círculo menor deve ser usado:
– um teste inicial pela BBox interna do círculo maior;
– seguido do cálculo da distância (euclidiana, sem raiz).
         */

        Camera camera;

        private int mainRaio = 150;
        private int dragRaio = 50;
        private Ponto4D center = new Ponto4D();

        private Ponto4D dotDragCircle = new Ponto4D();

        bool mousePressed = false;
        double lastX;
        double lastY;

        public Mundo(Camera camera)
        {
            this.camera = camera;
            camera.SetOnKeyDownListener(this);
            camera.SetMouseListener(this);
            this.reset();
        }

        private void reset()
        {
            mousePressed = false;
            UpdateDotCirclePoint(0, 0);
            UpdateLastPoint(0, 0);
        }

        public void Render()
        {
            this.DrawMainCircle();
            this.DrawDragCircle();
            this.DrawMainSquare();
        }

        public void OnKeyPressed(KeyboardKeyEventArgs key)
        {

        }

        public void DrawMainSquare()
        {
            int angulo = 45;
            GL.Color3(Color.Pink);
            GL.Begin(PrimitiveType.Lines);
            ptoCircle(angulo, this.mainRaio).GLVertex();
            ptoCircle(angulo * 3, this.mainRaio).GLVertex();

            ptoCircle(angulo * 3, this.mainRaio).GLVertex();
            ptoCircle(angulo * 5, this.mainRaio).GLVertex();

            ptoCircle(angulo * 5, this.mainRaio).GLVertex();
            ptoCircle(angulo * 7, this.mainRaio).GLVertex();

            ptoCircle(angulo * 7, this.mainRaio).GLVertex();
            ptoCircle(angulo, this.mainRaio).GLVertex();
            GL.End();
        }

        public void DrawDragCircle()
        {
            GL.LineWidth(2);
            this.CreateCircle(this.dotDragCircle.X, this.dotDragCircle.Y, this.dragRaio);
            this.DrawDotDragCircle();

        }

        public void DrawDotDragCircle()
        {
            GL.PointSize(5);
            GL.Begin(PrimitiveType.Points);
            dotDragCircle.GLVertex();
            GL.End();
        }

        public void DrawMainCircle()
        {
            GL.LineWidth(3);
            this.CreateCircle(0, 0, this.mainRaio);
        }

        private void CreateCircle(double centerX, double centerY, int raio)
        {
            int pontos = 360;

            double anguloParte = 360 / pontos;
            GL.Color3(Color.Black);
            GL.PointSize(2);
            GL.Begin(PrimitiveType.Points);
            for (int i = 0; i <= 360; i++)
            {
                Ponto4D pto = ptoCircle(anguloParte * i, raio);
                GL.Vertex2(centerX + pto.X, centerY + pto.Y);
            }
            GL.End();
        }

        public Ponto4D ptoCircle(double angulo, double raio)
        {
            Ponto4D pto = new Ponto4D();
            pto.X = (raio * Math.Cos(Math.PI * angulo / 180.0));
            pto.Y = (raio * Math.Sin(Math.PI * angulo / 180.0));
            pto.Z = 0;
            return (pto);
        }

        public void OnMouseKeyDown(MouseButtonEventArgs e)
        {

        }

        public void OnMouseKeyUp(MouseButtonEventArgs e)
        {
            this.reset();
        }

        public void MoveDragPoint(double x, double y)
        {

            Console.WriteLine("X:" + this.dotDragCircle.X);
            Console.WriteLine("Y:" + this.dotDragCircle.Y);

            double newX = this.dotDragCircle.X + x;
            double newY = this.dotDragCircle.Y + y;

            UpdateDotCirclePoint(newX, newY);
        }

        public void OnMouseMove(MouseMoveEventArgs e)
        {
            this.mousePressed = e.Mouse.IsButtonDown(OpenTK.Input.MouseButton.Left);

            if (this.mousePressed)
            {
                double deslocX = e.X - lastX;
                double deslocY = lastY - e.Y;

                this.MoveDragPoint(deslocX, deslocY);

                UpdateLastPoint(e.X, e.Y);
            }
            else
            {
                UpdateLastPoint(0, 0);
            }
        }

        private void UpdateDotCirclePoint(double x, double y)
        {
            this.dotDragCircle.X = x;
            this.dotDragCircle.Y = y;
        }

        private void UpdateLastPoint(double x, double y)
        {
            this.lastX = x;
            this.lastY = y;
        }
    }

}
using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using OpenTK.Input;

namespace exercicio
{
    public class Render : GameWindow
    {
        Mundo mundo;
        Camera camera;
        readonly Events events = Events.Instance();

        public Render(int width, int height) : base(width, height)
        {
            camera = Camera.Initialize(-width, width, -height, height);
            mundo = new Mundo();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, camera.xmax, 0, camera.ymax, -1, 1);
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.ClearColor(Color.White);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            mundo.Draw();

            SwapBuffers();
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
            events.OnMousePressChange(e);

        }

        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            base.OnMouseUp(e);
            events.OnMousePressChange(e);
        }

        protected override void OnMouseMove(MouseMoveEventArgs e)
        {
            base.OnMouseMove(e);
            events.OnMouseMove(e.X, e.Y);

        }

        protected override void OnKeyDown(KeyboardKeyEventArgs e)
        {
            base.OnKeyDown(e);
            events.OnKeyPressChange(e.Key, Events.State.ON);
        }

        protected override void OnKeyUp(KeyboardKeyEventArgs e)
        {
            base.OnKeyUp(e);
            events.OnKeyPressChange(e.Key, Events.State.OFF);
        }
    }
}
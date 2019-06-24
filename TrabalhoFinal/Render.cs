using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;


namespace TrabalhoFinal
{
    public class Render : GameWindow
    {
        Mundo mundo;
        Camera camera;
        readonly InputObservable listener = InputObservable.Instance();

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

        protected override void OnKeyDown(KeyboardKeyEventArgs e)
        {
            base.OnKeyDown(e);
            listener.OnKeyPressChange(e.Key);
        }
    }
}

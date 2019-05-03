using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
namespace exercicio
{
    public class Render : GameWindow
    {
        Camera camera;
        Mundo mundo;
        public Render(int width, int height) : base(width, height)
        {
            this.camera = new Camera((-1) * width, width, (-1) * height, height);
            this.mundo = new Mundo(this.camera);
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
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.ClearColor(Color.White);
            GL.MatrixMode(MatrixMode.Modelview);

            mundo.Desenha();

            this.SwapBuffers();
        }
    }
}
using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
namespace exercicio
{
public class Render : GameWindow
    {
        Mundo mundo;
        public Render(int width, int height) : base(width, height)
        {
            this.mundo = new Mundo(width, height);
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
using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
namespace exercicio2
{
    public class Render : GameWindow
    {
        Camera camera;
        Mundo mundo = new Mundo();
        public Render(int width, int height) : base(width, height)
        {
            Camera camera = new Camera(this);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //Console.WriteLine("[2] .. OnLoad");
        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            //Console.WriteLine("[3] .. OnUpdateFrame");

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-300, 300, -300, 300, -1, 1);//camera
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            //Console.WriteLine("[4] .. OnRenderFrame");

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.ClearColor(Color.White);
            GL.MatrixMode(MatrixMode.Modelview);

            mundo.SRU3D();
            mundo.Desenha();

            this.SwapBuffers();
        }
    }
}
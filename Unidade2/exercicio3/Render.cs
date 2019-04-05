using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
namespace exercicio3
{
    public class Render : GameWindow
    {
        Camera camera;
        Mundo mundo = new Mundo();
        public Render(int width, int height) : base(width, height)
        {
            this.camera = new Camera(this);
            camera.InitOrtho(-300, 300, -300, 300);//camera
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
            camera.Ortho();//camera

            
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
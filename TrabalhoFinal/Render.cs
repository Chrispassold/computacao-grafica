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
        Vector3 eye = Vector3.Zero, target = Vector3.Zero, up = Vector3.UnitY;

        public Render(int width, int height, int depth) : base(width, height)
        {
            camera = Camera.Initialize(-width, width, -height, height, -depth, depth);
            mundo = new Mundo();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(Color.Gray);                        // Aqui é melhor
            GL.Enable(EnableCap.DepthTest);                   // NOVO

            eye.X = 0;
            eye.Y = 0;
            eye.Z = 0;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height);

            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4, Width / (float)Height, 1.0f, 50.0f);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);
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
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit); // GL.Clear(ClearBufferMask.ColorBufferBit);

            Matrix4 modelview = Matrix4.LookAt(eye, target, up);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelview);

            mundo.Draw();

            SRU3D();

            SwapBuffers();
        }

        protected override void OnKeyDown(KeyboardKeyEventArgs e)
        {
            base.OnKeyDown(e);
            listener.OnKeyPressChange(e.Key);
            /*
            if (e.Key == Key.Q)
                eye.X = eye.Y = eye.Z = 15;
            else
  if (e.Key == Key.W)
                eye.X = eye.Y = eye.Z = 10;
            else
    if (e.Key == Key.E)
                eye.X = eye.Y = eye.Z = 5;
            else
      if (e.Key == Key.R)
                eye.X = eye.Y = eye.Z = 1;
            else
      if (e.Key == Key.T)
                eye.X = eye.Y = eye.Z = 0;
            else
      if (e.Key == Key.Y)
                eye.X = eye.Y = eye.Z = -1;
            else
      if (e.Key == Key.U)
                eye.X = eye.Y = eye.Z = -5;
            else
      if (e.Key == Key.I)
                eye.X = eye.Y = eye.Z = -10;
            else
      if (e.Key == Key.O)
                eye.X = eye.Y = eye.Z = -15;
            else
      if (e.Key == Key.A)
                target.X = target.Y = target.Z = 15;
            else
      if (e.Key == Key.S)
                target.X = target.Y = target.Z = 10;
            else
      if (e.Key == Key.D)
                target.X = target.Y = target.Z = 5;
            else
      if (e.Key == Key.F)
                target.X = target.Y = target.Z = 1;
            else
      if (e.Key == Key.G)
                target.X = target.Y = target.Z = 0;
            else
      if (e.Key == Key.H)
                target.X = target.Y = target.Z = -1;
            else
      if (e.Key == Key.J)
                target.X = target.Y = target.Z = -5;
            else
      if (e.Key == Key.K)
                target.X = target.Y = target.Z = -10;
            else
      if (e.Key == Key.L)
                target.X = target.Y = target.Z = -15;*/

        }

        public void SRU3D()
        {
            GL.LineWidth(5);
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Red);
            GL.Vertex3(0, 0, 0); GL.Vertex3(150, 0, 0);//x
            GL.Color3(Color.Green);
            GL.Vertex3(0, 0, 0); GL.Vertex3(0, 150, 0);//y
            GL.Color3(Color.Blue);
            GL.Vertex3(0, 0, 0); GL.Vertex3(0, 0, 150);//y
            GL.End();
        }


    }
}

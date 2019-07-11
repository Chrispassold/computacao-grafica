using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;

namespace TrabalhoFinal3D
{
    class Render : GameWindow
    {
        Mundo mundo = Mundo.getInstance();
        Vector3 eye = Vector3.Zero, target = Vector3.Zero, up = Vector3.UnitY;
        readonly InputObservable listener = InputObservable.Instance();
        private Color cor = Color.White;

        public Render(int width, int height) : base(width, height)
        {
            Camera.Initialize();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(Color.Gray);                        // Aqui é melhor
            GL.Enable(EnableCap.DepthTest);                   // NOVO

            //eye.X = 0;
            //eye.Y = 10;
            //eye.Z = -25;

            eye.X = 0;
            eye.Y = 10;
            eye.Z = -20;

            // Enable Light 0 and set its parameters.
            GL.Light(LightName.Light0, LightParameter.Position, new float[] { 1.0f, 1.0f, 1.0f });
            GL.Light(LightName.Light0, LightParameter.Ambient, new float[] { 0.3f, 0.3f, 0.3f, 1.0f });
            GL.Light(LightName.Light0, LightParameter.Diffuse, new float[] { 1.0f, 1.0f, 1.0f, 1.0f });
            GL.Light(LightName.Light0, LightParameter.Specular, new float[] { 1.0f, 1.0f, 1.0f, 1.0f });
            GL.Light(LightName.Light0, LightParameter.SpotExponent, new float[] { 1.0f, 1.0f, 1.0f, 1.0f });
            GL.LightModel(LightModelParameter.LightModelAmbient, new float[] { 0.2f, 0.2f, 0.2f, 1.0f });
            GL.LightModel(LightModelParameter.LightModelTwoSide, 1);
            GL.LightModel(LightModelParameter.LightModelLocalViewer, 1);

            // Use GL.Material to set your object's material parameters.
            GL.Material(MaterialFace.Front, MaterialParameter.Ambient, new float[] { 0.3f, 0.3f, 0.3f, 1.0f });
            GL.Material(MaterialFace.Front, MaterialParameter.Diffuse, new float[] { 1.0f, 1.0f, 1.0f, 1.0f });
            GL.Material(MaterialFace.Front, MaterialParameter.Specular, new float[] { 1.0f, 1.0f, 1.0f, 1.0f });
            GL.Material(MaterialFace.Front, MaterialParameter.Emission, new float[] { 0.0f, 0.0f, 0.0f, 1.0f });

            //FIXME: cor só aparece nas superfícies laterais. Ter mais tipos de luz.      
            GL.Material(MaterialFace.Front, MaterialParameter.ColorIndexes, cor);

        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height);

            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4, Width / (float)Height, Constants.NEAR, Constants.FAR);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit); // GL.Clear(ClearBufferMask.ColorBufferBit);

            Matrix4 modelview = Matrix4.LookAt(eye, target, up);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelview);

           // GL.Enable(EnableCap.Lighting);
            //GL.Enable(EnableCap.Light0);

           //GL.Enable(EnableCap.ColorMaterial);

            mundo.Desenha();

          //  GL.Disable(EnableCap.Lighting);
//GL.Disable(EnableCap.Light0);

            SwapBuffers();
        }

        protected override void OnKeyDown(KeyboardKeyEventArgs e)
        {

            switch (e.Key)
            {
                case Key.A:
                    eye.X -= 1;
                    Console.WriteLine(string.Format("{0} - {1} - {2}", eye.X, eye.Y, eye.Z));
                    break;
                case Key.D:
                    eye.X += 1;
                    Console.WriteLine(string.Format("{0} - {1} - {2}", eye.X, eye.Y, eye.Z));
                    break;
                case Key.W:
                    eye.Y += 1;
                    Console.WriteLine(string.Format("{0} - {1} - {2}", eye.X, eye.Y, eye.Z));
                    break;
                case Key.S:
                    eye.Y -= 1;
                    Console.WriteLine(string.Format("{0} - {1} - {2}", eye.X, eye.Y, eye.Z));
                    break;
                case Key.Z:
                    eye.Z += 1;
                    Console.WriteLine(string.Format("{0} - {1} - {2}", eye.X, eye.Y, eye.Z));
                    break;
                case Key.X:
                    eye.Z -= 1;
                    Console.WriteLine(string.Format("{0} - {1} - {2}", eye.X, eye.Y, eye.Z));
                    break;
            }

            listener.OnKeyPressChange(e.Key);
        }

    }
}

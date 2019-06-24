using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace TrabalhoFinal
{
    class Car : Drawable
    {
        private Point4D position = null;

        public void Draw()
        {
            if (position == null) return;

            GL.PointSize(10);
            GL.Color3(Color.Blue);
            GL.Begin(PrimitiveType.Points);
            GL.Vertex2(position.X, position.Y);
            GL.End();
        }

        public void SetPosition(double x)
        {
            position = new Point4D(x, 50);
        }


    }
}

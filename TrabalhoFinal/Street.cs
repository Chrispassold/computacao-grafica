using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace TrabalhoFinal
{
    class Street : Drawable
    {

        private const int STREET_WIDTH = 300;
        private const int STREET_LINES = 3;

        private double xmin, xmax;

        private Camera camera;

        public Street()
        {
            camera = Camera.Instance();
            var center = camera.Center();

            xmin = center.X - (STREET_WIDTH / 2);
            xmax = center.X + (STREET_WIDTH / 2);
        }

        public void Draw()
        {
            DrawLimit();
            DrawLines();
        }

        public int QuantityLines() => STREET_LINES;

        public double GetXAxiosByLine(int line)
        {
            if (line < 1 || line > STREET_LINES)
                throw new System.InvalidOperationException(string.Format("No line %d found", line));

            int distLines = STREET_WIDTH / STREET_LINES;
            var centerLineX = xmin + (line * distLines) - (distLines / 2);

            return centerLineX;
        }

        private void DrawLimit()
        {
            var lineLeft1 = new Point4D(xmin, camera.ymax);
            var lineLeft2 = new Point4D(xmin, camera.ymin);

            var lineRight1 = new Point4D(xmax, camera.ymax);
            var lineRight2 = new Point4D(xmax, camera.ymin);

            GL.LineWidth(3);
            GL.PointSize(3);
            GL.Color3(Color.Red);
            GL.Begin(PrimitiveType.Lines);
            //limite da esquerda
            GL.Vertex2(lineLeft1.X, lineLeft1.Y);
            GL.Vertex2(lineLeft2.X, lineLeft2.Y);

            //limite da direita
            GL.Vertex2(lineRight1.X, lineRight1.Y);
            GL.Vertex2(lineRight2.X, lineRight2.Y);

            GL.End();
        }

        private void DrawLines()
        {
            int distanceLines = STREET_WIDTH / STREET_LINES;

            GL.LineWidth(3);
            GL.PointSize(3);
            GL.Color3(Color.Blue);
            GL.Begin(PrimitiveType.Lines);
            for (int i = distanceLines; i < STREET_WIDTH; i += distanceLines)
            {
                GL.Vertex2(xmin + i, camera.ymax);
                GL.Vertex2(xmin + i, camera.ymin);
            }
            GL.End();

        }

    }
}

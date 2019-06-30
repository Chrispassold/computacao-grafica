using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace TrabalhoFinal
{
    abstract class Drawable
    {

        protected List<Point4D> points = new List<Point4D>();
        private BBox bBox = new BBox();

        public virtual void Draw()
        {
            GL.LineWidth(4);
            GL.Color3(Color.White);
            GL.Begin(PrimitiveType.LineLoop);
            foreach (Point4D pto in points)
            {
                GL.Vertex2(pto.X, pto.Y);
            }
            GL.End();
        }

        protected void AddPoint(Point4D point)
        {
            points.Remove(point);
            points.Add(point);
        }

        public void AtualizarBBox()
        {
            if (points.Count > 0)
            {
                bBox.atribuirBBox(points[0]);             // inicializa BBox
                for (int i = 1; i < points.Count; i++)
                {
                    bBox.atualizarBBox(points[i]);
                }
                bBox.processarCentroBBox();
            }
        }

    }
}

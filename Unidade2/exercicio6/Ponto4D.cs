using System;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
namespace exercicio6
{
    internal class Ponto4D
    {
        private double x;
        private double y;
        private double z;
        private double w;

        private bool selected = false;

        public Ponto4D(double x = 0.0, double y = 0.0, bool selected = false)
        {
            this.x = x;
            this.y = y;
            this.z = 0;
            this.w = 1;
            this.selected = selected;
        }

        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }
        public double Z { get => z; set => z = value; }

        public override string ToString()
        {
            return string.Format("[Ponto4D => x: {0}, y:{1}, z:{2}]", this.X, this.Y, this.Z);
        }

        public void SetSelected(bool selected)
        {
            this.selected = selected;
        }

        public bool IsSelected()
        {
            return selected;
        }

        public void GLVertex(Color color)
        {
            GL.Color3(color);
            GL.Vertex3(this.X, this.Y, this.Z);
        }
        
        public void GLVertex()
        {
            if (this.selected)
                GL.Color3(Color.Red);
            else
                GL.Color3(Color.Black);

            GL.Vertex3(this.X, this.Y, this.Z);
        }

    }
}
using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace exercicio5
{
    public class SRU3D
    {
        public static void Render(){
            GL.LineWidth(1);
            GL.Begin(PrimitiveType.Lines);
            GL.Color3(Color.Red);
            GL.Vertex3(0, 0, 0); GL.Vertex3(200, 0, 0);//x
            GL.Vertex3(0, 0, 0); GL.Vertex3(-200, 0, 0);//x
            GL.Color3(Color.Green);
            GL.Vertex3(0, 0, 0); GL.Vertex3(0, 200, 0);//y
            GL.Vertex3(0, 0, 0); GL.Vertex3(0, -200, 0);//y
            GL.End();
        }
    }
}
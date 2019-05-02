using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace exercicio
{
    public class Mundo
    {
        private Camera camera;
        private readonly List<Poligono> poligonos = new List<Poligono>();
        private Poligono ultimoPoligonoSelecionado = null;
        private bool ehPonto = false;

        public Mundo(double width, double height)
        {
            camera = new Camera();
        }

        public void Desenha()
        {
            
        }
    }
}
using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using OpenTK.Input;
using System.Collections.Generic;

namespace exercicio7
{
    class Mundo : IKeyDownListener
    {

        /*
E por fim, esta aplicação tem o objetivo de fazer um joystick virtual. Basicamente deve-se desenhar dois círculos (um menor e outro maior) 
e poder usar o mouse para mover o círculo menor, mas sem deixar ele (o centro do círculo menor) sair dos limites do círculo maior.
Para controlar o movimento do centro do círculo menor deve ser usado:
– um teste inicial pela BBox interna do círculo maior;
– seguido do cálculo da distância (euclidiana, sem raiz).
         */

        Camera camera;

        private double center = 150;

        public Mundo(Camera camera)
        {
            this.camera = camera;
            camera.SetOnKeyDownListener(this);
            this.init();
        }

        private void init()
        {

        }

        public void Render()
        {

            GL.PointSize(1);
            GL.LineWidth(1);

        }

        public void OnKeyPressed(KeyboardKeyEventArgs key)
        {

        }


    }

}
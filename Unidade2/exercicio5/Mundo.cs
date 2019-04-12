using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using OpenTK.Input;

namespace exercicio5
{
    class Mundo
    {

        /*
        Agora, crie uma nova aplicação com o objetivo de poder mover um Segmento de Reta (SR),
        aqui conhecido com Sr. "Palito", lateralmente usando as teclas Q (esquerda) e W (Direita).
        Ao iniciar a aplicação um dos pontos do Sr. Palito está na origem. O segundo ponto do Sr. Palito
        será definido com raio de valor 100 e ângulo 45º. Ainda é possível usar as teclas A (diminuir)
        e S (aumentar) para mudar  o tamanho (raio), e as teclas Z (diminuir) e X (aumentar) para girar
        (ângulo) do Sr. Palito. Olhe o exemplo no vídeo a baixo.
         */

        Ponto4D ponto1 = new Ponto4D(0, 0);
        Ponto4D ponto2 = new Ponto4D(100, 100);
        Camera camera;

        public Mundo(Camera camera)
        {
            this.camera = camera;
        }

        public void Render()
        {
            GL.PointSize(5);
            GL.Color3(Color.Blue);

            GL.Begin(PrimitiveType.Lines);
            GL.Vertex2(ponto1.X, ponto1.Y);
            GL.Vertex2(ponto2.X, ponto2.Y);
            GL.End();
        }

        private void onKeyDown(object sender, KeyboardKeyEventArgs e){

        }
    }

}
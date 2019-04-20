using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using OpenTK.Input;

namespace exercicio5
{
    class Mundo : IKeyDownListener
    {

        /*
        Agora, crie uma nova aplicação com o objetivo de poder mover um Segmento de Reta (SR),
        aqui conhecido com Sr. "Palito", lateralmente usando as teclas Q (esquerda) e W (Direita).
        Ao iniciar a aplicação um dos pontos do Sr. Palito está na origem. O segundo ponto do Sr. Palito
        será definido com raio de valor 100 e ângulo 45º. Ainda é possível usar as teclas A (diminuir)
        e S (aumentar) para mudar  o tamanho (raio), e as teclas Z (diminuir) e X (aumentar) para girar
        (ângulo) do Sr. Palito. Olhe o exemplo no vídeo a baixo.
         */


        static double angulo = 45;
        static double raio = 100;
        static Ponto4D ponto1 = Ponto4D.InstanceFrom(angulo, 0);
        static Ponto4D ponto2 = Ponto4D.InstanceFrom(angulo, raio, ponto1);
        Ponto4D ponto3 = Ponto4D.InstanceFrom(angulo, raio);

        Camera camera;

        public Mundo(Camera camera)
        {
            this.camera = camera;
            camera.SetOnKeyDownListener(this);
        }

        public void Render()
        {

            GL.LineWidth(5);
            GL.Color3(Color.Blue);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex2(ponto1.X, ponto1.Y);
            GL.Vertex2(ponto2.X, ponto2.Y);
            GL.End();
        }

        public void SetPonto1(double x, double y)
        {
            ponto1.X = x;
            ponto1.Y = y;
        }

        public void SetPonto2(Ponto4D ponto)
        {
            ponto2 = ponto;
        }
        public void SetPonto2(double x, double y)
        {
            ponto2.X = x;
            ponto2.Y = y;
        }

        public void OnKeyPressed(KeyboardKeyEventArgs key)
        {

            Console.WriteLine(key.Key.ToString());

            //movimentar esquerda (Q)
            if (Key.Q.Equals(key.Key))
            {
                this.SetPonto1(ponto1.X - 2, ponto1.Y);
                this.SetPonto2(ponto2.X - 2, ponto2.Y);

            }

            //movimentar direita (W)
            if (Key.W.Equals(key.Key))
            {
                this.SetPonto1(ponto1.X + 2, ponto1.Y);
                this.SetPonto2(ponto2.X + 2, ponto2.Y);
            }

            //diminuir (A)
            if (Key.A.Equals(key.Key))
            {
                if (raio >= 0)
                {
                    raio -= 2;
                    ponto2.UpdateRaio(raio);
                }
            }

            //aumentar (S)
            if (Key.S.Equals(key.Key))
            {
                raio += 2;
                ponto2.UpdateRaio(raio);
            }

            //rotacionar sentido anti horario (diminuir) (Z)
            if (Key.Z.Equals(key.Key))
            {
                angulo += 1;
                ponto2.UpdateAngulo(angulo);
            }

            //rotacionar sentido horario (aumentar) (X)
            if (Key.X.Equals(key.Key))
            {
                angulo -= 1;
                ponto2.UpdateAngulo(angulo);
            }

            Console.WriteLine("ponto1: " + ponto1.ToString());
            Console.WriteLine("ponto2: " + ponto2.ToString());

        }
    }

}
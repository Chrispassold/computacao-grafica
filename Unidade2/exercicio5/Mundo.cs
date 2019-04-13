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
        Ponto4D ponto1 = PtoCirculo(angulo, CalcularModulo(0, 0));
        Ponto4D ponto2 = PtoCirculo(angulo, CalcularModulo(100, 100));

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
            this.ponto1 = PtoCirculo(angulo, CalcularModulo(x, y));
        }

        public void SetPonto2(double x, double y)
        {
            this.ponto2 = PtoCirculo(angulo, CalcularModulo(x, y));
        }

        public void OnKeyPressed(KeyboardKeyEventArgs key)
        {

            Console.WriteLine(key.Key.ToString());
            Console.WriteLine("ponto1: " + ponto1.ToString());
            Console.WriteLine("ponto2: " + ponto2.ToString());
            Console.WriteLine("angulo: " + angulo);

            //movimentar esquerda
            if (Key.Q.Equals(key.Key))
            {
                if (ponto1.X > SRU3D.NX)
                {
                    this.SetPonto1(ponto1.X - 2, ponto1.Y);
                    this.SetPonto2(ponto2.X - 2, ponto2.Y);
                }

            }

            //movimentar direita
            if (Key.W.Equals(key.Key))
            {
                this.SetPonto1(ponto1.X + 2, ponto1.Y);
                this.SetPonto2(ponto2.X + 2, ponto2.Y);
            }

            //diminuir
            if (Key.A.Equals(key.Key))
            {
                this.SetPonto2(ponto2.X - 2, ponto2.Y - 2);
            }

            //aumentar
            if (Key.S.Equals(key.Key))
            {
                this.SetPonto2(ponto2.X + 2, ponto2.Y + 2);
            }

            //rotacionar sentido anti horario (diminuir)
            if (Key.Z.Equals(key.Key))
            {
                angulo += 1;
                this.SetPonto2(ponto2.X, ponto2.Y);
            }

            //rotacionar sentido horario (aumentar)
            if (Key.X.Equals(key.Key))
            {
                angulo += -1;
                this.SetPonto2(ponto2.X, ponto2.Y);
            }

        }

        private static Ponto4D PtoCirculo(double angulo, double raio)
        {
            Ponto4D pto = new Ponto4D();
            pto.X = (raio * Math.Cos(Math.PI * angulo / 180.0));
            pto.Y = (raio * Math.Sin(Math.PI * angulo / 180.0));
            pto.Z = 0;
            return (pto);
        }

        private static double CalcularModulo(double x, double y)
        {
            return Math.Sqrt(x * x + y * y);
        }

    }

}
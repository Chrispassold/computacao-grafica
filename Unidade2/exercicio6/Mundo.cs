using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using OpenTK.Input;

namespace exercicio6
{
    class Mundo : IKeyDownListener
    {

        /*
Já esta aplicação o seu objetivo é poder desenhar uma spline (curva polinomial) que permita alterar a posição (x,y) dos pontos de controle dinamicamente utilizando o teclado. As dimensões da janela com valores (xMin: -400, xMax: 400, yMin: -400, yMax: 400) e os pontos são valores de 100 negativo e positivo de forma que o resultado final seja o mais parecido com o vídeo a baixo.
No caso a interação deve ser:
– para mudar entre o ponto de controle selecionado (em cor vermelha) usar as teclas “1, 2, 3 e 4”;
– para mover o ponto selecionado (um dos pontos de controle) usar as teclas C (cima), B (baixo), E (esquerda) e D (direita);
– as teclas do sinal de mais (+) e menos (-) podem aumentar e diminui a quantidade de pontos calculados na spline;
– ao pressionar a tecla R os pontos de controle devem voltar aos valores iniciais;
– a spline deve ser desenha usando linhas de cor amarela;
– o poliedro de controle deve ser desenhado usando uma linha de cor ciano.
ATENÇÃO: não é permitido usar o comando spline do OpenGL, sendo só permitido usar UMA das formas de splines “demonstradas em aula”. Ao mover um dos pontos de controle, o poliedro e a spline deve se ajustar aos novos valores deste ponto.
Veja o exemplo no vídeo a baixo.
         */

        Ponto4D[] arrPontos = new Ponto4D[]{
            new Ponto4D(-100, 100, true),//1 pontoTopLeft
            new Ponto4D(100, 100),//2 pontoTopRight
            new Ponto4D(-100, -100),//3 pontoBottomLeft
            new Ponto4D(100, -100)//4 pontoBottomRight
        };

        Ponto4D selected;

        Camera camera;

        public Mundo(Camera camera)
        {
            this.camera = camera;
            camera.SetOnKeyDownListener(this);
        }

        public void Render()
        {

            GL.PointSize(10);
            GL.Begin(PrimitiveType.Points);
            for (int i = 0; i < arrPontos.Length; i++)
            {
                Ponto4D ponto = arrPontos[i];

                if (ponto.IsSelected())
                    this.selected = ponto;
                ponto.GLVertex2();
            }
            GL.End();


        }

        public void OnKeyPressed(KeyboardKeyEventArgs key)
        {
            switch (key.Key)
            {
                case Key.Number1:
                    DefineSelected(0);
                    break;
                case Key.Number2:
                    DefineSelected(1);
                    break;
                case Key.Number3:
                    DefineSelected(2);
                    break;
                case Key.Number4:
                    DefineSelected(3);
                    break;
                case Key.E:
                case Key.D:
                case Key.C:
                case Key.B:
                    Move(key.Key);
                    break;
            }
        }

        private void Move(Key key)
        {
            //esquerda
            if (Key.E.Equals(key))
            {
                if (selected != null)
                {
                    selected.X -= 1;
                }
            }

            //direita
            if (Key.D.Equals(key))
            {
                if (selected != null)
                {
                    selected.X += 1;
                }
            }

            //cima
            if (Key.C.Equals(key))
            {
                if (selected != null)
                {
                    selected.Y += 1;
                }
            }

            //baixo
            if (Key.B.Equals(key))
            {
                if (selected != null)
                {
                    selected.Y -= 1;
                }
            }
        }

        private void DefineSelected(int index)
        {
            for (int i = 0; i < arrPontos.Length; i++)
            {
                bool selected = i == index;

                arrPontos[i].SetSelected(selected);
            }
        }

    }

}
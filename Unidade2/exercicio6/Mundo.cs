using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using OpenTK.Input;
using System.Collections.Generic;

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

        List<Ponto4D> arrPontos;

        Ponto4D selected = null;

        Camera camera;

        double controlSplines = 0d;

        List<Ponto4D> splinePoints = new List<Ponto4D>();

        public Mundo(Camera camera)
        {
            this.camera = camera;
            camera.SetOnKeyDownListener(this);
            this.init();
        }

        private void init()
        {
            this.arrPontos = new List<Ponto4D>(){
                new Ponto4D(-100, -100),
                new Ponto4D(-100, 100),
                new Ponto4D(100, 100),
                new Ponto4D(100, -100),
            };

            this.controlSplines = 1;
            this.splinePoints = GetSplines();
        }

        public void Render()
        {

            GL.PointSize(10);
            GL.LineWidth(2);
            Ponto4D lastPoint = null;
            for (int i = 0; i < arrPontos.Count; i++)
            {
                Ponto4D ponto = arrPontos[i];

                if (this.selected == null)
                {
                    ponto.SetSelected(true);
                }

                if (ponto.IsSelected())
                {
                    this.selected = ponto;
                }

                GL.Begin(PrimitiveType.Points);
                ponto.GLVertex();
                GL.End();

                if (lastPoint != null)
                {
                    GL.Begin(PrimitiveType.Lines);
                    lastPoint.GLVertex(Color.Cyan);
                    ponto.GLVertex(Color.Cyan);
                    GL.End();
                }
                lastPoint = ponto;
            }

            this.DrawSpline();

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
                case Key.R:
                    Reset();
                    break;
                case Key.Plus:
                case Key.KeypadPlus:
                    IncreaseSplinePoints();
                    break;
                case Key.Minus:
                case Key.KeypadMinus:
                    DecreaseSplinePoints();
                    break;
            }
        }

        private void Reset()
        {
            this.init();
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

            if (selected != null)
                this.UpdateSplinePoints();

        }

        private void DefineSelected(int index)
        {
            for (int i = 0; i < arrPontos.Count; i++)
            {
                bool selected = i == index;

                arrPontos[i].SetSelected(selected);
            }
        }

        public void IncreaseSplinePoints()
        {
            if (this.controlSplines < 50)
            {
                this.controlSplines++;
                this.UpdateSplinePoints();
            }
        }

        public void DecreaseSplinePoints()
        {
            if (this.controlSplines > 1)
            {
                this.controlSplines--;
                this.UpdateSplinePoints();
            }
        }

        private void UpdateSplinePoints()
        {
            this.splinePoints = GetSplines();
        }

        private void DrawSpline()
        {
            Ponto4D lastSplinePoint = null;
            foreach (Ponto4D point in this.splinePoints)
            {
                if (lastSplinePoint != null)
                {
                    GL.Begin(PrimitiveType.Lines);
                    GL.Color3(Color.Yellow);
                    lastSplinePoint.GLVertex(Color.Yellow);
                    point.GLVertex(Color.Yellow);
                    GL.End();
                }

                lastSplinePoint = point;
            }
        }

        private List<Ponto4D> GetSplines()
        {
            List<Ponto4D> splinePoints = new List<Ponto4D>();
            for (int i = 0; i <= this.controlSplines; i++)
            {
                double t = (1 / this.controlSplines) * i;
                splinePoints.Add(this.GetSplinesPoint(t));
            }
            return splinePoints;
        }

        private Ponto4D GetSplinesPoint(double t)
        {

            Queue<Ponto4D> fila = new Queue<Ponto4D>();
            Queue<Ponto4D> aux = new Queue<Ponto4D>();

            arrPontos.ForEach(value => fila.Enqueue(value));
            while (fila.Count > 1)
            {
                Ponto4D ponto1 = fila.Dequeue();
                Ponto4D ponto2 = fila.Peek();

                double newX = CalculateSpline(t, ponto1.X, ponto2.X);
                double newY = CalculateSpline(t, ponto1.Y, ponto2.Y);

                aux.Enqueue(new Ponto4D(newX, newY));

                if (fila.Count <= 1)
                {
                    var tmp = fila;
                    tmp.Clear();
                    fila = aux;
                    aux = tmp;
                }
            }

            return fila.Dequeue();
        }

        private double CalculateSpline(double t, double A, double B)
        {
            return A + (B - A) * t;
        }

    }

}
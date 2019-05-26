using System.Collections.Generic;
using OpenTK.Input;
using System;

namespace exercicio
{
    public class Mundo : Events.EventTrigger
    {
        private readonly List<Poligono> poligonos = new List<Poligono>();
        private Poligono poligonoSelecionado = null;
        private bool isControlClicked = false;

        private PoligonoDrawer drawer = null;

        private Events.MousePosition currentMousePosition = null;

        public Mundo() => Events.Instance().Observe(this);

        public void Draw()
        {
            poligonos.ForEach(x => x.Draw());

            drawer?.Draw();

            poligonoSelecionado?.DrawBBox();
        }

        public void ObserveKey(Key key, Events.State state)
        {
            if (state.Equals(Events.State.OFF))
                return;


            isControlClicked = Key.ControlLeft.Equals(key);

            //Completa poligono
            if (Key.Space.Equals(key))
            {
                if (drawer != null)
                {
                    Poligono poligono = drawer.Complete();
                    poligonos.Add(poligono);
                    poligonoSelecionado = poligono;
                    drawer = null;
                }
            }

            //Mudar primitiva
            if (Key.P.Equals(key))
            {
                drawer?.ChangePrimitive();
                poligonoSelecionado?.ChangePrimitive();
            }


            //Remove o ultimo poligono selecionado
            if (Key.Delete.Equals(key))
            {
                poligonoSelecionado?.RemoverVerticeSelecionado();
                drawer = null;
            }

            //Remove seleçao
            if (Key.Escape.Equals(key))
            {
                poligonos.ForEach(it => it.UnselectVerticeSelecionado());
                poligonoSelecionado = null;
            }

            //Altera cor
            if (Key.R.Equals(key) || Key.G.Equals(key) || Key.B.Equals(key))
            {
                //Aumenta o vermelho
                if (Key.R.Equals(key))
                    poligonoSelecionado?.cor.IncRed();

                //Aumenta o verde
                if (Key.G.Equals(key))
                    poligonoSelecionado?.cor.IncGreen();

                //Aumenta o azul
                if (Key.B.Equals(key))
                    poligonoSelecionado?.cor.IncBlue();

                Console.WriteLine("Cor: " + key);
            }

            if (Key.Left.Equals(key) || Key.Right.Equals(key) || Key.Down.Equals(key) || Key.Up.Equals(key))
            {
                poligonoSelecionado?.MoverVerticeSelecionado(key);
            }

            //Adiciona o poligono que esta no ponteiro ao presionar o F como filho do poligono selecionado
            if (Key.F.Equals(key))
            {
                if (poligonoSelecionado != null && currentMousePosition != null)
                {
                    Poligono poligonoFilho = Helper.GetPoligonoSelecionado(poligonos, currentMousePosition);
                    if(poligonoFilho != null)
                    {
                        poligonoSelecionado.AddFilho(poligonoFilho);
                        poligonos.Remove(poligonoFilho);
                    }
                }
            }

        }

        public void ObserveMouseButtomLeft(Events.State state, Events.MousePosition mousePosition)
        {

            if (poligonoSelecionado == null && drawer == null)
            {
                if (state.Equals(Events.State.ON))
                {
                    poligonoSelecionado = Helper.GetPoligonoSelecionado(poligonos, mousePosition);
                    Console.WriteLine("Mouse Left " + mousePosition.ToString());
                }
            }

            //Console.WriteLine("Mouse Left " + mousePosition.ToString());

        }

        public void ObserveMouseButtomRight(Events.State state, Events.MousePosition mousePosition)
        {
            //Console.WriteLine("Mouse Right " + mousePosition.ToString());
            if (poligonoSelecionado == null)
            {
                if (drawer == null)
                    drawer = new PoligonoDrawer();

                if (state.Equals(Events.State.ON))
                    drawer.AddVertice(mousePosition.X, mousePosition.Y);

            }
        }

        public void ObserveMouseMove(Events.MousePosition mousePosition)
        {
            //Console.WriteLine("Mouse Move " + mousePosition.ToString());
            drawer?.MoveToMouse(mousePosition.X, mousePosition.Y);
            currentMousePosition = mousePosition;
        }
    }
}
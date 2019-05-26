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
            List<Poligono> toRemove = new List<Poligono>();
            poligonos.ForEach(it =>
            {
                if (it.CountVertices() > 0)
                    it.Draw();
                else
                    toRemove.Add(it);
            });

            toRemove.ForEach(it => poligonos.Remove(it));

            drawer?.Draw();

            poligonoSelecionado?.DrawBBox();
        }

        public void ObserveKey(Key key, Events.State state)
        {
            if (state.Equals(Events.State.OFF))
                return;

            switch (key)
            {
                //Completa poligono
                case Key.Space:
                    if (drawer != null)
                    {
                        Poligono poligono = drawer.Complete();
                        poligonos.Add(poligono);
                        poligonoSelecionado = poligono;
                        drawer = null;
                    }
                    break;
                //Mudar primitiva
                case Key.P:
                    drawer?.ChangePrimitive();
                    poligonoSelecionado?.ChangePrimitive();
                    break;
                //Remove o poligono selecionado
                case Key.X:
                    if (poligonoSelecionado != null)
                    {
                        poligonos.Remove(poligonoSelecionado);
                        poligonoSelecionado = null;
                    }
                    break;
                //Remove o vertice selecionado
                case Key.Delete:
                    poligonoSelecionado?.RemoverVerticeSelecionado();
                    drawer = null;
                    break;
                //Remove seleçao
                case Key.Escape:
                    poligonos.ForEach(it => it.UnselectVerticeSelecionado());
                    poligonoSelecionado = null;
                    break;
                //Altera cor
                case Key.R:
                case Key.G:
                case Key.B:
                    //Aumenta o vermelho
                    if (Key.R.Equals(key))
                        poligonoSelecionado?.cor.IncRed();

                    //Aumenta o verde
                    if (Key.G.Equals(key))
                        poligonoSelecionado?.cor.IncGreen();

                    //Aumenta o azul
                    if (Key.B.Equals(key))
                        poligonoSelecionado?.cor.IncBlue();
                    break;
                //Mover vertice selecionado
                case Key.Left:
                case Key.Right:
                case Key.Down:
                case Key.Up:
                    poligonoSelecionado?.MoverVerticeSelecionado(key);
                    break;
                //Adiciona o poligono que esta no ponteiro ao presionar o F como filho do poligono selecionado
                case Key.F:
                    if (poligonoSelecionado != null && currentMousePosition != null)
                    {
                        Poligono poligonoFilho = Helper.GetPoligonoSelecionado(poligonos, currentMousePosition);
                        if (poligonoFilho != null)
                        {
                            poligonoSelecionado.AddFilho(poligonoFilho);
                            poligonos.Remove(poligonoFilho);
                        }
                    }
                    break;
                //Reseta matriz
                case Key.I:
                    poligonoSelecionado?.atribuirIdentidade();
                    break;
                //Translação
                case Key.W:
                case Key.A:
                case Key.S:
                case Key.D:
                    if (Key.W.Equals(key))
                        poligonoSelecionado?.translacaoXYZ(0, 10, 0);
                    if (Key.A.Equals(key))
                        poligonoSelecionado?.translacaoXYZ(-10, 0, 0);
                    if (Key.S.Equals(key))
                        poligonoSelecionado?.translacaoXYZ(0, -10, 0);
                    if (Key.D.Equals(key))
                        poligonoSelecionado?.translacaoXYZ(10, 0, 0);
                    break;
                //Escala
                case Key.PageUp:
                case Key.PageDown:
                    if (Key.PageUp.Equals(key))
                        poligonoSelecionado?.escalaXYZ(2);
                    if (Key.PageDown.Equals(key))
                        poligonoSelecionado?.escalaXYZ(0.5);
                    break;
                //Rotacionar
                case Key.Number4:
                case Key.Number6:
                    if (Key.Number4.Equals(key))
                        poligonoSelecionado?.rotacaoZ(10);
                    if (Key.Number6.Equals(key))
                        poligonoSelecionado?.rotacaoZ(-10);
                    break;
                    /*
                    if (e.Key == Key.Number3)
                        objeto_2.rotacaoZPtoFixo(10, new CG_Biblioteca.Ponto4D(-150, -150));
                    else
if (e.Key == Key.Number4)
                        objeto_2.rotacaoZPtoFixo(-10, new CG_Biblioteca.Ponto4D(-150, -150));

                    if (e.Key == Key.Home)
                        objeto_2.escalaXYZPtoFixo(0.5, new CG_Biblioteca.Ponto4D(-150, -150));
                    else
if (e.Key == Key.End)
                        objeto_2.escalaXYZPtoFixo(2, new CG_Biblioteca.Ponto4D(-150, -150));
                        */
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
using System.Collections.Generic;
using OpenTK.Input;

namespace exercicio
{
    public class Mundo : Events.EventTrigger
    {
        private readonly List<Poligono> poligonos = new List<Poligono>();
        private Poligono poligonoSelecionado = null;
        private bool ehPonto = false;

        private PoligonoDrawer drawer = null;

        public Mundo() => Events.Instance().Observe(this);

        public void Draw()
        {
            poligonos.ForEach(x => x.Draw());

            if (drawer != null)
                drawer.Draw();

            if(poligonoSelecionado != null)
                poligonoSelecionado.DrawBBox();
        }

        public void ObserveKey(Key key, Events.State state)
        {
            if (state.Equals(Events.State.OFF))
                return;

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

            //Remove o ultimo poligono selecionado
            if (Key.Delete.Equals(key))
            {
                if (poligonoSelecionado != null)
                {
                    poligonos.Remove(poligonoSelecionado);
                    poligonoSelecionado = null;
                }
            }

            if (Key.Escape.Equals(key))
            {
                poligonoSelecionado = null;
            }

        }

        public void ObserveMouseButtomLeft(Events.State state, Events.MousePosition mousePosition)
        {
            //Console.WriteLine("Mouse Left " + mousePosition.ToString());
            if(poligonoSelecionado == null)
            {
                if (drawer == null)
                    drawer = new PoligonoDrawer();

                if (state.Equals(Events.State.ON))
                    drawer.AddVertice(mousePosition.X, mousePosition.Y);
            }
        }

        public void ObserveMouseButtomRight(Events.State state, Events.MousePosition mousePosition)
        {
            //Console.WriteLine("Mouse Right " + mousePosition.ToString());
        }

        public void ObserveMouseMove(Events.MousePosition mousePosition)
        {
            //Console.WriteLine("Mouse Move " + mousePosition.ToString());
            if (drawer != null)
            {
                drawer.MoveToMouse(mousePosition.X, mousePosition.Y);
            }
        }
    }
}
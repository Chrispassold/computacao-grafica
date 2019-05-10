using System.Collections.Generic;
using OpenTK.Input;
using System;

namespace exercicio
{
    public class Mundo : Events.EventTrigger
    {
        private readonly List<Poligono> poligonos = new List<Poligono>();
        private Poligono ultimoPoligonoSelecionado = null;
        private bool ehPonto = false;
        private Events events;


        private bool drawing = false;
        private PoligonoDrawer drawer = null;

        public Mundo()
        {
            events = Events.Instance();
            events.Observe(this);
        }

        public void Desenha()
        {
            poligonos.ForEach(x => x.Desenha());

            if (drawer != null)
                drawer.Desenha();
        }

        public void ObserveKey(Key key, Events.State state)
        {
        }

        public void ObserveMouseButtomLeft(Events.State state, Events.MousePosition mousePosition)
        {
            Console.WriteLine("Mouse Left " + mousePosition.ToString());
            if (drawer == null)
                drawer = new PoligonoDrawer();

            drawer.AddVertice(mousePosition.X, mousePosition.Y);
        }

        public void ObserveMouseButtomRight(Events.State state, Events.MousePosition mousePosition)
        {
            Console.WriteLine("Mouse Right " + mousePosition.ToString());
        }

        public void ObserveMouseMove(Events.MousePosition mousePosition)
        {
            Console.WriteLine("Mouse Move " + mousePosition.ToString());
            if (drawer != null)
            {
                drawer.MoveToMouse(mousePosition.X, mousePosition.Y);
            }
        }
    }
}
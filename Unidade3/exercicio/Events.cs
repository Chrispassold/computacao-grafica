using OpenTK.Input;
using System.Collections.Generic;

namespace exercicio
{
    public class Events
    {

        public enum State
        {
            ON,
            OFF
        }

        public enum SideButtom
        {
            LEFT,
            RIGHT
        }

        public class MousePosition
        {
            public int X { get; set; }
            public int Y { get; set; }

            public MousePosition(MouseButtonEventArgs e)
            {
                Camera camera = Camera.Instance();
                X = e.X;
                Y = ((int)camera.ymax) - e.Y;
            }

            public MousePosition(MouseMoveEventArgs e)
            {
                Camera camera = Camera.Instance();
                X = e.X;
                Y = ((int)camera.ymax) - e.Y;
            }

            public MousePosition(int x, int y)
            {
                Camera camera = Camera.Instance();
                X = x;
                Y = ((int)camera.ymax) - y;
            }

            public override string ToString()
            {
                return string.Format("x: {0} | y: {1}", X, Y);
            }
        }

        public interface EventTrigger
        {
            void ObserveKey(Key key, State state);
            void ObserveMouseMove(MousePosition mousePosition);
            void ObserveMouseButtomLeft(State state, MousePosition mousePosition);
            void ObserveMouseButtomRight(State state, MousePosition mousePosition);
        }

        private readonly List<EventTrigger> observables = new List<EventTrigger>();
        private static Events instance = null;

        private Events() { }

        public static Events Instance()
        {
            if (instance == null)
                instance = new Events();

            return instance;
        }

        public void Observe(EventTrigger eventTrigger)
        {
            if (eventTrigger != null)
                observables.Add(eventTrigger);
        }

        public void OnMousePressChange(MouseButtonEventArgs e)
        {
            State state = e.IsPressed ? State.ON : State.OFF;

            if (e.Mouse.IsButtonDown(MouseButton.Left))
                observables.ForEach(it => it.ObserveMouseButtomLeft(state, new MousePosition(e)));
            else if (e.Mouse.IsButtonDown(MouseButton.Right))
                observables.ForEach(it => it.ObserveMouseButtomRight(state, new MousePosition(e)));
        }

        public void OnMouseMove(int x, int y)
        {
            observables.ForEach(it => it.ObserveMouseMove(new MousePosition(x, y)));
        }

        public void OnKeyPressChange(Key key, State state)
        {
            observables.ForEach(it => it.ObserveKey(key, state));
        }

    }
}

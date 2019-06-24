using OpenTK.Input;
using System.Collections.Generic;

namespace TrabalhoFinal
{
    class Commands : InputObservable.InputObserver
    {

        public interface CommandsListener
        {
            void OnLeft();
            void OnRight();
            void OnEscape();
        }

        private static Commands instance = null;

        private List<CommandsListener> listeners = new List<CommandsListener>();

        private Commands() => InputObservable.Instance().Observe(this);

        public static Commands Instance()
        {
            if (instance == null)
                instance = new Commands();

            return instance;
        }

        public void ListenCommands(CommandsListener listener)
        {
            if (listener != null && !listeners.Contains(listener))
                listeners.Add(listener);
        }

        public void ObserveKey(Key key)
        {
            switch (key)
            {
                case Key.Left:
                    listeners.ForEach(it => it.OnLeft());
                    break;
                case Key.Right:
                    listeners.ForEach(it => it.OnRight());
                    break;
                case Key.Escape:
                    listeners.ForEach(it => it.OnEscape());
                    break;
            }
        }


    }
}

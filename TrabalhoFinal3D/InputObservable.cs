using OpenTK.Input;
using System.Collections.Generic;

namespace TrabalhoFinal3D
{
    class InputObservable
    {

        private readonly List<InputObserver> observables = new List<InputObserver>();
        private static InputObservable instance = null;

        private InputObservable() { }

        public static InputObservable Instance()
        {
            if (instance == null)
                instance = new InputObservable();

            return instance;
        }

        /// <summary>
        /// Contract para o trigger
        /// </summary>
        public interface InputObserver
        {
            void ObserveKey(Key key);
        }

        /// <summary>
        /// Adiciona um observable
        /// </summary>
        /// <param name="inputTrigger">Observador</param>
        public void Observe(InputObserver inputTrigger)
        {
            if (inputTrigger != null && !observables.Contains(inputTrigger))
                observables.Add(inputTrigger);
        }

        /// <summary>
        /// Envia um evento para todos os observadores quando uma tecla é pressionada
        /// </summary>
        /// <param name="key">Tecla</param>
        public void OnKeyPressChange(Key key)
        {
            observables.ForEach(it => it.ObserveKey(key));
        }

    }
}

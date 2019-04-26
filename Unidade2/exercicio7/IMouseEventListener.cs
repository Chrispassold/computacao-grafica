using OpenTK.Input;
namespace exercicio7
{
    public interface IMouseEventListener
    {
        void OnMouseKeyDown(MouseButtonEventArgs e);
        void OnMouseKeyUp(MouseButtonEventArgs e);
        void OnMouseMove(MouseMoveEventArgs e);
    }
}
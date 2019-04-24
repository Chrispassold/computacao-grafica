using OpenTK.Input;
namespace exercicio7
{
    public interface IKeyDownListener
    {
         void OnKeyPressed(KeyboardKeyEventArgs key);
    }
}
using OpenTK.Input;
namespace exercicio6
{
    public interface IKeyDownListener
    {
         void OnKeyPressed(KeyboardKeyEventArgs key);
    }
}
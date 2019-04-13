using OpenTK.Input;
namespace exercicio5
{
    public interface IKeyDownListener
    {
         void OnKeyPressed(KeyboardKeyEventArgs key);
    }
}
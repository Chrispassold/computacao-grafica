using System.Drawing;
namespace exercicio
{
    public class Cor
    {
        private int Red { get; set; } = 0;
        private int Green { get; set; } = 0;
        private int Blue { get; set; } = 0;

        private int factor = 5;

        public void IncRed()
        {
            if (Red < 255)
                Red += factor;
        }
        public void IncGreen()
        {
            if (Green < 255)
                Green += factor;
        }
        public void IncBlue()
        {
            if (Blue < 255)
                Blue += factor;
        }

        public Color GetColor() => Color.FromArgb(Red, Green, Blue);

    }
}

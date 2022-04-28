using System;

namespace Trabalho
{
    class Mapa
    {
        private int[] size = new int[2];

        public Mapa(int sizeX, int sizeY)
        {
            this.size[0] = sizeX;
            this.size[1] = sizeY;
        }

        public void TamanhoConsole()
        {
            Console.SetBufferSize(this.size[0], this.size[1]);
            Console.SetWindowSize(this.size[0], this.size[1]);
            Console.CursorVisible = false;
        }

        public void DesenharMapa()
        {
            for (int i = 0; i < size[1]; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(0, i);
                Console.Write("■");
                Console.SetCursorPosition(size[0] - 1, i);
                Console.Write("■");
            }
        }
    }
}

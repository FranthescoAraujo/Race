using System;

namespace Trabalho
{
    class Inimigo
    {
        private Random rnd = new Random();
        private int velocidade;
        private string limparCarro = "         ";
        private string[] layoutCarro = new string[] { "  0___0  " ,
                                                      " | ___ | " ,
                                                      "| |   | |" ,
                                                      "| |___| |" ,
                                                      " |     | " ,
                                                      " |_____| " ,
                                                      "  00 00  " };
        private bool[] isPrint = new bool[] { false, false, false, false, false, false, false };
        public int[] position = new int[] { 0, -7 };
        public int[] limiteY = new int[] { 0, Console.WindowHeight - 7 };
        public int[,] collider;

        public Inimigo(int posX)
        {
            this.position[0] = posX;
            this.velocidade = this.rnd.Next(1, 4);
            this.collider = new int[,] { { position[0], position[0] + 8 }, { position[1], position[1] + 6 } };
        }

        public void MostrarCarro()
        {
            for (int i = 0; i < this.isPrint.Length; i++)
            {
                if (this.isPrint[i])
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(this.position[0], this.position[1] + i);
                    Console.Write(this.layoutCarro[i]);
                }
            }
        }

        public void ApagarCarro()
        {
            for (int i = 0; i < this.velocidade; i++)
            {
                if (this.position[1] + i >= this.limiteY[0])
                {
                    if (this.position[1] + i >= this.limiteY[1] + 7)
                    {
                        break;
                    }
                    else {
                        Console.SetCursorPosition(this.position[0], this.position[1] + i);
                        Console.Write(this.limparCarro);
                    }
                }
            }
        }

        public void ApagarCarroInteiro()
        {
            for (int i = 0; i < layoutCarro.Length; i++)
            {
                if (isPrint[i] == true)
                {
                    Console.SetCursorPosition(this.position[0], this.position[1] + i);
                    Console.Write(this.limparCarro);
                }
            }
        }

        public void Andar()
        {
            for (int i = 1; i <= this.velocidade; i++)
            {
                this.position[1]++;
                this.collider[1, 0] = this.position[1];
                this.collider[1, 1] = this.position[1] + 6;
                if (this.position[1] <= this.limiteY[0])
                {
                    int dif = this.isPrint.Length - (this.limiteY[0] - this.position[1]);
                    for (int j = 1; j <= dif; j++)
                    {
                        this.isPrint[this.isPrint.Length - j] = true;
                    }
                }

                if (this.position[1] > this.limiteY[1])
                {
                    int dif = this.position[1] - this.limiteY[1];
                    for (int j = 1; j <= dif; j++)
                    {
                        this.isPrint[this.isPrint.Length - j] = false;
                    }
                }
                
                if (this.position[1] > this.limiteY[1] + this.layoutCarro.Length - 1)
                {
                    this.position[1] = -10;

                }
            }
        }
    }
}

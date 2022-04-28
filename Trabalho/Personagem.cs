using System;

namespace Trabalho
{
    class Personagem
    {
        private string limparCarro = "         ";
        private string[] layoutCarro = new string[] { "  0_|_0  " ,
                                                      " |     | " ,
                                                      " | ___ | " ,
                                                      "| |   | |" ,
                                                      "| |___| |" ,
                                                      " |_____| " ,
                                                      "  0   0  " };
        private int[] position = new int[] { 1, Console.WindowHeight - 7 };
        private int[] limiteX = new int[] { 1, Console.WindowWidth - 1 - 9 };
        private int[] limiteY = new int[] { 0, Console.WindowHeight - 7 };
        private int[] posicaoTiroAux = new int[2];
        public int[,] posicaoTiro = new int[2,4] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
        private GerenciaTempo tempo = new GerenciaTempo();
        public GerenciaTempo tempoAtirar = new GerenciaTempo();
        public int[,] collider;

        public Personagem()
        {
            this.collider = new int[2,2] { {this.position[0], this.position[0] + 8 }, {this.position[1], this.position[1] + 6 } };
        }

        public void MostrarCarro()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            for (int i = 0; i < this.layoutCarro.Length; i++)
            {
                Console.SetCursorPosition(this.position[0], this.position[1] + i);
                Console.Write(this.layoutCarro[i]);
            }
        }

        public void ApagarCarro()
        {
            for (int i = 0; i < this.layoutCarro.Length; i++)
            {
                Console.SetCursorPosition(this.position[0], this.position[1] + i);
                Console.Write(this.limparCarro);
            }
        }

        public void Atirar(ConsoleKeyInfo cki)
        {
            switch (cki.Key)
            {
                case ConsoleKey.Z:
                    if (tempoAtirar.deltaTime >= 300)
                    {
                        this.posicaoTiroAux[0] = this.position[0] + 4;
                        this.posicaoTiroAux[1] = this.position[1] - 1;
                        tempoAtirar.deltaTime = 0;
                    }
                    break;
            }
        }

        public void MostrarTiro()
        { 
            if (tempo.deltaTime >= 20)
            {
                OrganizaVetorTiro();
                for (int i = 0; i < this.posicaoTiro.GetLength(1); i++)
                {
                    if  (this.posicaoTiro[0, i] != 0 || this.posicaoTiro[1, i] != 0)
                    {
                        if (this.posicaoTiro[1, i] < limiteY[0])
                        {
                            Console.SetCursorPosition(this.posicaoTiro[0, i], this.posicaoTiro[1, i] + 1);
                            Console.Write(" ");
                            this.posicaoTiro[0, i] = 0;
                            this.posicaoTiro[1, i] = 0;
                        }
                        else
                        {
                            Console.SetCursorPosition(this.posicaoTiro[0, i], this.posicaoTiro[1, i] + 1);
                            Console.Write(" ");
                            Console.SetCursorPosition(this.posicaoTiro[0, i], this.posicaoTiro[1, i]);
                            Console.Write("o");
                            this.posicaoTiro[1, i]--;
                            tempo.deltaTime = 0;
                        }
                    }
                }
            }
            else
            {
                tempo.Tempo();
            }
        }

        public void ApagarTiro(int posY)
        {
            Console.SetCursorPosition(this.posicaoTiro[0, posY], this.posicaoTiro[1, posY] + 1);
            Console.Write(" ");
        }

        public void OrganizaVetorTiro()
        {
            if (this.posicaoTiroAux[0] != 0 || this.posicaoTiroAux[1] != 0)
            {
                for (int i = 0; i < this.posicaoTiro.GetLength(1); i++)
                {
                    if (this.posicaoTiro[0, i] == 0 && this.posicaoTiro[1, i] == 0)
                    {
                        this.posicaoTiro[0, i] = this.posicaoTiroAux[0];
                        this.posicaoTiro[1, i] = this.posicaoTiroAux[1];
                        this.posicaoTiroAux[0] = 0;
                        this.posicaoTiroAux[1] = 0;
                        break;
                    }
                }
            }
        }

        public void Andar(ConsoleKeyInfo cki)
        {
            switch (cki.Key)
            {
                case ConsoleKey.UpArrow:
                    if (this.position[1] > this.limiteY[0])
                    {
                        this.position[1]--;
                        this.collider[1, 0]--;
                        this.collider[1, 1]--;
                        break;
                    }
                    break;

                case ConsoleKey.RightArrow:
                    if (this.position[0] < this.limiteX[1])
                    {
                        this.position[0]++;
                        this.collider[0, 0]++;
                        this.collider[0, 1]++;
                        break;
                    }
                    break;


                case ConsoleKey.DownArrow:
                    if (this.position[1] < this.limiteY[1])
                    {
                        this.position[1]++;
                        this.collider[1, 0]++;
                        this.collider[1, 1]++;
                        break;
                    }
                    break;

                case ConsoleKey.LeftArrow:
                    if (this.position[0] > this.limiteX[0])
                    {
                        this.position[0]--;
                        this.collider[0, 0]--;
                        this.collider[0, 1]--;
                        break;
                    }
                    break;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;

namespace Trabalho
{
    class GerenciaJogo
    {
        private List<Inimigo> inimigos = new List<Inimigo>();
        private int numInimigos = 70;
        private Random rnd = new Random();
        private int[] limiteX = new int[] { 10, Console.WindowWidth - 1 - 9 };
        private int espaco = 7;
        private int[] carrosCampo = new int[7];
        private GerenciaTempo tempo = new GerenciaTempo();
        public Personagem personagem = new Personagem();
        public Menu menu;
        public Mapa mapa;
        private bool gameOver = false;

        public GerenciaJogo(int sizeX, int sizeY)
        {
            this.menu = new Menu(sizeX, sizeY);
            this.mapa = new Mapa(sizeX, sizeY);
        }

        public void Criar()
        {
            for (int i = 0; i < this.espaco; i++)
            {
                for (int j = 1; j <= this.numInimigos/this.espaco; j++)
                {
                    this.inimigos.Add(new Inimigo(this.rnd.Next((this.numInimigos / this.espaco + 3*i* this.numInimigos / this.espaco), (this.numInimigos / this.espaco + 3 * i * this.numInimigos / this.espaco + ((limiteX[1]-limiteX[0])/10)))));
                }
                carrosCampo[i] = this.rnd.Next((i*this.numInimigos / this.espaco), ((i+1)*this.numInimigos / this.espaco-1));
            }
        }

        public void MostrarInimigo()
        {
            if (tempo.deltaTime >= 25)
            {
                for (int i = 0; i < carrosCampo.Length; i++)
                {
                    inimigos[carrosCampo[i]].ApagarCarro();
                    inimigos[carrosCampo[i]].Andar();
                    inimigos[carrosCampo[i]].MostrarCarro();

                    if (inimigos[carrosCampo[i]].position[1] < -7)
                    {
                        inimigos[carrosCampo[i]].position[1] = -7;
                        carrosCampo[i] = this.rnd.Next((i * this.numInimigos / this.espaco), ((i + 1) * this.numInimigos / this.espaco - 1));
                    }
                }
                tempo.deltaTime = 0;
            }
            else
            {
                tempo.Tempo();
            }
        }

        public void ColisorTiro()
        {
            for (int i = 0; i < personagem.posicaoTiro.GetLength(1); i++)
            {
                for (int j = 0; j < carrosCampo.Length; j++)
                {
                    if (personagem.posicaoTiro[0, i] >= inimigos[carrosCampo[j]].collider[0,0] && personagem.posicaoTiro[0, i] <= inimigos[carrosCampo[j]].collider[0, 1])
                    {
                        if (personagem.posicaoTiro[1, i] >= inimigos[carrosCampo[j]].collider[1, 0] && personagem.posicaoTiro[1, i] <= inimigos[carrosCampo[j]].collider[1, 1])
                        {
                            inimigos[carrosCampo[j]].ApagarCarroInteiro();
                            personagem.ApagarTiro(i);
                            menu.score++;
                            inimigos[carrosCampo[j]] = new Inimigo(inimigos[carrosCampo[j]].position[0]);
                            carrosCampo[j] = this.rnd.Next((j * this.numInimigos / this.espaco), ((j + 1) * this.numInimigos / this.espaco - 1));
                            personagem.posicaoTiro[0, i] = 0;
                            personagem.posicaoTiro[1, i] = 0;
                        }
                    }
                }
            }
        }

        public bool ColisorCarro()
        {
            foreach (Inimigo inimigo in this.inimigos)
            {
                if (this.personagem.collider[0, 0] >= inimigo.collider[0, 0] && this.personagem.collider[0, 0] <= inimigo.collider[0, 1])
                {
                    if (this.personagem.collider[1, 0] >= inimigo.collider[1, 0] && this.personagem.collider[1, 0] <= inimigo.collider[1, 1])
                    {
                        return this.gameOver = true;
                    }
                }

                if (this.personagem.collider[0, 1] >= inimigo.collider[0, 0] && this.personagem.collider[0, 1] <= inimigo.collider[0, 1])
                {
                    if (this.personagem.collider[1, 0] >= inimigo.collider[1, 0] && this.personagem.collider[1, 0] <= inimigo.collider[1, 1])
                    {
                        return this.gameOver = true;
                    }
                }

                if (this.personagem.collider[0, 0] >= inimigo.collider[0, 0] && this.personagem.collider[0, 0] <= inimigo.collider[0, 1])
                {
                    if (this.personagem.collider[1, 1] >= inimigo.collider[1, 0] && this.personagem.collider[1, 1] <= inimigo.collider[1, 1])
                    {
                        return this.gameOver = true;
                    }
                }

                if (this.personagem.collider[0, 1] >= inimigo.collider[0, 0] && this.personagem.collider[0, 1] <= inimigo.collider[0, 1])
                {
                    if (this.personagem.collider[1, 1] >= inimigo.collider[1, 0] && this.personagem.collider[1, 1] <= inimigo.collider[1, 1])
                    {
                        return this.gameOver = true;
                    }
                }




            }
            return this.gameOver;
        }

        public void LerTxt(string PATH = "rank.txt")
        {
            if (!File.Exists(PATH))
            {
                StreamWriter sw = new StreamWriter(PATH);
                sw.Close();
                return;
            }
            int aux = 0;
            StreamReader sr = new StreamReader(PATH);
            while (true)
            {
                string verificaString = sr.ReadLine();
                if (verificaString == null) break;
                this.menu.rankNames[aux] = verificaString.Split()[0];
                this.menu.rankScore[aux] = int.Parse(verificaString.Split()[1]);
                aux++;
            }
            sr.Close();
        }

        public void EscreverTxt(string PATH = "rank.txt")
        {
            int aux = -1;
            for (int i = this.menu.rankNames.Length - 1; i >= 0; i--)
            {
                if (this.menu.score<this.menu.rankScore[i])
                {
                    break;
                }
                aux = this.menu.rankNames.Length - i;
            }
            for (int i = 1; i <= aux; i++)
            {
                if (i == aux)
                {
                    this.menu.rankNames[this.menu.rankNames.Length - i] = this.menu.nome;
                    this.menu.rankScore[this.menu.rankNames.Length - i] = this.menu.score;
                    break;
                }
                this.menu.rankNames[this.menu.rankNames.Length - i] = this.menu.rankNames[this.menu.rankNames.Length - (i + 1)];
                this.menu.rankScore[this.menu.rankNames.Length - i] = this.menu.rankScore[this.menu.rankNames.Length - (i + 1)];
            }
            StreamWriter sw = new StreamWriter(PATH);
            for (int i = 0; i < this.menu.rankNames.Length; i++)
            {
                sw.WriteLine(this.menu.rankNames[i] + " " + this.menu.rankScore[i].ToString());
            }
            sw.Close();
        }
    }
}

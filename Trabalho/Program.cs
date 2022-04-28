using System;

namespace Trabalho
{
    class Program
    {
        static ConsoleKeyInfo cki;
        static void Main(string[] args)
        {
            GerenciaJogo gerenciaJogo = new GerenciaJogo(Console.LargestWindowWidth, Console.LargestWindowHeight);
            gerenciaJogo.LerTxt();
            gerenciaJogo.mapa.TamanhoConsole();
            gerenciaJogo.menu.MenuInicio(cki);
            gerenciaJogo.mapa.DesenharMapa();
            gerenciaJogo.Criar();
            do
            {
                if (Console.KeyAvailable)
                {
                    cki = Console.ReadKey(true);
                    gerenciaJogo.personagem.ApagarCarro();
                    gerenciaJogo.personagem.Andar(cki);
                    gerenciaJogo.personagem.Atirar(cki);
                }
                gerenciaJogo.personagem.tempoAtirar.Tempo();
                gerenciaJogo.personagem.MostrarCarro();
                gerenciaJogo.personagem.MostrarTiro();
                gerenciaJogo.MostrarInimigo();
                gerenciaJogo.menu.Score();
                gerenciaJogo.ColisorTiro();
                if (gerenciaJogo.ColisorCarro())
                {
                    gerenciaJogo.menu.GameOver();
                    break;
                }
            } while (cki.Key != ConsoleKey.Escape);
            gerenciaJogo.EscreverTxt();
        }
    }
}

using System;

namespace Trabalho
{
    class Menu
    {
        public string nome = "";
        private float[] size = new float[2];
        private int tamanho = 76;
        private int tamanhoGameOver = 160;
        public string[] rankNames = new string[] { "none", "none", "none", "none", "none", "none", "none", "none", "none", "none" };
        public int[] rankScore = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private string[] logoRace = new string[] {"                                                             _____   ",
                                                  "___________           _____                 _____       _____\\    \\  ",
                                                  "\\          \\        /      |_          _____\\    \\_    /    / |    | ",
                                                  " \\    /\\    \\      /         \\        /     /|     |  /    /  /___/| ",
                                                  "  |   \\_\\    |    |     /\\    \\      /     / /____/| |    |__ |___|/ ",
                                                  "  |      ___/     |    |  |    \\    |     | |____|/  |       \\       ",
                                                  "  |      \\  ____  |     \\/      \\   |     |  _____   |     __/ __    ",
                                                  " /     /\\ \\/    \\ |\\      /\\     \\  |\\     \\|\\    \\  |\\    \\  /  \\   ",
                                                  "/_____/ |\\______| | \\_____\\ \\_____\\ | \\_____\\|    |  | \\____\\/    |  ",
                                                  "|     | | |     | | |     | |     | | |     /____/|  | |    |____/|  ",
                                                  "|_____|/ \\|_____|  \\|_____|\\|_____|  \\|_____|    ||   \\|____|   | |  ",
                                                  "                                            |____|/         |___|/   "};

        private string[] logoCarro = new string[] {"                                              _____________                ",
                                                   "                                  ..---:::::::-----------. ::::;;.         ",
                                                   "                               .'\"\"\"\"\"\"                  ;;   \\  \":.       ",
                                                   "                            .''                          ;     \\   \"\\__.   ",
                                                   "                          .'                            ;;      ;   \\\\\";   ",
                                                   "                        .'                              ;   _____;   \\\\/   ",
                                                   "                      .'                               :; ;\"     \\ ___:'.  ",
                                                   "                    .'--...........................    : =   ____:\"    \\ \\ ",
                                                   "               ..-\"\"                               \"\"\"'  o\"\"\"     ;     ; :",
                                                   "          .--\"\"  .----- ..----...    _.-    --.  ..-\"     ;       ;     ; ;",
                                                   "       .\"\"_-     \"--\"\"-----'\"\"    _-\"        .-\"\"         ;        ;    .-.",
                                                   "    .'  .'                      .\"         .\"              ;       ;   /. |",
                                                   "   /-./'                      .\"          /           _..  ;       ;   ;;;|",
                                                   "  :  ;-.______               /       _________==.    /_  \\ ;       ;   ;;;;",
                                                   "  ;  / |      \"\"\"\"\"\"\"\"\"\"\".---.\"\"\"\"\"\"\"          :    /\" \". |;       ; _; ;;;",
                                                   " /\"-/  |                /   /                  /   /     ;|;      ;-\" | ;';",
                                                   ":-  :   \"\"\"----______  /   /              ____.   .  .\"'. ;;   .-\"..T\"   . ",
                                                   "'. \"  ___            \"\":   '\"\"\"\"\"\"\"\"\"\"\"\"\"\"    .   ; ;    ;; ;.\" .\"   '--\"  ",
                                                   " \",   __ \"\"\"  \"\"---... :- - - - - - - - - ' '  ; ;  ;    ;;\"  .\"           ",
                                                   "  /. ;  \"\"\"---___                             ;  ; ;     ;|.\"\"             ",
                                                   " :  \":           \"\"\"----.    .-------.       ;   ; ;     ;:                ",
                                                   "  \\  '--__               \\   \\        \\     /    | ;     ;;                ",
                                                   "   '-..   \"\"\"\"---___      :   .______..\\ __/..-\"\"|  ;   ; ;                ",
                                                   "       \"\"--..       \"\"\"--\"                      .   \". . ;                 ",
                                                   "             \"\"------...                  ..--\"\"      \" :                  ",
                                                   "                        \"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"\"    \\        /                   ",
                                                   "                                               \"------\"                     "};

        private string[] gameOver = new string[] {"                                                                           _____                                                      _____                     ",
                                                  "        _____            _____                 ___________            _____\\    \\                ____      _______    ______     _____\\    \\  ___________       ",
                                                  "   _____\\    \\_        /      |_              /           \\          /    / |    |           ____\\_  \\__   \\      |  |      |   /    / |    | \\          \\      ",
                                                  "  /     /|     |      /         \\            /    _   _    \\        /    /  /___/|          /     /     \\   |     /  /     /|  /    /  /___/|  \\    /\\    \\     ",
                                                  " /     / /____/|     |     /\\    \\          /    //   \\\\    \\      |    |__ |___|/         /     /\\      |  |\\    \\  \\    |/  |    |__ |___|/   |   \\_\\    |    ",
                                                  "|     | |_____|/     |    |  |    \\        /    //     \\\\    \\     |       \\              |     |  |     |  \\ \\    \\ |    |   |       \\         |      ___/     ",
                                                  "|     | |_________   |     \\/      \\      /     \\\\_____//     \\    |     __/ __           |     |  |     |   \\|     \\|    |   |     __/ __      |      \\  ____  ",
                                                  "|\\     \\|\\        \\  |\\      /\\     \\    /       \\ ___ /       \\   |\\    \\  /  \\          |     | /     /|    |\\         /|   |\\    \\  /  \\    /     /\\ \\/    \\ ",
                                                  "| \\_____\\|    |\\__/| | \\_____\\ \\_____\\  /________/|   |\\________\\  | \\____\\/    |         |\\     \\_____/ |    | \\_______/ |   | \\____\\/    |  /_____/ |\\______| ",
                                                  "| |     /____/| | || | |     | |     | |        | |   | |        | | |    |____/|         | \\_____\\   | /      \\ |     | /    | |    |____/|  |     | | |     | ",
                                                  " \\|_____|     |\\|_|/  \\|_____|\\|_____| |________|/     \\|________|  \\|____|   | |          \\ |    |___|/        \\|_____|/      \\|____|   | |  |_____|/ \\|_____| ",
                                                  "        |____/                                                            |___|/            \\|____|                                  |___|/                     "};
        private string[] rank = new string[] {"___________          _____        _____    _____     ______   _______            ",
                                              "\\          \\       /      |_     |\\    \\   \\    \\   |\\     \\  \\      \\ ",
                                              " \\    /\\    \\     /         \\     \\\\    \\   |    |   \\\\     \\  |     /|",
                                              "  |   \\_\\    |   |     /\\    \\     \\\\    \\  |    |    \\|     |/     //   ",
                                              "  |      ___/    |    |  |    \\     \\|    \\ |    |     |     |_____//         ",
                                              "  |      \\  ____ |     \\/      \\     |     \\|    |     |     |\\     \\      ",
                                              " /     /\\ \\/    \\|\\      /\\     \\   /     /\\      \\   /     /|\\|     |  ",
                                              "/_____/ |\\______|| \\_____\\ \\_____\\ /_____/ /______/| /_____/ |/_____/|      ",
                                              "|     | | |     || |     | |     ||      | |     | ||     | / |    | |           ",
                                              "|_____|/ \\|_____| \\|_____|\\|_____||______|/|_____|/ |_____|/  |____|/         "};
        
        private string[] seta = new string[] {"                .   ",
                                             " .. ............;;.  ",
                                             "  ..::::::::::::;;;;.",
                                             ". . ::::::::::::;;:' ",
                                             "                :'   "};
        private string apagaSeta = "                     ";
        public int escolha = 0;
        private int apagaEscolha = 0;
        public int score = 0;

        public Menu(int sizeX, int sizeY)
        {
            this.size[0] = sizeX;
            this.size[1] = sizeY;
        }

        public void MenuInicio(ConsoleKeyInfo cki)
        {
            Console.Clear();
            this.escolha = 0;
            this.apagaEscolha = 0;
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < this.logoRace.Length; i++)
            {
                Console.SetCursorPosition((int)((this.size[0] - 2 * this.tamanho) / 2), 15 + i);
                Console.Write(this.logoRace[i]);
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            for (int i = 0; i < this.logoCarro.Length; i++)
            {
                Console.SetCursorPosition((int)((this.size[0] - 2 * this.tamanho) / 2 + this.tamanho), 15 + i);
                Console.Write(this.logoCarro[i]);
            }
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < seta.Length; i++)
            {
                Console.SetCursorPosition((int)((this.size[0] - 2 * this.tamanho) / 2 + 10), 27 + i);
                Console.Write(seta[i]);
            }

            Console.SetCursorPosition((int)((this.size[0] - this.tamanho) / 2), 29);
            Console.Write("Jogar");
            Console.SetCursorPosition((int)((this.size[0] - this.tamanho) / 2), 29 + 5);
            Console.Write("Rank");
            Console.SetCursorPosition((int)((this.size[0] - this.tamanho) / 2), 29 + 10);
            Console.Write("Sair");

            do
            {
                cki = Console.ReadKey(true);
                EscolhaInicio(cki);
            } while (cki.Key != ConsoleKey.Enter);

            switch (this.escolha)
            {
                case 0:
                    MenuIniciar(cki);
                    break;
                case 1:
                    MenuRank(cki);
                    break;
                case 2:
                    Console.Clear();
                    Environment.Exit(1);
                    break;
            }
        }

        private void MenuIniciar(ConsoleKeyInfo cki)
        {
            Console.Clear();
            this.escolha = 0;
            this.apagaEscolha = 0;
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < this.logoRace.Length; i++)
            {
                Console.SetCursorPosition((int)((this.size[0] - 2 * this.tamanho) / 2), 15 + i);
                Console.Write(this.logoRace[i]);
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            for (int i = 0; i < this.logoCarro.Length; i++)
            {
                Console.SetCursorPosition((int)((this.size[0] - 2 * this.tamanho) / 2 + this.tamanho), 15 + i);
                Console.Write(this.logoCarro[i]);
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition((int)((this.size[0] - 2 * this.tamanho) / 2), 15);
            Console.Write("Digite como deseja ser chamado: ");
            nome = Console.ReadLine();

            for (int i = 0; i < seta.Length; i++)
            {
                Console.SetCursorPosition((int)((this.size[0] - 2 * this.tamanho) / 2 + 10), 27 + i);
                Console.Write(seta[i]);
            }

            Console.SetCursorPosition((int)((this.size[0] - this.tamanho) / 2), 29);
            Console.Write("Iniciar");
            Console.SetCursorPosition((int)((this.size[0] - this.tamanho) / 2), 29 + 5);
            Console.Write("Voltar");
            Console.SetCursorPosition((int)((this.size[0] - this.tamanho) / 2), 29 + 10);
            Console.Write("Sair");

            do
            {
                cki = Console.ReadKey(true);
                EscolhaInicio(cki);
            } while (cki.Key != ConsoleKey.Enter);

            switch (this.escolha)
            {
                case 0:
                    Console.Clear();
                    break;
                case 1:
                    MenuInicio(cki);
                    break;
                case 2:
                    Console.Clear();
                    Environment.Exit(1);
                    break;
            }

        }

        private void MenuRank(ConsoleKeyInfo cki)
        {
            Console.Clear();
            this.escolha = 0;
            this.apagaEscolha = 0;
            for (int i = 0; i < this.rank.Length; i++)
            {
                Console.SetCursorPosition((int)((this.size[0] - this.tamanho) / 2), 5 + i);
                Console.Write(this.rank[i]);
            }

            Console.SetCursorPosition((int)((this.size[0] - this.tamanho) / 2), 29);
            Console.Write("Iniciar");
            Console.SetCursorPosition((int)((this.size[0] - this.tamanho) / 2), 29 + 5);
            Console.Write("Voltar");
            Console.SetCursorPosition((int)((this.size[0] - this.tamanho) / 2), 29 + 10);
            Console.Write("Sair");

            for (int i = 0; i < this.rankNames.Length; i++)
            {
                Console.SetCursorPosition((int)(this.size[0]/2), 29 + i);
                Console.Write(this.rankNames[i] + " " + this.rankScore[i].ToString());
            }

            for (int i = 0; i < seta.Length; i++)
            {
                Console.SetCursorPosition((int)((this.size[0] - 2 * this.tamanho) / 2 + 10), 27 + i);
                Console.Write(seta[i]);
            }

            do
            {
                cki = Console.ReadKey(true);
                EscolhaInicio(cki);
            } while (cki.Key != ConsoleKey.Enter);

            switch (this.escolha)
            {
                case 0:
                    MenuIniciar(cki);
                    break;
                case 1:
                    MenuInicio(cki);
                    break;
                case 2:
                    Console.Clear();
                    Environment.Exit(1);
                    break;
            }
        }

        private void EscolhaInicio(ConsoleKeyInfo cki)
        {
            switch (cki.Key)
            {
                case ConsoleKey.UpArrow:
                    if (escolha > 0)
                    {
                        escolha--;
                        for (int i = 0; i < seta.Length; i++)
                        {
                            Console.SetCursorPosition((int)((this.size[0] - 2 * this.tamanho) / 2 + 10), 5 * this.apagaEscolha + 27 + i);
                            Console.Write(apagaSeta);
                            Console.SetCursorPosition((int)((this.size[0] - 2 * this.tamanho) / 2 + 10), 5 * this.escolha + 27 + i);
                            Console.Write(seta[i]);
                        }
                        apagaEscolha = escolha;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (escolha < 2)
                    {
                        escolha++;
                        for (int i = 0; i < seta.Length; i++)
                        {
                            Console.SetCursorPosition((int)((this.size[0] - 2 * this.tamanho) / 2 + 10), 5 * this.apagaEscolha + 27 + i);
                            Console.Write(apagaSeta);
                            Console.SetCursorPosition((int)((this.size[0] - 2 * this.tamanho) / 2 + 10), 5 * this.escolha + 27 + i);
                            Console.Write(seta[i]);
                        }
                        apagaEscolha = escolha;
                    }
                    break;
            }
        }

        public void GameOver()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < this.gameOver.Length; i++)
            {
                Console.SetCursorPosition((int)((this.size[0] - this.tamanhoGameOver) / 2), 15 + i);
                Console.Write(this.gameOver[i]);
            }
            Console.SetCursorPosition((int)((this.size[0] - this.tamanhoGameOver) / 2), 29);
            Console.Write("Score: " + this.nome);
            Console.SetCursorPosition((int)((this.size[0] - this.tamanhoGameOver) / 2), 30);
            Console.Write("Score: " + this.score);
            Console.ReadKey();
            Console.Clear();
        }

        public void Score()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(2, 0);
            Console.Write(this.nome);
            Console.SetCursorPosition(2, 1);
            Console.Write("Score: " + this.score);
        }
    }
}

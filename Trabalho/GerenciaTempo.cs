using System;

namespace Trabalho
{
    class GerenciaTempo
    {
        private int tempoAnterior = 0;
        private int tempoAgora = 0;
        public int deltaTime = 0;

        public void Tempo()
        {
            this.tempoAnterior = DateTime.Now.Millisecond;
            if (this.tempoAgora != this.tempoAnterior)
            {
                this.deltaTime++;
                this.tempoAgora = DateTime.Now.Millisecond;
            }
        }
    }
}

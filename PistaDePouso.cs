using System;

namespace av2_sistemas_distribuidos
{
    public class PistaDePouso
    {
        private static int pistasCriadas = 0;

        public PistaDePouso(){
            pistasCriadas++;
            this.numero = pistasCriadas;
            this.emUso = false;
        }

        public int numero {get; set;}
        public bool emUso{get;set;}        
    }
}

using System;

namespace av2_sistemas_distribuidos
{
    public class PistaDePouso
    {
        private static int pistasCriadas = 0;
        private readonly object lockObj = new object();

        public PistaDePouso(){
            pistasCriadas++;
            this.numero = pistasCriadas;
            this.emUso = false;
        }

        public int numero;
        private bool _emUso;

        public bool emUso {
            get {
                return _emUso;
            } set {
                lock(lockObj){
                    _emUso = value;
                }
            }
        }
    }
}

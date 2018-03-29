using System;
using System.Collections.Generic;

namespace av2_sistemas_distribuidos
{
    public class Hangar
    {
        private static int hangaresCriados = 0;
        private readonly object lockObj = new object();

        public Hangar(){
            hangaresCriados++;
            this.numero = hangaresCriados;
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

using System;

namespace av2_sistemas_distribuidos
{
    public class Aviao
    {
        public string nome{get;set;}
        private PistaDePouso pista{get;set;}

        public Aviao(string nome){
            this.nome = nome;
        }

        public Aviao(string nome, PistaDePouso pista) : this(nome){
            this.pista = pista;
        }

        public bool Pousar(PistaDePouso pista){
            if(!pista.emUso){
                this.pista = pista;
                this.pista.emUso = true;
                Console.WriteLine("Pousei! ["+ this.nome + "][Pista-" + this.pista.numero + "]");
                return true;
            }

            Console.WriteLine("Pista ocupada! ["+ this.nome + "][Pista-" + pista.numero + "]");
            return false;
        }

        public void Decolar(){
            Console.WriteLine("Decolando! [" + this.nome + "][Pista-" + this.pista.numero + "]");
            this.pista.emUso = false;
            this.pista = null;
        }

    }
}

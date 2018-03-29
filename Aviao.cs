using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace av2_sistemas_distribuidos
{
    public class Aviao
    {
        public string nome{get;set;}
        private PistaDePouso pista{get;set;}

        private List<PistaDePouso> pistas {get; set;}

        public Aviao(string nome){
            this.nome = nome;
        }

        public Aviao(string nome, PistaDePouso pista) : this(nome){
            this.pista = pista;
        }

        public Aviao(string nome, List<PistaDePouso> pistas) : this(nome){
            this.pistas = pistas;
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

        public void init(){
            Task t = new Task(() => {
                Console.WriteLine("Avião " + this.nome + " está no radar da torre de comando.");

                while(true){
                    Thread.Sleep(2000);
                }
            });
        }

    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

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

        public bool Pousar(){
            if(!pista.emUso){
                this.pista = pista;
                this.pista.emUso = true;
                Console.WriteLine("Pousei! ["+ this.nome + "][Pista-" + this.pista.numero + "]");
                return true;
            }

            Console.WriteLine("Pista ocupada! ["+ this.nome + "][Pista-" + pista.numero + "]");
            return false;
        }

        public bool Decolar(){
            var pistaParaUsar = this.pistas.FirstOrDefault(x => !x.emUso);
            if(!pistaParaUsar.emUso){
                pistaParaUsar.emUso = true;
                Console.WriteLine(this.nome + " está realizando o procedimento de decolagem");

                Thread.Sleep(1500);
                Console.WriteLine(this.nome + " decolou! A pista será liberada");

                Thread.Sleep(900);
                pistaParaUsar.emUso = false;
                return true;
            } else {
                Console.WriteLine(this.nome + " aguardando autorização para decolar");
                return false;
            }

        }

        public void init(int acao){
            Task t = new Task(() => {
                Console.WriteLine("Avião " + this.nome + " está no radar da torre de comando.");

                while(true){
                    var realizouAcao = false;
                    if(acao == 0){
                        realizouAcao = Decolar();
                    } else {
                        realizouAcao = Pousar();
                    }

                    if(realizouAcao){
                        break;
                    } else {
                        Thread.Sleep(2000);
                    }
                }
            });
        }

    }
}

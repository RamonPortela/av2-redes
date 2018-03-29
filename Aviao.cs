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
        private static int avioesCriados = 0;

        private List<PistaDePouso> pistas {get; set;}
        private List<Hangar> hangares{get;set;}

        private Hangar hangarParaEstacionar{get;set;}

        private Aviao(){
            avioesCriados++;
            this.nome = "Avião " + avioesCriados.ToString();
        }

        public Aviao(List<PistaDePouso> pistas, List<Hangar> hangares) : this(){            
            this.pistas = pistas;
            this.hangares = hangares;
        }

        public bool Pousar(){
           var pistaParaUsar = this.pistas.FirstOrDefault(x => !x.emUso);
           var hangarParaEstacionar = this.hangares.FirstOrDefault(h => !h.emUso);
            if(pistaParaUsar != null && !pistaParaUsar.emUso && hangarParaEstacionar != null && !hangarParaEstacionar.emUso){
                hangarParaEstacionar.emUso = true;
                pistaParaUsar.emUso = true;
                this.hangarParaEstacionar = hangarParaEstacionar;
                Console.WriteLine(this.nome + " está realizando o procedimento de aterrisagem, na pista: " + pistaParaUsar.numero);
                Console.WriteLine("O hangar " + this.hangarParaEstacionar.numero + " está designado para o "+ this.nome+ " estacionar.");

                Thread.Sleep(1500);
                Console.WriteLine(this.nome + " aterrisou! A pista " + pistaParaUsar.numero + " será liberada");

                Thread.Sleep(900);
                pistaParaUsar.emUso = false;
                Console.WriteLine("Pista " + pistaParaUsar.numero + " agora está liberada.");

                return true;
            } else {

                string mensagem = "Permissão de decolagem para o "+ this.nome + " negada,";

                if(pistaParaUsar == null || pistaParaUsar.emUso){
                    Console.WriteLine(mensagem + " todas as pistas estão ocupadas");
                    return false;
                }

                if(hangarParaEstacionar == null || hangarParaEstacionar.emUso){
                    Console.WriteLine(mensagem + " todas os hangares estão ocupados");
                    return false;
                }

                return false;
            }
        }

        public bool Decolar(){
            var pistaParaUsar = this.pistas.FirstOrDefault(x => !x.emUso);
            if(pistaParaUsar != null && !pistaParaUsar.emUso){
                pistaParaUsar.emUso = true;

                Console.WriteLine(this.nome+ " está liberando o Hangar " + this.hangarParaEstacionar.numero);
                this.hangarParaEstacionar.emUso = false;
                this.hangarParaEstacionar = null;
                
                Console.WriteLine(this.nome + " está realizando o procedimento de decolagem, na pista: " + pistaParaUsar.numero);

                Thread.Sleep(1500);
                Console.WriteLine(this.nome + " decolou! A pista " + pistaParaUsar.numero + " será liberada");

                Thread.Sleep(900);
                pistaParaUsar.emUso = false;
                Console.WriteLine("Pista " + pistaParaUsar.numero + " agora está liberada.");

                return true;
            } else {
                Console.WriteLine("Permissão de decolagem negada, todas as pistas estão ocupadas.");
                return false;
            }
        }

        public Task init(){
            Task t = new Task(() => {
                Console.WriteLine(this.nome + " está no radar da torre de comando.");

                while(true){
                    Console.WriteLine(this.nome + " está pedindo permissão para pousar.");
                    var pousou = false;
                    pousou = Pousar();
                    if(pousou){
                        break;
                    } else {
                        Thread.Sleep(2000);
                    }
                }

                Console.WriteLine(this.nome + " está aguardando no Hangar " + this.hangarParaEstacionar.numero); 
                Thread.Sleep(2000);

                while(true){
                    Console.WriteLine(this.nome + " está pedindo permissão para decolar.");
                    var decolou = false;
                    decolou = Decolar();
                    if(decolou){
                        break;
                    }
                    else{
                        Thread.Sleep(2000);
                    }
                }
            });

            t.Start();

            return t;
        }

    }
}

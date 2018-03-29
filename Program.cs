using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace av2_sistemas_distribuidos
{
    class Program
    {
        static Random random = new Random();
        static List<PistaDePouso> pistas;

        static void Main(string[] args)
        {
            pistas = new List<PistaDePouso> { new PistaDePouso() };

            Aviao aviao1 = new Aviao("Avião 1");
            Aviao aviao2 = new Aviao("Avião 2");

            aviao1.Pousar(pista);
            aviao2.Pousar(pista);
            aviao1.Decolar();
            aviao2.Pousar(pista);
        }

        static void geraAviao(){
            Task t = new Task(() => {
                while(true){
                    Aviao aviao = new Aviao("Aviao" + random.Next(0000, 9999), pistas);
                    aviao.init();
                    Thread.Sleep(random.Next(1000, 4000));
                }
            });
        }
    }
}

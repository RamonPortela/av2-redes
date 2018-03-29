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

            geraAviao();
            
        }

        static void geraAviao(){
            while(true){
                Aviao aviao = new Aviao("Aviao" + random.Next(0000, 9999), pistas);
                aviao.init(random.Next(0, 1));
                Thread.Sleep(random.Next(1000, 4000));
            }
        }
    }
}

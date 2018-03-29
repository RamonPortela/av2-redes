using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace av2_sistemas_distribuidos
{
    class Program
    {
        static Random random = new Random();
        

        static void Main(string[] args)
        {
            List<PistaDePouso> pistas = new List<PistaDePouso> { new PistaDePouso(), new PistaDePouso(), new PistaDePouso() };
            List<Hangar> hangares = new List<Hangar>() { new Hangar(), new Hangar() };

            geraAviao(pistas, hangares).Wait();
            
        }

        static async Task geraAviao(List<PistaDePouso> pistas, List<Hangar> hangares){

            List<Task> threads = new List<Task>();

            for (int i = 0; i < 5; i++)
            {
                Aviao aviao = new Aviao(pistas, hangares);

                Hangar hangar = hangares.FirstOrDefault(h => !h.emUso);

                threads.Add(aviao.init());
                Thread.Sleep(random.Next(1000, 3000));
            }
            
            await Task.WhenAll(threads);

        }
    }
}

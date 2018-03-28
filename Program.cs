using System;

namespace av2_sistemas_distribuidos
{
    class Program
    {
        static void Main(string[] args)
        {
            PistaDePouso pista = new PistaDePouso();
            Aviao aviao1 = new Aviao("Avião 1");
            Aviao aviao2 = new Aviao("Avião 2");

            aviao1.Pousar(pista);
            aviao2.Pousar(pista);
            aviao1.Decolar();
            aviao2.Pousar(pista);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manipulador_Arquivos
{
    class Program
    {
        static Manipulador manipulador = new Manipulador();

        static void Main(string[] args)
        {
            manipulador.verificarPastas();
            manipulador.separarComentarios(manipulador.abrirArquivo());
            Console.WriteLine("");
            Console.ReadKey();

        }
    }
}

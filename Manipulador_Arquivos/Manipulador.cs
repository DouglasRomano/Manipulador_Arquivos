using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Manipulador_Arquivos
{
    class Manipulador
    {
        private DirectoryInfo pathAtual;
        private DirectoryInfo pathFontes;
        private DirectoryInfo pathObj;
        private DirectoryInfo pathComp;

        private String comentarios;
        private String obj;
        private String var;

        

        public Manipulador()
        {
            String caminhoCorrente = Directory.GetCurrentDirectory();
            pathAtual = new DirectoryInfo(caminhoCorrente);
            pathFontes = new DirectoryInfo(Path.Combine(pathAtual.FullName,"fontes"));
            pathObj = new DirectoryInfo(Path.Combine(pathAtual.FullName,"obj"));
            pathComp = new DirectoryInfo(Path.Combine(pathAtual.FullName, "comp"));
            
        }

        public void verificarPastas()
        {
            /* este metodo é responsável por verificar se as pastas "fontes", "obj" e "comp" existem,
             * caso não, as mesmas deverão ser criadas */

            if (!pathFontes.Exists)
            {
                pathFontes.Create();
            }
            if (!pathObj.Exists)
            {
                pathObj.Create();
            }
            if (!pathComp.Exists)
            {
                pathComp.Create();
            }
            }

        public String abrirArquivo()
        {
            String texto = File.ReadAllText(Path.Combine(pathFontes.FullName, "fonte.c"));
            texto = texto.Replace("\r", "");
            return texto;
        }

        public void separarComentarios(String texto)
        {
            
            int indexInicioComentario =0;
            int indexFimComentario;

            while (indexInicioComentario != -1)
            {
                indexInicioComentario = texto.IndexOf("//");
                if (indexInicioComentario > 0)
                {
                    indexFimComentario = texto.IndexOf("\n", indexInicioComentario);
                    comentarios = comentarios + texto.Substring(indexInicioComentario, indexFimComentario - indexInicioComentario) + ";";
                    texto = texto.Remove(indexInicioComentario, indexFimComentario - indexInicioComentario);
                }
            }

            indexInicioComentario = 0; // zera o indice para entrar no loop novamente

            while (indexInicioComentario != -1)
            {
                indexInicioComentario = texto.IndexOf("/*");
                if (indexInicioComentario > 0)
                {
                    indexFimComentario = texto.IndexOf("*/", indexInicioComentario);
                    comentarios = comentarios + texto.Substring(indexInicioComentario, (indexFimComentario+2) - indexInicioComentario) + ";";
                    texto = texto.Remove(indexInicioComentario, (indexFimComentario+2) - indexInicioComentario);
                }
            }
            File.WriteAllText(Path.Combine(pathComp.FullName, "comentarios.c"), comentarios);
            Console.WriteLine("Comentarios salvos!");
            Console.ReadKey();
        }

        public void separarVariaveis(String texto)
        {
            int indexInicioVariavel = 0;
            int indexLimiteVariavelGlobal;
            String linhaGlobal = "global = ";
            String linhaLocal = "local = ";

            indexLimiteVariavelGlobal = texto.IndexOf("main("); //inicio do main

            List<String> listVariaveis = new List<String>();
            String[] variaveis = { "int","float","define","num","char" };

            while (indexInicioVariavel != -1)
            {
                for (int x = 0; x < (variaveis.Length-1); x++)
                {
                    char[] varchar = variaveis[x].ToCharArray();
                    

        
                }
            }
        }
        public DirectoryInfo PathAtual
        {
            get { return pathAtual; }
            set { pathAtual = value; }
        }

        public DirectoryInfo PathFontes
        {
            get { return pathFontes; }
            set { pathFontes = value; }
        }

        public DirectoryInfo PathObj
        {
            get { return pathObj; }
            set { pathObj = value; }
        }

        public DirectoryInfo PathComp
        {
            get { return pathComp; }
            set { pathComp = value; }
        }

    }
}

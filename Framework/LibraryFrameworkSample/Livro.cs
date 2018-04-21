using System;
using Devmedia.Estudo.LibraryFrameworkSample.Library;

namespace Devmedia.Estudo.LibraryFrameworkSample
{
    public class Livro
    {
        string titulo;

        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }
        string autor;

        public string Autor
        {
            get { return autor; }
            set { autor = value; }
        }

        int anoPublicacao;

        public int AnoPublicacao
        {
            get { return anoPublicacao; }
            set { anoPublicacao = value; }
        }

        Biblioteca _biblioteca;

        public Biblioteca _Biblioteca
        {
            get { return _biblioteca; }
            set { _biblioteca = value; }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace ProjetoLivraria.Models
{
    public class Livros
    {
        public decimal LIV_ID_LIVRO;
        public decimal LIV_ID_TIPO_LIVRO;
        public decimal LIV_ID_EDITOR;
        public string LIV_NM_TITULO;
        public decimal LIV_VL_PRECO;
        public decimal LIV_PC_ROYALTY;
        public string LIV_DS_RESUMO;
        public int LIV_NU_EDICAO;

        public Livros(decimal idLivro, decimal idTipoLivro, decimal livIdEditor, string nmTitulo, decimal valorLivro, decimal pcRoyalt, string livroDsResumo, int livroEdicao)
        {
            this.LIV_ID_LIVRO = idLivro;
            this.LIV_ID_TIPO_LIVRO = idTipoLivro;
            this.LIV_ID_EDITOR = livIdEditor;
            this.LIV_NM_TITULO = nmTitulo;
            this.LIV_VL_PRECO = valorLivro;
            this.LIV_PC_ROYALTY = pcRoyalt;
            this.LIV_DS_RESUMO = livroDsResumo;
            this.LIV_NU_EDICAO = livroEdicao;
        }

    }
}
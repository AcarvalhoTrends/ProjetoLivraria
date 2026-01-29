using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoLivraria.Models
{
    public class TipoLivro
    {
        public decimal til_id_tipo_livro;
        public string til_ds_descricao;


        public TipoLivro(decimal idTipoDeLivro, string tilDescricao)
        {
            this.til_id_tipo_livro = idTipoDeLivro;
            this.til_ds_descricao = tilDescricao;
        }
    }
    
}
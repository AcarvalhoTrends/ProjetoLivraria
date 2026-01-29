using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoLivraria.Models

{
    [Serializable]
    public class liaLivro
    {
        public decimal lia_id_autor { get; set; }
        public decimal lia_id_livro { get; set; }
        public decimal lia_pc_royalt { get; set; }


        public liaLivro(decimal liaIdAutor, decimal liaIdlivro, decimal liaPcRoyalt)
        {
            this.lia_id_autor = liaIdAutor;
            this.lia_id_livro = liaIdlivro;
            this.lia_pc_royalt = liaPcRoyalt;

        }


    }
}
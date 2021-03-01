using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexaoBD
{
    class Usuario
    {
        public int UsuarioId { get; set; }

        public string Nome { get; set; }

        public string Cargo { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalGamesCet49.Dados.Entidades
{
    public class PedidoDeContacto
    {
        public int Id { get; set; }                                                         /* propriedade de leitura e escrita get: pode ler, set: pode escrever*/

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Mensagem { get; set; }
    }
}

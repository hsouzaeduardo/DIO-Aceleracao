using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DIO.Pagamento.Model
{
    public class Pedido
    {
        public string NumeroPedido { get; set; }
        public string DataPedido { get; set; }
        public string Item { get; set; }
        public string Preco { get; set; }
        public string AzureWebJobsParentId { get; set; }


    }
}


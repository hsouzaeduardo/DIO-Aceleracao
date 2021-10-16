using API.DIO.Pagamento.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace API.DIO.Pagamento.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PagamentoController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] Pedido pedido)
        {
            var wsurl = "wss://free3.piesocket.com/v3/1?api_key=PXTylH7wqVKkqUoVxrntub9Qiy12TG6prIG72mXG0oUGYdZyjlimxDxnsrTJ&notify_self";

            using(var socket = new ClientWebSocket())
            {
                try
                {
                    await socket.ConnectAsync(new Uri(wsurl), CancellationToken.None);
                    var pedidojson = JsonConvert.SerializeObject(pedido);

                    await SendToFront(pedidojson, socket);

                }
                catch (Exception ex)
                {

                    throw;
                }
            }
            return Ok(); 
        }

        private async Task SendToFront(string pedido, ClientWebSocket socket) => await socket.SendAsync(Encoding.UTF8.GetBytes(pedido)
            , WebSocketMessageType.Text, true, CancellationToken.None); 
    }
}

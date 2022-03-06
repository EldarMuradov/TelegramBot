using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Telegram.Bot.Types;
using TelegramBotSeeker;
using TelegramBotSeeker.Models;

namespace TelegramBotSeeker.Controllers
{
    public class MessageController : ApiController
    {
        [Route(@"api/message/upd")] //webhook uri part
        public async Task<OkResult> Update([FromBody] Update update)
        {
            var commands = Bot.Commands;
            var message = update.Message;
            var client = await Bot.Get();
            foreach (var command in commands) 
            {
                if (command.Contains(message.Text)) 
                {
                    command.Execute(message, client);
                    break;
                }
            }
            return Ok();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Telegram.Bot;
using TelegramBotSeeker.Models.Commands;
using TelegramBotSeeker.Commands;

namespace TelegramBotSeeker.Models
{
    public static class Bot
    {
        private static TelegramBotClient client;
        public static List<Command> commandList;
        public static IReadOnlyList<Command> Commands { get => commandList.AsReadOnly(); }
        public static async Task<TelegramBotClient> Get()
        {
            if (client != null) { return client; }

            commandList = new List<Command>();
            commandList.Add(new HelloCommand());
            //TODO: Add more  commands -_-
            client = new TelegramBotClient(AppSettings.Key);
            var hook = string.Format(AppSettings.Url, "api/message/update");
            await client.SetWebhookAsync(hook);
            return client;
        }

    }
}
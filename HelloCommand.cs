using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types;
using Telegram.Bot;
using TelegramBotSeeker.Commands;

namespace TelegramBotSeeker.Models.Commands
{
    public class HelloCommand : Command
    {
        public override string Name => "hello!";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            var ChatId = message.Chat.Id;
            var messageId = message.MessageId;
            //TODO: Bot Logic -_-
            await client.SendTextMessageAsync(ChatId, "Hallo!");
        }
    }
}
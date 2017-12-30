using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using Discord;

namespace cfrpb.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        [Command("bio")]
        public async Task HWC()
        {
            await ReplyAsync("Here is a Bio for <user>");
        }






    }
}

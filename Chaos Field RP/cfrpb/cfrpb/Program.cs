using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace cfrpb
{
    public class Program
    {
        public static void Main(string[] args)
         => new Program().StartAsync().GetAwaiter().GetResult();

        public DiscordSocketClient _client = new DiscordSocketClient(new DiscordSocketConfig
        {
            LogLevel = LogSeverity.Verbose
        });
        private LoginInfo loginInfo = new LoginInfo();
        private CommandHandler _handler = new CommandHandler();

        public async Task StartAsync()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            _client.Log += Log;
            _client.Ready += Ready;

            await _client.LoginAsync(TokenType.Bot, loginInfo.token);
            await _client.StartAsync();
            await _handler.InitializeAsync(_client);

            await Task.Delay(-1);
        }
        public Task Log(LogMessage lm)
        {
            Console.WriteLine(lm.ToString());
            return Task.CompletedTask;
        }
        public async Task Ready()
        {
            await _client.SetGameAsync("cf! | Character Bios for Chaos Fields");
        }
    }
}

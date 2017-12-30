using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Discord.Commands;
using System.Net.Http;
using Discord;

namespace cfrpb.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        private HttpClient client = new HttpClient();
        private libCFRP lib = new libCFRP();

        private string getUsersURL = "http://monstahhhbot.890m.com/NexiBot/getCharData10.php";
        private string injectUsersURL = "http://monstahhhbot.890m.com/NexiBot/postCharData10.php";

        [Command("help")]
        public async Task HelpCmd ()
        {
            EmbedBuilder e = new EmbedBuilder();
            e.Color = new Color(0x0e0000);

            e.AddField("Bot Prefix", "cf!");
            e.AddField("bio", "[CHARACTER NAME] get information about a specific character.");
            e.AddField("injectbio", "[NAME], [DESCRIPTION], [IMAGE URL] uploads a character to the database.");
            e.AddField("**Credits**", "Injection and Getting data made by Monstahhh#9629, Base code by Monstahhh#9629");

            Embed a = e.Build();
            await ReplyAsync("", embed: a);
        }
        [Command("bio")]
        public async Task GetBioCmd (string charName = null)
        {
            if (charName == null)
            {
                await ReplyAsync("Please enter a character.");
                return;
            }
            #region GetData
            var getCharsDict = new Dictionary<string, string>
            {
                {"charNamePost", charName}
            };
            FormUrlEncodedContent content = new FormUrlEncodedContent(getCharsDict);
            HttpResponseMessage response = await client.PostAsync(getUsersURL, content);
            string responseStr = await response.Content.ReadAsStringAsync();
            #endregion
            string[] charData = responseStr.Split('|');
            string charNameResult = charData[0];
            string charDesc = charData[1];
            string charUrl = charData[2];
            Embed a = lib.createEmbedWithThumbnail(charNameResult, charDesc, charUrl);

            await ReplyAsync("", embed: a);
            
        }
        [Command("injectbio")]
        public async Task InjectBioCmd (string name, string desc, string imgURL)
        {
            if (name == null || desc == null || imgURL == null)
            {
                await ReplyAsync("One or more parameters are missing.");
                return;
            }
            var postUsersDict = new Dictionary<string, string>
            {
                {"usernamePost", name},
                {"descPost", desc},
                {"urlPost", imgURL}
            };
            FormUrlEncodedContent content = new FormUrlEncodedContent(postUsersDict);
            HttpResponseMessage response = await client.PostAsync(injectUsersURL, content);
            string responseStr = await response.Content.ReadAsStringAsync();
            if (responseStr.Contains("Injected"))
            {
                await ReplyAsync("Successfully added Character to the database.");
            } else if (responseStr == "-1")
            {
                await ReplyAsync("**ERROR**:" + responseStr);
            }
        }
    }
}

using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cfrpb
{
    public class libCFRPB
    {
        public LoginInfo loginInfo = new LoginInfo();

        public Embed createEmbedWithThumbnail(string title, string text, string imgUrl)
        {
            EmbedBuilder e = new EmbedBuilder();
            e.Color = new Color(0x0e0000);
            e.AddField(title, text);
            e.ThumbnailUrl = imgUrl;
            return e.Build();
        }
        public String getToken ()
        {
            return loginInfo.token;
        }
    }
}

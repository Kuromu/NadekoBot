using NadekoBot.Extensions;
using System.Collections.Generic;

namespace NadekoBot.Core.Services.Database.Models
{
    public class WaifuInfo : DbEntity
    {
        public int WaifuId { get; set; }
        public DiscordUser Waifu { get; set; }

        public int? ClaimerId { get; set; }
        public DiscordUser Claimer { get; set; }

        public int? AffinityId { get; set; }
        public DiscordUser Affinity { get; set; }

        public int Price { get; set; }
        public List<WaifuItem> Items { get; set; } = new List<WaifuItem>();

        public override string ToString()
        {
            var claimer = "no one";
            var status = "";

            var waifuUsername = Waifu.Username.TrimTo(20);
            var claimerUsername = Claimer?.Username.TrimTo(20);

            if (Claimer != null)
            {
                claimer = $"{ claimerUsername }#{Claimer.Discriminator}";
            }
            if (AffinityId == null)
            {
                status = $"... but {waifuUsername} swears loyalty to no one.";
            }
            else if (AffinityId == ClaimerId)
            {
                status = $"... and {waifuUsername} has sworn loyalty to {claimerUsername}, as well!";
            }
            else {
                status = $"... but {waifuUsername} has sworn loyalty to {Affinity.Username.TrimTo(20)}#{Affinity.Discriminator}";
            }
            return $"**{waifuUsername}#{Waifu.Discriminator}** - hired by **{claimer}**\n\t{status}";
        }
    }
}

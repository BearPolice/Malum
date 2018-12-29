using Terraria;
using Terraria.ModLoader;

namespace Malum
{
    public class MaliciousPlayer : ModPlayer
    {
        public static MaliciousPlayer ModPlayer(Player player)
        {
            return player.GetModPlayer<MaliciousPlayer>();
        }


        public float MaliciousDamage = 1f;
        public float MaliciousKnockback;
        public int MaliciousCrit;

        public override void ResetEffects()
        {
            ResetVariables();
        }

        public override void UpdateDead()
        {
            ResetVariables();
        }

        private void ResetVariables()
        {
            MaliciousDamage = 1f;
            MaliciousKnockback = 0f;
            MaliciousCrit = 0;
        }
    }
}
using System.Collections.Generic;
using Newtonsoft.Json;

namespace EloBuddy.SDK.Spells
{
    public static class SpellDatabase
    {
        internal static Dictionary<string, List<SpellInfo>> Database { get; set; }

        internal static void Initialize()
        {
            // Deserialize database
            Database = JsonConvert.DeserializeObject<Dictionary<string, List<SpellInfo>>>(DefaultSettings.SpellDatabase);

            // Listen to required events
            //Obj_AI_Base.OnProcessSpellCast += OnProcessSpellCast;
            //Obj_AI_Base.OnSpellCast += OnSpellCast;
        }

        public static List<SpellInfo> GetSpellInfoList(string baseSkinName)
        {
            if (Database.ContainsKey(baseSkinName))
            {
                return Database[baseSkinName];
            }
            return new List<SpellInfo>();
        }

        public static List<SpellInfo> GetSpellInfoList(Obj_AI_Base sender)
        {
            return GetSpellInfoList(sender.BaseSkinName);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Agro.Interfaces;

namespace Agro.Helpers
{
    public static class UserSettingsHelper
    {
        public static UserSettings GetUserSettings()
        {
            UserSettings? userSettings = new();
            if (File.Exists("UserSettings.json"))
            {
                string data = File.ReadAllText("UserSettings.json");
                userSettings = JsonSerializer.Deserialize<UserSettings>(data);
            }
            return userSettings!;
        }

        public static bool SetUserSettings(UserSettings userSettings)
        {
            string personJson = JsonSerializer.Serialize(userSettings, typeof(UserSettings));
            StreamWriter file = File.CreateText("UserSettings.json");
            file.WriteLine(personJson);
            file.Close();
            return true;
        }

    }
}

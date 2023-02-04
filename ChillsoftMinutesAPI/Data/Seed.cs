using ChillsoftMinutesAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace ChillsoftMinutesAPI.Data
{
    public class Seed
    {
        public static async Task SeedUsers(DataContext context)
        {
            if(await context.Users.AnyAsync()) return;

            var userData = await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");
            var jobject = JObject.Parse(userData);

            var users = JsonSerializer.Deserialize<List<AppUser>>(userData);
            if(users == null || users.Count == 0) return;

            foreach (var user in users)
            {
                user.UserName = user.UserName.ToLower();
                //user.NormalizedEmail = user.EmailAddress.ToUpper(),
                
                await context.Users.AddAsync(user);
            }

            await context.SaveChangesAsync();

        }
    }
}

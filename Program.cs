using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

class Program
{
    private DiscordSocketClient _client;
    private Random rand = new Random();

    private readonly ulong[] AdminRoles =
    {
        1481765988147138772,
        1496291548936142919,
        1477658738969284699
    };

    private readonly ulong OWNER_ID = 1218638987208691858;
    private readonly ulong other = 1246224666083725465;
    private readonly ulong lul = 939233522504327169;

    public static Task Main(string[] args)
        => new Program().MainAsync();

    public async Task MainAsync()
    {
        _client = new DiscordSocketClient(new DiscordSocketConfig
        {
            GatewayIntents =
                GatewayIntents.Guilds |
                GatewayIntents.GuildMessages |
                GatewayIntents.MessageContent |
                GatewayIntents.GuildMembers
        });

        _client.Log += Log;
        _client.MessageReceived += MessageReceived;

        // =========================
        // HOSTING FIX (IMPORTANT)
        // =========================
        string token = Environment.GetEnvironmentVariable("DISCORD_TOKEN");

        if (string.IsNullOrEmpty(token))
        {
            Console.WriteLine("❌ DISCORD_TOKEN missing in environment variables");
            return;
        }

        await _client.LoginAsync(TokenType.Bot, token);
        await _client.StartAsync();

        Console.WriteLine("Bot running...");
        await Task.Delay(-1);
    }

    private Task Log(LogMessage msg)
    {
        Console.WriteLine(msg);
        return Task.CompletedTask;
    }

    // =========================
    // MESSAGE HANDLER (ALL YOUR COMMANDS KEPT)
    // =========================
    private async Task MessageReceived(SocketMessage message)
    {
        if (message.Author.IsBot) return;

        string msg = message.Content.ToLower();
        var user = message.Author;

        // ===== BASIC COMMANDS =====
        if (msg == "?ping") await message.Channel.SendMessageAsync("🏓 Pong!");
        else if (msg == "?hello") await message.Channel.SendMessageAsync($"👋 Hello {user.Mention}");
        else if (msg == "?bye") await message.Channel.SendMessageAsync("👋 Goodbye!");
        else if (msg == "?joke") await message.Channel.SendMessageAsync(GetJoke());
        else if (msg == "?quote") await message.Channel.SendMessageAsync("💡 Keep going, you got this!");
        else if (msg == "?fact") await message.Channel.SendMessageAsync("🍌 Bananas are berries!");
        else if (msg == "?meme") await message.Channel.SendMessageAsync("😂 https://tenor.com/view/patrick-drooling-patrick-star-spongebob-movie-drooling-slime-gif-525340425450564005");
        else if (msg == "?time") await message.Channel.SendMessageAsync(DateTime.Now.ToShortTimeString());
        else if (msg == "?date") await message.Channel.SendMessageAsync(DateTime.Now.ToShortDateString());
        else if (msg == "?flip") await message.Channel.SendMessageAsync(rand.Next(2) == 0 ? "Heads" : "Tails");
        else if (msg == "?roll") await message.Channel.SendMessageAsync($"🎲 {rand.Next(1, 101)}");
        else if (msg == "?dice") await message.Channel.SendMessageAsync($"🎲 {rand.Next(1, 7)}");
        else if (msg == "?sayhi") await message.Channel.SendMessageAsync("Hi back 👋");

        // ===== ROBLOX / LINKS =====
        else if (msg == "?gamelink") await message.Channel.SendMessageAsync("🎮 https://www.roblox.com/share?code=7ef5c06850582548b308875d4edc8dd3&type=ExperienceDetails&stamp=1776427978985\n\nCheck Discord channel for more! " + message.Author.Mention);
        else if (msg == "?notion") await message.Channel.SendMessageAsync("https://www.youtube.com/watch?v=Q6lYUGkAdnw " + message.Author.Mention);
        else if (msg == "?shower") await message.Channel.SendMessageAsync("Go take a shower 🤮🚿 " + message.Author.Mention);

        // ===== OWNER COMMANDS =====
        else if (msg == "!rainty")
        {
            if (message.Author.Id != OWNER_ID)
            {
                await message.Channel.SendMessageAsync("❌ Not you " + message.Author.Mention);
                return;
            }

            await message.Channel.SendMessageAsync("hi Rainyy");
        }
        else if (msg == "!cloudy")
        {
            if (message.Author.Id != other)
            {
                await message.Channel.SendMessageAsync("❌ Not you " + message.Author.Mention);
                return;
            }

            await message.Channel.SendMessageAsync("hi Cloudy");
        }
        else if (msg == "!oak")
        {
            if (message.Author.Id != lul)
            {
                await message.Channel.SendMessageAsync("❌ Not you");
                return;
            }

            await message.Channel.SendMessageAsync("hi Oakly");
        }

        // ===== FUN COMMANDS (ALL KEPT) =====
        else if (msg == "?roast") await message.Channel.SendMessageAsync("You code like a potato 💀");
        else if (msg == "?compliment") await message.Channel.SendMessageAsync("You're actually amazing ⭐");
        else if (msg == "?8ball") await message.Channel.SendMessageAsync(Get8Ball());
        else if (msg == "?choose") await message.Channel.SendMessageAsync("I choose option 1");
        else if (msg == "?truth") await message.Channel.SendMessageAsync("What's your biggest fear?");
        else if (msg == "?dare") await message.Channel.SendMessageAsync("Say something funny in chat");
        else if (msg == "?coinflip") await message.Channel.SendMessageAsync(rand.Next(2) == 0 ? "Heads" : "Tails");
        else if (msg == "?lucky") await message.Channel.SendMessageAsync($"🍀 {rand.Next(1, 100)}%");
        else if (msg == "?unlucky") await message.Channel.SendMessageAsync($"💀 {rand.Next(1, 50)}%");
        else if (msg == "?joke2") await message.Channel.SendMessageAsync(GetJoke());
        else if (msg == "?rage") await message.Channel.SendMessageAsync("💢 AHHHHH");
        else if (msg == "?sus") await message.Channel.SendMessageAsync("📮 SUS");
        else if (msg == "?brainrot") await message.Channel.SendMessageAsync("🧠💀 overload");
        else if (msg == "?simp") await message.Channel.SendMessageAsync("simp detected 💔");
        else if (msg == "?based") await message.Channel.SendMessageAsync("🗿 based");
        else if (msg == "?cringe") await message.Channel.SendMessageAsync("cringe 😬");
        else if (msg == "?huh") await message.Channel.SendMessageAsync("?!");
        else if (msg == "?lol") await message.Channel.SendMessageAsync("LOL");
        else if (msg == "?bruh") await message.Channel.SendMessageAsync("bruh 💀");
        else if (msg == "?skillissue") await message.Channel.SendMessageAsync("skill issue");

        // ===== RAINYY THEME =====
        else if (msg == "?rain") await message.Channel.SendMessageAsync("🌧️ rain starts");
        else if (msg == "?storm") await message.Channel.SendMessageAsync("⛈️ storm incoming");
        else if (msg == "?thunder") await message.Channel.SendMessageAsync("⚡ BOOM");
        else if (msg == "?cloud") await message.Channel.SendMessageAsync("☁️ clouds");
        else if (msg == "?rainyy") await message.Channel.SendMessageAsync("Rainyy on top 🌧️");
        else if (msg == "?wetmode") await message.Channel.SendMessageAsync("💧 wet mode activated");
        else if (msg == "?fog") await message.Channel.SendMessageAsync("🌫️ fog");
        else if (msg == "?sky") await message.Channel.SendMessageAsync("🌌 sky vibes");
        else if (msg == "?weatherfake") await message.Channel.SendMessageAsync("☀️ fake weather");
        else if (msg == "?vibes") await message.Channel.SendMessageAsync("✨ vibes only");

        // ===== ADMIN =====
        else if (msg.StartsWith("?kick")) await Admin(message, "kick");
        else if (msg.StartsWith("?ban")) await Admin(message, "ban");
        else if (msg.StartsWith("?clear")) await Admin(message, "clear");
        else if (msg.StartsWith("?say")) await Admin(message, message.Content.Substring(5));
        else if (msg.StartsWith("?dm")) await Admin(message, "dm sent");
    }

    // =========================
    // ADMIN SYSTEM
    // =========================
    private async Task Admin(SocketMessage message, string action)
    {
        if (message.Author is not SocketGuildUser user)
            return;

        if (!user.Roles.Any(r => AdminRoles.Contains(r.Id)))
        {
            await message.Channel.SendMessageAsync("❌ No permission");
            return;
        }

        await message.Channel.SendMessageAsync(action);
    }

    // =========================
    // HELPERS
    // =========================
    private string GetJoke()
    {
        string[] jokes =
        {
            "Why is Rainyy so good at coding? IDK😂",
            "I told my code a joke... it crashed 😂",
            "Stack overflow is my home 🏠"
        };

        return jokes[rand.Next(jokes.Length)];
    }

    private string Get8Ball()
    {
        string[] r =
        {
            "Yes",
            "No",
            "Maybe",
            "Definitely",
            "Ask again"
        };

        return r[rand.Next(r.Length)];
    }
}
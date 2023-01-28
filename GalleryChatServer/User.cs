namespace GalleryChatServer;
using System;

public class User
{
    public User(string Username, string Fullname)
    {
        this.Username = Username;
        this.Fullname = Fullname;
    }

    public Guid Id { get; } = Guid.NewGuid();
    public string Username { get; set; }
    public string Fullname { get; set; }

    public static User getTestUser(int? i = null)
    {
        int index = (int)(i.HasValue ? (i.Value > 4 ? 4 : i) : new Random().Next(1, 5));

        string[,] user_details = new string[,] {
            { "neri.coder", "Neriya Rosner" },
            {"josh.doe", "Josh Doe" },
            {"erica.the.queen", "Erica Queen" },
            {"michael.jackson", "Micheal Jackson" },
            {"donna.primadona", "Donna Primadona" },
        };

        string username = user_details[index, 0];
        string name = user_details[index, 1];

        return new User(username, name);
    }

}


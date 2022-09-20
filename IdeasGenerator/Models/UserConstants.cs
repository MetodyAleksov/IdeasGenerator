using System.Collections.Generic;

namespace IdeasGenerator.Models
{
    public static class UserConstants
    {
        public const List<User> Users = new List<User>()
        {
            new User(){ Username = "jsonAdmin", Password = "mypass", Role="admin"},
            new User(){ Username ="user", Password='mypass2', Role="user"}
        };
    }
}

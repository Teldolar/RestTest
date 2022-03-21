using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Aquality.Selenium.Browsers;
using TestProject1.Models;

namespace TestProject1.Utils
{
    public static class TestUtil
    {
        public static bool IsPostsSorted(string jsonString)
        {
            AqualityServices.Logger.Debug("Check post for sorted");
            var posts = JsonSerializer.Deserialize<List<Post>>(jsonString);
            return posts != null && posts.All(_ => posts[0].Id < posts[1].Id);
        }

        public static (int, int, bool, bool) GetSecondStepInfo(string jsonString)
        {
            AqualityServices.Logger.Debug("Get second step info");
            var post = JsonSerializer.Deserialize<Post>(jsonString);
            return (post.UserId,post.Id,!string.IsNullOrEmpty(post.Title),!string.IsNullOrEmpty(post.Body));
        }

        public static User GetUser(string jsonString,int number)
        {
            AqualityServices.Logger.Debug("Get user by number");
            var foundUser = new User();
            foreach (var user in JsonSerializer.Deserialize<List<User>>(jsonString)!.Where(user => user.Id==number))
            {
                foundUser = user;
            }
            return foundUser;
        }

        public static User GetUser(string jsonString)
        {
            AqualityServices.Logger.Debug("Check user by url");
            return JsonSerializer.Deserialize<User>(jsonString);
        }

        public static Post GetPost(string jsonString)
        {
            AqualityServices.Logger.Debug("Get Post obj from json");
            return JsonSerializer.Deserialize<Post>(jsonString);
        }
    }
}
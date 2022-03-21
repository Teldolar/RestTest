using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Aquality.Selenium.Browsers;
using NUnit.Framework;
using TestProject1.Models;

namespace TestProject1.Utils
{
    public static class AppApiUtils
    {
        private static readonly TestCase _testCase;
        static AppApiUtils()
        {
            using var reader = new StreamReader("settings.json");
            _testCase = JsonSerializer.Deserialize<TestCase>(reader.ReadToEnd());
        }
        
        public static string GetAllPostsJson()
        {
            AqualityServices.Logger.Debug("Get all post json");
            Assert.AreEqual(200,ApiUtils.Get($"{_testCase.Url}{_testCase.PostsPath}").Item1,"Wrong status code");
            return ApiUtils.Get($"{_testCase.Url}{_testCase.PostsPath}").Item2.Replace("\r","");
        }

        public static Post GetUniquePostFromServer(int postId)
        {
            AqualityServices.Logger.Debug("Get unique post from server");
            Assert.AreEqual(200,ApiUtils.Get($"{_testCase.Url}{_testCase.PostsPath}/{postId}").Item1,"Wrong status code");
            return JsonSerializer.Deserialize<Post>(ApiUtils.Get($"{_testCase.Url}{_testCase.PostsPath}/{postId}").Item2);
        }
        
        public static User GetUniqueUserFromServer(int userId)
        {
            AqualityServices.Logger.Debug("Get unique user from server");
            Assert.AreEqual(200,ApiUtils.Get($"{_testCase.Url}{_testCase.UsersPath}/{userId}").Item1,"Wrong status code");
            return JsonSerializer.Deserialize<User>(ApiUtils.Get($"{_testCase.Url}{_testCase.UsersPath}/{userId}").Item2);
        }

        public static string GetPostJson(int postId)
        {
            AqualityServices.Logger.Debug("Get post json");
            Assert.AreEqual(404,ApiUtils.Get($"{_testCase.Url}{_testCase.PostsPath}/{postId}").Item1,"Wrong status code");
            return ApiUtils.Get($"{_testCase.Url}{_testCase.PostsPath}/{postId}").Item2;
        }

        public static Post PostUniquePost()
        {
            AqualityServices.Logger.Debug("Post unique post");
            using var reader = new StreamReader("101Post.json");
            var (statusCode, json) = ApiUtils.Post($"{_testCase.Url}{_testCase.PostsPath}", reader.ReadToEnd());
            Assert.AreEqual(201,statusCode,"Wrong status code");
            return JsonSerializer.Deserialize<Post>(json);
        }

        public static User GetUniqueUserFromUserList(int userId)
        {
            AqualityServices.Logger.Debug("Get unique user from user list");
            Assert.AreEqual(200,ApiUtils.Get($"{_testCase.Url}{_testCase.PostsPath}").Item1,"Wrong status code");
            var uniqueUser = new User();
            foreach (var user in JsonSerializer.Deserialize<List<User>>(ApiUtils.Get($"{_testCase.Url}{_testCase.UsersPath}").Item2).Where(user => user.Id==userId))
            {
                uniqueUser = user;
            }
            return uniqueUser;
        }
    }
}
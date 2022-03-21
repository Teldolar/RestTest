using System.IO;
using Aquality.Selenium.Browsers;
using Newtonsoft.Json;
using NUnit.Framework;
using TestProject1.Models;
using TestProject1.Utils;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace TestProject1.Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public static void Test()
        {
            AqualityServices.Logger.Debug("1 step");
            using (var reader = new StreamReader("AllPosts.json"))
            {
                Assert.AreEqual(reader.ReadToEnd().Replace("\r",""),AppApiUtils.GetAllPostsJson(),"You get wrong list of posts");
            }

            AqualityServices.Logger.Debug("2 step");
            using (var reader = new StreamReader("99Post.json"))
            {
                Assert.True(JsonSerializer.Deserialize<Post>(reader.ReadToEnd()).AreEqual(AppApiUtils.GetUniquePostFromServer(99)),"You get wrong 99 post");
            }
            
            using (var reader = new StreamReader("150Post.json"))
            {
                Assert.AreEqual(reader.ReadToEnd(),AppApiUtils.GetPostJson(150),"You get wrong 150 post");
            }
            
            AqualityServices.Logger.Debug("4 step");
            using (var reader = new StreamReader("101Post.json"))
            {
                    Assert.True(AppApiUtils.PostUniquePost().AreEqual(JsonSerializer.Deserialize<Post>(reader.ReadToEnd())),"title,body,userId parameters is wrong");
            }
            
            AqualityServices.Logger.Debug("5 step");
            var fifthUser = AppApiUtils.GetUniqueUserFromUserList(5); 
            using (var reader = new StreamReader("5User.json"))
            {
                Assert.True(fifthUser.AreEqual(JsonSerializer.Deserialize<User>(reader.ReadToEnd())),"User data is wrong");
            }
            
            AqualityServices.Logger.Debug("6 step");
            var user = AppApiUtils.GetUniqueUserFromServer(5);
            Assert.True(fifthUser.AreEqual(user),"user data is different");
        }
    }
}
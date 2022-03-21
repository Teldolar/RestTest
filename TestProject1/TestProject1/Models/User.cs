using System.Text.Json.Serialization;

namespace TestProject1.Models
{
    public class User
    {
        [JsonPropertyName("id")] public int Id { get; set; } 
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("username")] public string UserName { get; set; }
        [JsonPropertyName("email")] public string Email { get; set; }
        [JsonPropertyName("address")] public Address Address { get; set; }
        [JsonPropertyName("phone")] public string Phone { get; set; }
        [JsonPropertyName("website")] public string WebSite { get; set; }
        [JsonPropertyName("company")] public Company Company { get; set; }

        public bool AreEqual(User user)
        {
            return Id==user.Id&&Name==user.Name&&UserName==user.UserName&&Email==user.Email&&Address.AreEqual(user.Address)&&Phone==user.Phone&&WebSite==user.WebSite&&Company.AreEqual(user.Company);
        }
    }
        
    public class Address
    {
        [JsonPropertyName("street")] public string Street { get; set; }
        [JsonPropertyName("suite")] public string Suite { get; set; }
        [JsonPropertyName("city")] public string City { get; set; }
        [JsonPropertyName("zipcode")] public string ZipCode { get; set; }
        [JsonPropertyName("geo")] public Geo Geo { get; set; }
        
        public bool AreEqual(Address address)
        {
            return Street==address.Street&&Suite==address.Suite&&City==address.City&&ZipCode==address.ZipCode&&Geo.AreEqual(address.Geo);
        }
    }
        
    public class Geo
    {
        [JsonPropertyName("lat")] public string Lat { get; set; }
        [JsonPropertyName("lng")] public string Lng { get; set; }
        
        public bool AreEqual(Geo geo)
        {
            return Lat==geo.Lat&&Lng==geo.Lng;
        }
    }
        
    public class Company
    {
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("catchPhrase")] public string CatchPhrase { get; set; }
        [JsonPropertyName("bs")] public string Bs { get; set; }
        
        public bool AreEqual(Company company)
        {
            return Name==company.Name&&CatchPhrase==company.CatchPhrase&&Bs==company.Bs;
        }
    }
}
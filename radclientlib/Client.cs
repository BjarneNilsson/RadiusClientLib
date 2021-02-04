using System;
using System.Net.Http;
using System.Net.Http.Headers;

using System.Threading.Tasks;

namespace net.holmedal
{
    public class Client
    {
        public event EventHandler<UserAvalableArgs> UserAvalable;
        private Uri _BaseURI;
        private HttpClient _AClient = new HttpClient();
        public Client(string BaseUrl)
        {
            _BaseURI = new Uri(BaseUrl);
            _AClient.BaseAddress = _BaseURI ;
        }
        public async void GetUserAsync(string user)
        {
            _AClient.DefaultRequestHeaders.Accept
  .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var resp = await _AClient.GetAsync("GetUser?usr=" + user);
            User a = await resp.Content.ReadAsAsync<User>();
            _AClient.DefaultRequestHeaders.Accept.Remove(new MediaTypeWithQualityHeaderValue("application/json"));
            if (a.Password != null)
            {
                UserAvalable(this, new UserAvalableArgs(a.Name, a.Password, a.Vlan.Value));
            }
            else { }
        }
           
        public async  Task UpdateUser(string UserName, string Password,int vlan)
        {
            User a = new User() {Name =UserName,Password = Password, Vlan=vlan };
            
            await _AClient.PutAsJsonAsync("UpdateUser",a);
            
        }
        public async Task AddUser(string UserName,string Password,int vlan)
        {
            User a = new User()
            {
                Name = UserName,
                Password = Password,
                Vlan = vlan
            };
            await _AClient.PostAsJsonAsync("AddUser",a);
        }


    }
}

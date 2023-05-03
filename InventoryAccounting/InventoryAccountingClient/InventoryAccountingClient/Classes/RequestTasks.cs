using InventoryAccountingClient.Pages;
using InventoryAccountingWebApi.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace InventoryAccountingClient.Classes
{
    public class RequestTasks
    {

        public static async Task<List<Inventory>> GetInventory()
        {
            using (RestClient client = new RestClient())
            {
                RestRequest request = new RestRequest("http://www.inventoryaccounting.somee.com/api/Inventories/", Method.Get);
                var response = client.Execute(request);
                return JsonConvert.DeserializeObject<List<Inventory>>(response.Content);
            }
        }

        public static async Task<List<Category>> GetCategory()
        {
            using (RestClient client = new RestClient())
            {
                RestRequest request = new RestRequest("http://www.inventoryaccounting.somee.com/api/Categories/", Method.Get);
                var response = client.Execute(request);
                return JsonConvert.DeserializeObject<List<Category>>(response.Content);
            }
        }
        public static async Task<List<User>> GetUsers()
        {
            using (RestClient client = new RestClient())
            {
                RestRequest request = new RestRequest("http://www.inventoryaccounting.somee.com/api/Users/", Method.Get);
                var response = client.Execute(request);
                return JsonConvert.DeserializeObject<List<User>>(response.Content);
            }
        }
        public static async Task<List<Role>> GetRole()
        {
            using (RestClient client = new RestClient())
            {
                RestRequest request = new RestRequest("http://www.inventoryaccounting.somee.com/api/Roles/", Method.Get);
                var response = client.Execute(request);
                return JsonConvert.DeserializeObject<List<Role>>(response.Content);
            }
        }



        public static async Task<bool> DeleteInventory(int id)
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest($"http://www.inventoryaccounting.somee.com/api/Inventories/{id}", Method.Delete);
            RestResponse response = await client.DeleteAsync(request);
            return response.IsSuccessStatusCode;
        }
        public static async Task<bool> DeleteCategory(int id)
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest($"http://www.inventoryaccounting.somee.com/api/Categories/{id}", Method.Delete);
            RestResponse response = await client.DeleteAsync(request);
            return response.IsSuccessStatusCode;
        }
        public static async Task<bool> DeleteUsers(int id)
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest($"http://www.inventoryaccounting.somee.com/api/Users/{id}", Method.Delete);
            RestResponse response = await client.DeleteAsync(request);
            return response.IsSuccessStatusCode;
        }
        public static async Task<bool> DeleteRole(int id)
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest($"http://www.inventoryaccounting.somee.com/api/Roles/{id}", Method.Delete);
            RestResponse response = await client.DeleteAsync(request);
            return response.IsSuccessStatusCode;
        }


        public static async Task<bool> PostInventory(string name, int Quantity, int IdCategory)
        {
            RestResponse response;
            using (RestClient client = new RestClient())
            {
                var request = new RestRequest("http://www.inventoryaccounting.somee.com/api/Inventories", Method.Post);
                var body = new Inventory
                {
                    Name = name,
                    Quantity = Quantity,
                    IdCategory = IdCategory,
                };
                var bodyy = JsonConvert.SerializeObject(body);
                request.AddBody(bodyy);
                response = await client.ExecuteAsync(request);
            }
            return response.IsSuccessStatusCode;
        }
        public static async Task<bool> PostCategory(string name)
        {
            RestResponse response;
            using (RestClient client = new RestClient())
            {
                var request = new RestRequest("http://www.inventoryaccounting.somee.com/api/Categories", Method.Post);
                var body = new Category
                {
                    CategoryName = name,

                };
                var bodyy = JsonConvert.SerializeObject(body);
                request.AddBody(bodyy);
                response = await client.ExecuteAsync(request);
            }
            return response.IsSuccessStatusCode;
        }
        public static async Task<bool> PostUsers(string Login, string Password, int IdRole)
        {
            RestResponse response;
            using (RestClient client = new RestClient())
            {
                var request = new RestRequest("http://www.inventoryaccounting.somee.com/api/Users", Method.Post);
                var body = new User
                {

                    Login = Login,
                    Password = Password,
                    IdRole = IdRole

                };
                var bodyy = JsonConvert.SerializeObject(body);
                request.AddBody(bodyy);
                response = await client.ExecuteAsync(request);
            }
            return response.IsSuccessStatusCode;
        }
        public static async Task<bool> PostRole(string RoleName)
        {
            RestResponse response;
            using (RestClient client = new RestClient())
            {
                var request = new RestRequest("http://www.inventoryaccounting.somee.com/api/Roles", Method.Post);
                var body = new Role
                {
                    RoleName = RoleName,

                };
                var bodyy = JsonConvert.SerializeObject(body);
                request.AddBody(bodyy);
                response = await client.ExecuteAsync(request);
            }
            return response.IsSuccessStatusCode;
        }


        public static async Task<bool> PutInventory(int id, string name, int Quantity, int IdCategory)
        {
            RestResponse response;
            using (RestClient client = new RestClient())
            {
                var request = new RestRequest($"http://www.inventoryaccounting.somee.com/api/Inventories/{id}", Method.Put);
                var body = new Inventory
                {
                    Id = id,
                    Name = name,
                    Quantity = Quantity,
                    IdCategory = IdCategory
                };
                var bodyy = JsonConvert.SerializeObject(body);
                request.AddBody(bodyy);
                response = await client.PutAsync(request);
            }
            return response.IsSuccessStatusCode;
        }
        public static async Task<bool> PutCategory(int id, string name)
        {
            RestResponse response;
            using (RestClient client = new RestClient())
            {
                var request = new RestRequest($"http://www.inventoryaccounting.somee.com/api/Categories/{id}", Method.Put);
                var body = new Category
                {
                    Id = id,
                    CategoryName = name,

                };
                var bodyy = JsonConvert.SerializeObject(body);
                request.AddBody(bodyy);
                response = await client.PutAsync(request);
            }
            return response.IsSuccessStatusCode;
        }
        public static async Task<bool> PutUsers(int id, string Login, string Password, int IdRole)
        {
            RestResponse response;
            using (RestClient client = new RestClient())
            {
                var request = new RestRequest($"http://www.inventoryaccounting.somee.com/api/Users/{id}", Method.Put);
                var body = new User
                {
                    Id = id,
                    Login = Login,
                    Password = Password,
                    IdRole = IdRole
                };
                var bodyy = JsonConvert.SerializeObject(body);
                request.AddBody(bodyy);
                response = await client.PutAsync(request);
            }
            return response.IsSuccessStatusCode;
        }
        public static async Task<bool> PutRole(int id, string RoleName)
        {
            RestResponse response;
            using (RestClient client = new RestClient())
            {
                var request = new RestRequest($"http://www.inventoryaccounting.somee.com/api/Roles/{id}", Method.Put);
                var body = new Role
                {
                    Id = id,
                    RoleName = RoleName,
                };
                var bodyy = JsonConvert.SerializeObject(body);
                request.AddBody(bodyy);
                response = await client.PutAsync(request);
            }
            return response.IsSuccessStatusCode;
        }
    }
}

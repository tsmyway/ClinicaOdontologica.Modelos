using System.Text;
using Newtonsoft.Json;

namespace ClinicaOdontologica.Consumer;

public static class CRUD<T>
{
    public static string Endpoint { get; set; } = string.Empty;

    public static List<T> GetAll()
    {
        using (var cliente = new HttpClient())
        {
            var response = cliente.GetAsync(Endpoint).Result;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<T>>(json) ?? new List<T>();
            }
            else
            {
                throw new Exception($"Error en GetAll: {response.StatusCode} - {response.ReasonPhrase}");
            }
        }
    }

    public static T GetById(int id)
    {
        using (var cliente = new HttpClient())
        {
            var response = cliente.GetAsync($"{Endpoint}/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(json)!;
            }
            else
            {
                throw new Exception($"Error en GetById ({id}): {response.StatusCode} - {response.ReasonPhrase}");
            }
        }
    }

    public static T Create(T entity)
    {
        using (var cliente = new HttpClient())
        {
            var content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            var response = cliente.PostAsync(Endpoint, content).Result;
            
            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(json)!;
            }
            else
            {
                var errorDetail = response.Content.ReadAsStringAsync().Result;
                throw new Exception($"Error en Create: {response.StatusCode} - {errorDetail}");
            }
        }
    }

    public static bool Update(int id, T entity)
    {
        using (var cliente = new HttpClient())
        {
            var content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            var response = cliente.PutAsync($"{Endpoint}/{id}", content).Result;
            
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                var errorDetail = response.Content.ReadAsStringAsync().Result;
                throw new Exception($"Error en Update ({id}): {response.StatusCode} - {errorDetail}");
            }
        }
    }

    public static bool Delete(int id)
    {
        using (var cliente = new HttpClient())
        {
            var response = cliente.DeleteAsync($"{Endpoint}/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                var errorDetail = response.Content.ReadAsStringAsync().Result;
                throw new Exception($"Error en Delete ({id}): {response.StatusCode} - {errorDetail}");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using LeafGreen.App.Models;
using Newtonsoft.Json;

namespace LeafGreen.App.Services
{
    public class GardenApi : IGardenApi
    {
        public async Task<Garden> AddGardenAsync(Garden garden)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("http://leafgreen-dev.azurewebsites.net");
                var json = JsonConvert.SerializeObject(garden);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(new Uri("/api/garden"), content);
                return response.IsSuccessStatusCode ? JsonConvert.DeserializeObject<Garden>(await response.Content.ReadAsStringAsync()) : new Garden();
            }
        }

        public async Task<List<Garden>> GetGardensByDeviceIdAsync(string deviceId)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("http://leafgreen-dev.azurewebsites.net");
                    var response = await httpClient.GetAsync(new Uri($"/api/garden/{deviceId}/gardens"))
                        .ConfigureAwait(false);
                    return response.IsSuccessStatusCode
                        ? JsonConvert
                            .DeserializeObject<List<Garden>>(await response.Content.ReadAsStringAsync()
                                .ConfigureAwait(false)).ToList()
                        : new List<Garden>();
                }
            }
            catch (Exception ex)
            {
                return new List<Garden>();
            }
        }

        public async Task<Garden> GetGardenByIdAsync(int gardenId)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("http://leafgreen-dev.azurewebsites.net");
                var response = await httpClient.GetAsync(new Uri($"/api/garden/{gardenId}"));
                return response.IsSuccessStatusCode ?
                    JsonConvert.DeserializeObject<Garden>(await response.Content.ReadAsStringAsync()) : new Garden();
            }
        }
    }
}

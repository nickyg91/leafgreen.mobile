using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LeafGreen.App.Models;

namespace LeafGreen.App.Services
{
    public interface IGardenApi
    {
        Task<Garden> AddGardenAsync(Garden garden);
        Task<List<Garden>> GetGardensByDeviceIdAsync(string deviceId);
        Task<Garden> GetGardenByIdAsync(int garden);
    }
}

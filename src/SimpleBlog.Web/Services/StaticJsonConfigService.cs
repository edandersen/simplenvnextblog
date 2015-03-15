using SimpleBlog.Shared;
using System;
using SimpleBlog.ViewModels;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace SimpleBlog.Services
{
    public class StaticJsonConfigService : IConfigService
    {
        public async Task<ConfigViewModel> LoadConfigAsync()
        {
            using (var fileStream = System.IO.File.OpenText(System.IO.Path.Combine(AppContext.BaseDirectory + "\\Config\\config.json")))
            {
                var jsonConfig = await fileStream.ReadToEndAsync();

                return JsonConvert.DeserializeObject<ConfigViewModel>(jsonConfig);
            }
        }
    }
}
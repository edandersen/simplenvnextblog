using SimpleBlog.ViewModels;
using System;
using System.Threading.Tasks;

namespace SimpleBlog.Shared
{
    public interface IConfigService
    {
        Task<ConfigViewModel> LoadConfig();
    }
}
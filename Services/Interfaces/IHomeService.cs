using R4G.App.ViewModels;

namespace R4G.App.Services.Interfaces
{
    public interface IHomeService
    {
        Task<HomeViewModel> BuildHomeViewModel(string userId);
    }
}
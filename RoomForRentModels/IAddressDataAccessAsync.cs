using System.Threading.Tasks;


namespace RoomForRentModels
{
    public interface IAddressDataAccessAsync
    {
        #region Abstract
        Task DeleteDistrictAsync(int districtId);
        Task DeleteProvinceAsync(int provinceId);
        Task DeleteWardAsync(int wardId);
        Task<District[]> GetDistrictsAsync(int provinceId);
        Task<Province[]> GetProvincesAsync();
        Task<Ward[]> GetWardsAsync(int districtId);
        Task<District> SaveDistrictAsync(District district);
        Task<Province> SaveProvinceAsync(Province province);
        Task<Ward> SaveWardAsync(Ward ward);
        #endregion
    }
}
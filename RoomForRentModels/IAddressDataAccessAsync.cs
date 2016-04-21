using System.Threading.Tasks;


namespace RoomForRentModels
{
    public interface IAddressDataAccessAsync
    {
        #region Abstract
        Task<District[]> GetDistrictsAsync(int provinceId);
        Task<Province[]> GetProvincesAsync();
        Task<Ward[]> GetWardsAsync(int districtId);
        Task<District> SaveDistrictAsync(District district);
        Task<Province> SaveProvinceAsync(Province province);
        Task<Ward> SaveWardAsync(Ward ward);
        #endregion
    }
}
using System.Threading.Tasks;


namespace RoomForRentModels
{
    public interface IAddressDataAccessAsync
    {
        #region Abstract
        Task<District[]> GetDistrictsAsync(int provinceId);
        Task<Province[]> GetProvincesAsync();
        Task<Ward[]> GetWardsAsync(int districtId);
        #endregion
    }
}
namespace RoomForRentModels
{
    public interface IAddressDataAccessSync
    {
        #region Abstract
        District[] GetDistricts(int provinceId);
        Province[] GetProvinces();
        Ward[] GetWards(int districtId);
        #endregion
    }
}
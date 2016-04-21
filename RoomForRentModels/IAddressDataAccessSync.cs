namespace RoomForRentModels
{
    public interface IAddressDataAccessSync
    {
        #region Abstract
        District[] GetDistricts(int provinceId);
        Province[] GetProvinces();
        Ward[] GetWards(int districtId);
        District SaveDistrict(District district);
        Province SaveProvince(Province province);
        Ward SaveWard(Ward ward);
        #endregion
    }
}
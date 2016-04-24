namespace RoomForRentModels
{
    public interface IAddressDataAccessSync
    {
        #region Abstract
        void DeleteDistrict(int districtId);
        void DeleteProvince(int provinceId);
        void DeleteWard(int wardId);
        District[] GetDistricts(int provinceId);
        Province[] GetProvinces();
        Ward[] GetWards(int districtId);
        District SaveDistrict(District district);
        Province SaveProvince(Province province);
        Ward SaveWard(Ward ward);
        #endregion
    }
}
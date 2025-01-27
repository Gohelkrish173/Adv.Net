using Practice_Web_API.DATA;
using Practice_Web_API.Models;

namespace Practice_Web_API.BAL
{
    public class District_BALbase
    {
        private readonly DistrictRepository districtRepository;

        public District_BALbase(DistrictRepository districtRepository)
        {
            this.districtRepository = districtRepository;
        }

        #region GetAllDistricts
        public List<DistrictModel> GetAllDistricts()
        {
            try
            {
                List<DistrictModel> districts = districtRepository.GetAllDistricts().ToList();
                if (districts != null && districts.Count > 0)
                {
                    return districts;
                }
                else
                {
                    return [];
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}

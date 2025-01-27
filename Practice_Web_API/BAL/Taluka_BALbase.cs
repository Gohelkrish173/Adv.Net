using Practice_Web_API.DATA;
using Practice_Web_API.Models;

namespace Practice_Web_API.BAL
{
    public class Taluka_BALbase
    {
        private readonly TalukaRepository talukaRepository;

        public Taluka_BALbase(TalukaRepository talukaRepository)
        {
            this.talukaRepository = talukaRepository;
        }

        #region GetAllTalukas
        public List<TalukaModel> GetAllTalukas()
        {
            try
            {
                List<TalukaModel> talukas = talukaRepository.GetAllTalukas().ToList();
                if (talukas != null && talukas.Count > 0)
                {
                    return talukas;
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

using Practice_Web_API.DATA;
using Practice_Web_API.Models;

namespace Practice_Web_API.BAL
{
    public class State_BALbase
    {
        private readonly StateRepository stateRepository;

        public State_BALbase(StateRepository stateRepository)
        {
            this.stateRepository = stateRepository;
        }

        #region GetAllStates
        public List<StateModel> GetAllStates()
        {
            try
            {
                List<StateModel> states = stateRepository.GetAllStates().ToList();
                if (states != null && states.Count > 0)
                {
                    return states;
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


using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;

namespace RequestTrackerBLLibrary
{
    public class FeedbackBL
    {
        private readonly IRepository<int, SolutionFeedback> _repository;
        public FeedbackBL()
        {
            RequestTrackerContext requestTrackerContext = new RequestTrackerContext();
            _repository = new SolutionFeedbackRepository(requestTrackerContext);
        }

        public async Task<IList<SolutionFeedback>> GetAllFeedbacks()
        {
            return await _repository.GetAll();
        }

        public async Task CreateFeedback(int solutionId, string remark, int feedbackBy)
        {
            var solution = new SolutionFeedback { SolutionId = solutionId, Remarks = remark, FeedbackBy = feedbackBy };
            await _repository.Add(solution);
        }


    }
}

using Microsoft.EntityFrameworkCore;
using RequestTrackerModelLibrary;

namespace RequestTrackerDALLibrary
{
    public class SolutionFeedbackRepository : IRepository<int, SolutionFeedback>
    {
        protected readonly RequestTrackerContext _context;

        public SolutionFeedbackRepository(RequestTrackerContext context)
        {
            _context = context;
        }
        public async Task<SolutionFeedback> Add(SolutionFeedback entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<SolutionFeedback> Delete(int key)
        {
            var requestSolution = await Get(key);
            if (requestSolution != null)
            {
                _context.Feedbacks.Remove(requestSolution);
                await _context.SaveChangesAsync();
            }
            return requestSolution;
        }

        public virtual async Task<SolutionFeedback> Get(int key)
        {
            var requestSolution = _context.Feedbacks.SingleOrDefault(e => e.FeedbackId == key);
            return requestSolution;
        }

        public virtual async Task<IList<SolutionFeedback>> GetAll()
        {
            return await _context.Feedbacks.ToListAsync();
        }

         public virtual async Task<IList<SolutionFeedback>> GetAll(int empId)
        {
            return await _context.Feedbacks.Where(s=>s.FeedbackBy == empId).ToListAsync();
        }

        public async Task<SolutionFeedback> Update(SolutionFeedback entity)
        {
            var requestSolution = await Get(entity.FeedbackId);
            if (requestSolution != null)
            {
                _context.Entry<SolutionFeedback>(requestSolution).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return requestSolution;
        }
    }
}


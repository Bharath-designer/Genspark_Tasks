using Microsoft.EntityFrameworkCore;
using RequestTrackerModelLibrary;


namespace RequestTrackerDALLibrary
{
    public class RequestSolutionRequestRepository : RequestRepository
    {
        public RequestSolutionRequestRepository(RequestTrackerContext context) : base(context)
        {
        }
        public  async override Task<IList<Request>> GetAll()
        {
            return await _context.Requests.Include(e => e.RequestSolutions).ToListAsync();
        }
        public async override Task<Request> Get(int key)
        {
            var request =  _context.Requests.Include(e => e.RequestSolutions).SingleOrDefault(e => e.RequestNumber == key);
            return request;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;

namespace RequestTrackerBLLibrary
{
    public class RequestBL
    {
        private readonly RequestRepository _repository;
        public RequestBL() { 
            RequestTrackerContext requestTrackerContext = new RequestTrackerContext();
            _repository = new RequestRepository(requestTrackerContext);
        }

        public async Task CreateRequest(string Message, int RequestRaisedBy)
        {
            Request request = new Request { RequestMessage = Message, RequestRaisedBy = RequestRaisedBy, RequestStatus = "Initial"};
            await _repository.Add(request);
        }

        public async Task<IList<Request>> GetAllRequest()
        {
            return await _repository.GetAll();
        }

        public async Task<IList<Request>> GetAllRequest(int empId)
        {
            return await _repository.GetAll(empId);
        }

        public async Task CloseRequest(int requestId, int closedBy)
        {
            var request = await _repository.Get(requestId);
            request.RequestClosedBy = closedBy;
            request.ClosedDate = DateTime.Now;
            request.RequestStatus = "Closed";
            await _repository.Update(request);

        }


    }
}

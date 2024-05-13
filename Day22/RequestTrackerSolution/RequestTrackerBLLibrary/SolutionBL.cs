using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;

namespace RequestTrackerBLLibrary
{
    public class SolutionBL
    {
        private readonly RequestSolutionRepository _repository;
        public SolutionBL()
        {
            RequestTrackerContext requestTrackerContext = new RequestTrackerContext();
            _repository = new RequestSolutionRepository(requestTrackerContext);
        }

        public async Task<IList<RequestSolution>> GetAllSolutions()
        {
            return await _repository.GetAll();
        }

        public async Task<IList<RequestSolution>> GetAllSolutions(int empId)
        {
            return await _repository.GetAll(empId);
        }

        public async Task CreateSolution(int requestId, string solutionDescription, int solvedBy)
        {
            var solution  = new RequestSolution { RequestId=requestId, SolutionDescription= solutionDescription, SolvedBy = solvedBy };
            await _repository.Add(solution);
        }
    }
}

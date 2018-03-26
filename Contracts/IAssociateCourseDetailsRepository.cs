using Entities.Models;
using System.Collections.Generic;

namespace Contracts
{
    public interface IAssociateCourseDetailsRepository : IRepositoryBase<AssociateCourseDetails>
    {
        IEnumerable<AssociateCourseDetails> GetAssociateCourseDetails();
        void SaveAssociateCourseDetails(IList<AssociateCourseDetails> associateCourseDetails);
    }
}

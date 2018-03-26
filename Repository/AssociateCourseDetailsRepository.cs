using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contracts;
using Entities;
using Entities.Models;
namespace Repository
{
    public class AssociateCourseDetailsRepository : RepositoryBase<AssociateCourseDetails>, IAssociateCourseDetailsRepository
    {
        public AssociateCourseDetailsRepository(RepositoryContext repositoryContext) : base(repositoryContext){

        }
        public IEnumerable<AssociateCourseDetails> GetAssociateCourseDetails()
        {
            return GetAll();
        }

        public void SaveAssociateCourseDetails(IList<AssociateCourseDetails> associateCourseDetails) {
            Save(associateCourseDetails);
        }
    }
}

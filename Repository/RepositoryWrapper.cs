using System;
using System.Collections.Generic;
using System.Text;
using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        public IAssociateCourseDetailsRepository associateCourseDetailsRepository { get; set; }

        public RepositoryWrapper(RepositoryContext repositoryContext) {
            associateCourseDetailsRepository = new AssociateCourseDetailsRepository(repositoryContext);
        }
    }
}

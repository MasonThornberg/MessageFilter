using System;
using System.Collections.Generic;
using System.Text;

namespace MessageFilter.Repository
{
    public interface ISensitiveTermsRepository
    {
        IEnumerable<string> GetTerms();
    }
}

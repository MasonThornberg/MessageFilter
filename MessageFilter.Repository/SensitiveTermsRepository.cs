using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MessageFilter.Repository
{
    public class SensitiveTermsRepository : ISensitiveTermsRepository
    {
        public IEnumerable<string> GetTerms()
        {
            List<string> terms = new List<string> { "Death Star", "rouge squadron", "Yavin", "Hoth", "(admiral|general|commander) \\b.*\\b", "\\b.*\\b base" };

            //this would be handled in the query if possible for performance.
            //Sorting by length descendig ensures that if there is a pair of phrases like "hoth" and "hoth base", the full longer item will be censored. 
            terms = terms.OrderByDescending(x => x.Length).ToList();

            return terms;
        }
    }
}

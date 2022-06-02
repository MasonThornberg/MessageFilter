using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using MessageFilter.Common.Models;
using MessageFilter.Repository;

namespace MessageFilter.Service
{
    public class FilterService : IFilterService
    {

        private static readonly string CENSOR_PHRASE = "*****";
        private readonly ISensitiveTermsRepository _sensitiveTermsRepository;
        private List<string> sensitiveTerms;

        public FilterService(ISensitiveTermsRepository sensitiveTermsRepository)
        {
            _sensitiveTermsRepository = sensitiveTermsRepository;
            sensitiveTerms = _sensitiveTermsRepository.GetTerms().ToList();
        }

        public FilterEmailResponseModel EmailFilter(string messageBody)
        {
            var filterResponse = filter(messageBody);

            return new FilterEmailResponseModel { IsFlagged = filterResponse.Item1, MessageBody = filterResponse.Item2 };
        }

        private Tuple<bool, string> filter(string messageBody)
        {
            string filteredMessageBody = messageBody;
            Regex pattern;

            sensitiveTerms.ForEach(x => {
                pattern = new Regex(x, RegexOptions.IgnoreCase);
                filteredMessageBody = pattern.Replace(filteredMessageBody, CENSOR_PHRASE);
            });

            bool isFlagged = !(messageBody.Equals(filteredMessageBody));

            return Tuple.Create(isFlagged, filteredMessageBody);
        }


    }
}

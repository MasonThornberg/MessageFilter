using MessageFilter.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessageFilter.Service
{
    public interface IFilterService
    {
        FilterEmailResponseModel EmailFilter(string messageBody);
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace MessageFilter.Common.Models
{
    public class FilterEmailResponseModel
    {
        public string MessageBody { get; set; }
        public bool IsFlagged { get; set; }
    }
}

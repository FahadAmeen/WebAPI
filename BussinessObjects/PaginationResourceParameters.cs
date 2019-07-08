﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BussinessObjects
{
    public abstract class PaginationResourceParameters
    {
        private const int MaxPageSize = 28;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 16;

        public int PageSize
        {
            get=> _pageSize;
           // set => _pageSize ={ value > MaxPageSize} ? MaxPageSize:value;
    }

}
}
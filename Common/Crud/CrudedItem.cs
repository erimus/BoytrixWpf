﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boytrix.Logic.Business.Common
{
    public  class  CrudedItem<T> where T:class
    {
        public  string SqlStatement { get; set; }
        public  T DataRow { get; set; }
        public  FormMode FormState { get; set; }
    }
}

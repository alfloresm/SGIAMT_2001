﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAO;
using DTO;

namespace CTR
{
    public class CtrCategoria
    {
        DaoCategoria objDaoCategoria;
        public CtrCategoria()
        {
            objDaoCategoria = new DaoCategoria();
        }
        
    }
}

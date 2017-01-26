﻿using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IFrageRepository
    {
        Frage SearchFrageById(int id);
        List<Frage> SearchFrageBySparte(Sparte sparte);
    }
}

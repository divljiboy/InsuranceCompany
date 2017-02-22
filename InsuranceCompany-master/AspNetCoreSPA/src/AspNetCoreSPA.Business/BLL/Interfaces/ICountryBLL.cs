﻿using System.Collections.Generic;
using AspNetCoreSPA.Model.POCOs;

namespace AspNetCoreSPA.BLL
{
    public interface ICountryBLL
    {
        List<StateOfOrigin> GetAll();
        int Add(StateOfOrigin c);
    }
}

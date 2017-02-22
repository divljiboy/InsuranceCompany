using System;
using System.Collections.Generic;
using System.Linq;
using AspNetCoreSPA.Model.POCOs;
using AspNetCoreSPA.DAL;

namespace AspNetCoreSPA.BLL
{
    public class CountryBLL : ICountryBLL
    {
        private readonly IRepository<StateOfOrigin> _countryDAL;

        public CountryBLL(IRepository<StateOfOrigin> countryDAL)
        {
            _countryDAL = countryDAL;
        }

        public int Add(StateOfOrigin c)
        {
            throw new NotImplementedException();
        }

        public List<StateOfOrigin> GetAll()
        {
            try
            {
                return _countryDAL.GetAll().ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

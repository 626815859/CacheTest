using CacheTest.DAL;
using CacheTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheTest.BLL
{
  public  class PersonBll
    {
        PersonDal personDal = new PersonDal();
        public Person GetPersonById(int id)
        {
            return personDal.GetPersonById(id);
        }
        public bool AddPerson(string name)
        {
            return personDal.AddPerson(name);

        }
    }
}

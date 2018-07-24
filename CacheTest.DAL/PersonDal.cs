using CacheTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheTest.DAL
{
   public class PersonDal
    {

        Model1Container dbContext = new Model1Container();

        public Person GetPersonById(int id)
        {
           return dbContext.Set<Person>().Where(u=>u.Id==id).FirstOrDefault();
        }
        public bool AddPerson(string name)
        {
            Person p = new Person() { Name = name, Book = null };
            dbContext.Set<Person>().Add(p);
            if(dbContext.SaveChanges()>0)
            {
                return true;

            }
            else
            {
                return false;
            }

        }

    }
}

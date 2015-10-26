using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;

namespace DalMock
{
  public class PersonDal : Dal.IPersonDal
  {
    public PersonDto GetPerson(int id)
    {
      return new PersonDto { Id = id, Name = "Maria Kowalski" };
    }
  }
}

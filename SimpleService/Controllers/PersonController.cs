using System.Web.Http;

namespace SimpleService.Controllers
{
  public class PersonController : ApiController
  {
    // GET: api/Person/5
    public Contracts.PersonContract Get(int id)
    {
      var person = BusinessLibrary.PersonEdit.GetPersonEdit(id);
      return new Contracts.PersonContract
      {
        Id = person.Id,
        Name = person.Name
      };
    }
  }
}

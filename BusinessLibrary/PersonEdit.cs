using System;
using System.ComponentModel.DataAnnotations;
using Csla;
using System.Threading.Tasks;

namespace BusinessLibrary
{
  [Serializable]
  public class PersonEdit : BusinessBase<PersonEdit>
  {
    public static readonly PropertyInfo<int> IdProperty = RegisterProperty<int>(c => c.Id);
    public int Id
    {
      get { return GetProperty(IdProperty); }
      private set { SetProperty(IdProperty, value); }
    }

    public static readonly PropertyInfo<string> NameProperty = RegisterProperty<string>(c => c.Name);
    [Required]
    public string Name
    {
      get { return GetProperty(NameProperty); }
      set { SetProperty(NameProperty, value); }
    }


    public static async Task<PersonEdit> GetPersonEditAsync(int id)
    {
      return await DataPortal.FetchAsync<PersonEdit>(id);
    }

#if !NETFX_CORE
    public static PersonEdit GetPersonEdit(int id)
    {
      return DataPortal.Fetch<PersonEdit>(id);
    }
#endif

    private void DataPortal_Fetch(int id)
    {
      var dal = Dal.DalFactory.GetDal<Dal.IPersonDal>();
      var dto = dal.GetPerson(id);
      using (BypassPropertyChecks)
      {
        Id = dto.Id;
        Name = dto.Name;
      }
    }
  }
}

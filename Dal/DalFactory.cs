using System;

namespace Dal
{
  public static class DalFactory
  {
    public static T GetDal<T>()
    {
      Type dalType = null;
      if (typeof(T) == typeof(IPersonDal))
        dalType = Type.GetType("DalMock.PersonDal, DalMock");

      if (dalType != null)
        return (T)Activator.CreateInstance(dalType);
      else
        throw new Exception("DAL type not found");
    }
  }
}

using Microsoft.EntityFrameworkCore;
using SelfAssignment_MvcVersion.Models;

namespace SelfAssignment_MvcVersion.Business
{
    public class UserInfoManagar
    {
        public bool CreateRecord<T>(T tableEntity)
        {
            try
            {
                using (SelfAssignmentContext _db = new())
                {
                    _db.Entry(tableEntity).State = EntityState.Added;
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}

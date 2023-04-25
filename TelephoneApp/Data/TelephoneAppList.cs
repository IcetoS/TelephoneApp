using Microsoft.AspNetCore.Identity;

namespace TelephoneApp.Data
{
    public class TelephoneAppList
    {
        public int Id { get; set; }
        public virtual IdentityUser NameOfUser { get; set; }
        public int TelephoneNumber { get; set; }

        public DateTime LastCall { get; set; }

        public virtual TelephoneApp1 TelephoneApp { get; set; }

        public class Data
        {
        }
    }
}

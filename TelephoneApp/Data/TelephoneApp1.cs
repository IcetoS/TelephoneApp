using Microsoft.AspNetCore.Identity;

namespace TelephoneApp.Data
{
    public class TelephoneApp1
    {
        public TelephoneApp1()
        {
            items = new List<TelephoneAppList>();
        }
        public int Id { get; set; }

        public string UserId { get; set; }
        public virtual IdentityUser User { get; set; }
        public string Name { get; set; }

        public virtual List<TelephoneAppList> items { get; set; }

        public class Data
        {
            public class TelephoneApp1
            {
            }
        }
    }
}

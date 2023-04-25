namespace TelephoneApp.Data
{
    public class UserInfo
    {
        public string UserFurstName { get; set; }

        public string UserFamilyName { get; set; }

        public int UserPhoneNumber { get; set; }

        public List<TelephoneAppList> TelephoneLists { get; set; }
    }
}

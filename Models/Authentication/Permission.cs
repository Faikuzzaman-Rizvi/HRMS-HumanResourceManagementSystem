namespace HRMS.Models.Authentication
{
    public class Permission
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Module { get; set; }
        public string Action { get; set; } // Create, Read, Update, Delete
    }
}

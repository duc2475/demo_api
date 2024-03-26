using System.ComponentModel.DataAnnotations;

namespace demo_api_swagger.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string UserFName { get; set; }
        public string UserLName { get; set; } 
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace Users.API.Models
{
    public class User
    {
        [Key]   
        public Guid Id { get; set; }

        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public int UserAge { get; set; }
    }
}

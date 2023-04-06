using System.ComponentModel.DataAnnotations;

namespace teste_react_api.Entities

{
    public class UserAdress
    {
        [Key]
        public Guid Id { get; set; }
        public string Adress { get; set; }
    }
}

namespace teste_react_api.Entities
{
    public class User
    {
        public User ()
        {
            Adress = new List<UserAdress>();
            IsDeleted = false;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Cpf { get; set; }

        public List<UserAdress> Adress { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public bool IsDeleted { get; set; }


        public void Update(string name, string email, string password, string phone )
        {
            Name = name;
            Email = email;
            Password = password;
            Phone = phone;
        }

        public void Delete()
        {
            IsDeleted = true;
        }

    }
}

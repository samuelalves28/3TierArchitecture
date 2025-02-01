namespace Data.Models;

public class User
{
    public User(int id, string name, string lastName, string email, string password)
    {
        Id = id;
        Name = name;
        LastName = lastName;
        Email = email;
        Password = password;
    }

    public int Id { get; private set; }
    public string Name { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }


    public void Update(string name, string lastName, string email, string password)
    {
        Name = name;
        LastName = lastName;
        Email = email;
        Password = password;
    }
}

namespace TeamsLektion4;

public interface IdGenerator
{
    int Generate();
}

public class CountingGenerator : IdGenerator
{
    private int counter = 0;
    public int Generate()
    {
        return counter++;
    }
}

public enum UserType {
    Student,
    Teacher,
}

public class User
{
    private int _id;
    public int Id { get { return _id; } }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

    private string _password;
    public string Password { get { return _password; } }

    public User(IdGenerator generator, string firstName, string lastName, string email, string password)
    {
        this._id = generator.Generate();
        this.Email = email;
        this.FirstName = firstName;
        this.LastName = lastName;
        this._password = password;
    }
}

public class Student : User {
    public Student(IdGenerator generator, string firstName, string lastName, string email, string password) 
      : base(generator, firstName, lastName, email, password) { }
}

public class Teacher : User
{
    // TODO: Kurser

    public Teacher(IdGenerator generator, string firstName, string lastName, string email, string password) 
      : base(generator, firstName, lastName, email, password) { }
}

public class Administrator : User
{
    public Administrator(IdGenerator generator) 
      : base(generator, "admin", "admin", "admin@admin.com", "123") { }
}


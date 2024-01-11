namespace TeamsLektion4;

// Vi skapar ett interface för användarsystemet som lägger upp vad som skall
// kunna vara möjligt att göra. 
// Med andra ord: man skall kunna registrera användare, logga in och ut.
// Vi lägger dock inte in en specifik implementation (därvav interface) eftersom vi vill
// kunna ändra på beteendet om vi vill.
// Med ett interface kan vi enkelt ha olika versioner, såsom "DatabaseUserService", "LocalUserService" och "TestUserService".
public interface IUserService
{
    User Register(string firstName, string lastName, string email, string password, UserType type);
    User? Login(string email, string password);
    void Logout();
}

// En version/implementation av interfacet som sparar alla användare i en lokal lista.
// Den skall användas av det "riktiga" programmet.
public class LocalUserService : IUserService
{
    private IdGenerator idGenerator;
    private List<User> users;
    private User? loggedIn;

    public LocalUserService(IdGenerator idGenerator)
    {
        this.users = new List<User>();
        this.idGenerator = idGenerator;
        this.loggedIn = null;
    }

    public User Register(string firstName, string lastName, string email, string password, UserType type)
    {
        // TODO: Checks

        User user;
        if (type == UserType.Teacher)
        {
            user = new Teacher(idGenerator, firstName, lastName, email, password);
        }
        else if (type == UserType.Student)
        {
            user = new Student(idGenerator, firstName, lastName, email, password);
        }
        else
        {
            throw new ArgumentException("No such type exists");
        }

        this.users.Add(user);
        return user;
    }

    public User? Login(string email, string password)
    {
        // Vi letar efter en användare som matchar med "email" och "password".
        foreach (User user in this.users)
        {
            if (user.Email != email || user.Password != password)
            {
                continue;
            }

            this.loggedIn = user;
            return user;
        }

        return null;
    }

    public void Logout()
    {
        this.loggedIn = null;
    }
}
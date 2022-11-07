using NinjaNye.SearchExtensions;
using System.Text;
using ManagementSoftware.Models;
using ManagementSoftware.ViewModels;

namespace ManagementSoftware.DAL;

public class DALUser
{
    public static User? AuthLogin(string username, string password)
    {
        DataBaseContext dbContext = new DataBaseContext();
        User? user = (from u in dbContext.Users where (u.Username == username.Trim() && u.Password == password.Trim()) select u).FirstOrDefault();
        return user;
    }

    public static List<UserHasGroupName> GetAllUsersHasGroupName()
    {
        DataBaseContext dbContext = new DataBaseContext();
        var list = (from user in dbContext.Users
                    join gr in dbContext.Groups on user.GroupID equals gr.GroupID
                    select new UserHasGroupName
                    {
                        UserID = user.UserID,
                        FullName = user.FullName,
                        Username = user.Username,
                        Password = user.Password,
                        GroupName = gr.GroupName
                    }).ToList();
        return list;
    }

    public static List<User> FindUserByFullNameOrUsername(string name)
    {
        DataBaseContext dbContext = new DataBaseContext();
        var list = (dbContext.Users.Search(x => x.Username, x => x.FullName).Containing(name)).ToList();
        return list;
    }


    public static User? GetUserFromID(int id)
    {
        DataBaseContext dbContext = new DataBaseContext();
        var user = (from u in dbContext.Users where (u.UserID == id) select u).FirstOrDefault();
        return user;
    }


    // Them TK
    public static int AddUser(User user)
    {
        DataBaseContext dbContext = new DataBaseContext();
        dbContext.Users.Add(user);
        // số dòng thay đổi lớn hơn 0 thì đúng
        return dbContext.SaveChanges();

    }

    // Sua TK
    public static int UpdateUser(User user)
    {
        DataBaseContext dbContext = new DataBaseContext();
        var userUpdate = dbContext.Users.FirstOrDefault(u => u.Username == user.Username);
        if (userUpdate != null)
        {
            userUpdate.Username = user.Username;
            userUpdate.Password = user.Password;
            userUpdate.FullName = user.FullName;
            userUpdate.GroupID = user.GroupID;
        }

        return dbContext.SaveChanges();
    }

    public static int DeleteUser(string username)
    {
        DataBaseContext dbContext = new DataBaseContext();
        var userDelete = dbContext.Users.FirstOrDefault(u => u.Username == username);
        if (userDelete != null)
        {
            dbContext.Users.Remove(userDelete);
        }
        return dbContext.SaveChanges();

    }


    public static User? GetUserFromUsername(string username)
    {
        DataBaseContext dbContext = new DataBaseContext();
        return dbContext.Users.Where(u => u.Username == username).FirstOrDefault();
    }

    public static List<string>? GetListUsername()
    {
        DataBaseContext dbContext = new DataBaseContext();
        return dbContext.Users.Select(u => u.Username).ToList();
    }
}



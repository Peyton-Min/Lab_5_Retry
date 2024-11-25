using Lab_5_Web_App_Dev.Data;
using static System.Reflection.Metadata.BlobBuilder;
//WHY WON"T ANYTHING PUSH TEST TEST TEST
//TESTY MC TESTERSON
//TEST TEST TEST
namespace Lab_5_Web_App_Dev.Services
{
    public class UserServices
    {
        public List<User> users { get; set; } = new List<User>();
        /// <summary>
        /// Retrieves all of the users from the Users.csv file
        /// </summary>
        public void ReadUsers()
        {
            try
            {
                foreach (var line in File.ReadLines("./Data/Users.csv"))
                {
                    var fields = line.Split(',');

                    if (fields.Length >= 3)
                    {
                        var user = new User
                        {
                            Id = int.Parse(fields[0].Trim()),
                            Name = fields[1].Trim(),
                            Email = fields[2].Trim()
                        };

                        users.Add(user);
                    }
                }
                Console.WriteLine($"Users successfully read. Count:{users.Count} user: {users}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        /// <summary>
        /// Allows a user to add another user profile to the Users.csv
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        public void AddUser(string name, string email)
        {
            int id = users.Any() ? users.Max(b => b.Id) + 1 : 1;
            var newUser = new User { Id = id, Name = name, Email = email };

            users.Add(newUser);

            using (StreamWriter writer = File.AppendText("./Data/Users.csv"))
            {
                writer.WriteLine($"{id},{name},{email}");
            }
        }

        /// <summary>
        /// Allows a user to edit a previously made user profile saved within Users.csv
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="email"></param>
        public void EditUser(int id, string name, string email)
        {
            var user = users.FirstOrDefault(b => b.Id == id);
            if (user != null)
            {
                user.Name = name;
                user.Email = email;

                using (StreamWriter writer = new StreamWriter("./Data/Users.csv"))
                {
                    foreach (var b in users)
                    {
                        writer.WriteLine($"{b.Id},{b.Name},{b.Email}");
                    }
                }
            }
        }


        /// <summary>
        /// Allows a user to delete a previously made user within the Users.csv
        /// </summary>
        /// <param name="id"></param>
        public void DeleteUser(int id)
        {
            var user = users.FirstOrDefault(b => b.Id == id);
            if (user != null)
            {
                users.Remove(user);

                using (StreamWriter writer = new StreamWriter("./Data/Users.csv"))
                {
                    foreach (var b in users)
                    {
                        writer.WriteLine($"{b.Id},{b.Name},{b.Email}");
                    }
                }
                Console.WriteLine($"User with ID {id} deleted successfully.");
            }
            else
            {
                Console.WriteLine($"No user found with ID {id}.");
            }
        }

        /// <summary>
        /// Returns an IEnumerable containing every user in the Users.csv, organizaed by their Id.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<dynamic> ListUsers()
        {
            var userGroups = users.GroupBy(b => b.Id).Select(userGroup => new { User = userGroup.First(), Count = userGroup.Count() });

            return userGroups;
        }
    }
}

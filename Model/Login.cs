namespace GenSolveTest.Model
{
    
    public class Login
    {

        public string Organisation;
        public string Username;
        public string Password;

        public Login(string organisation, string username, string password)
        {
            Organisation = organisation;
            Username = username;
            Password = password;
        }
    };

}

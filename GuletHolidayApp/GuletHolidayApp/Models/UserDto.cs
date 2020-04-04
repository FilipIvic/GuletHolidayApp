namespace GuletHolidayApp.Models
{
    public class UserDto
    {
        private int id;
        private string username;
        private string password;
        private int yachtId;
        private string yachtName;
        private string firstName;
        private string lastName;

        public override string ToString()
        {
            return "User: id=" + id
                + ", username=" + username
                + ", password=" + password
                + ", yachtId=" + yachtId
                + ", yachtName=" + yachtName
                + ", firstName=" + firstName
                + ", lastName=" + lastName;
        }

        //prop TAB TAB

        public int GetId() { return id; }
        public void SetId(int value) { id = value; }

        public string GetUsername() { return username; }
        public void SetUsername(string value) { username = value; }

        public string GetPassword() { return password; }
        public void SetPassword(string value) { password = value; }

        public int GetYachtId() { return yachtId; }
        public void SetYachtId(int value) { yachtId = value; }

        public string GetYachtName() { return yachtName; }
        public void SetYachtName(string value) { yachtName = value; }

        public string GetFirstName() { return firstName; }
        public void SetFirstName(string value) { firstName = value; }

        public string GetLastName() { return lastName; }
        public void SetLastName(string value) { lastName = value; }


    }
}

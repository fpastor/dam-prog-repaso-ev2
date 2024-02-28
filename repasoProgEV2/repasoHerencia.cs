
namespace repasoProgEV2
{
    public class User
    {
        public int id;
        public string name = string.Empty;
        public string email = string.Empty;
        public bool superuser;

        public User()
        {
            superuser = false;
        }
    }


    public class Student: User
    {
        public Student() : base()
        {
        }
    }

    public class Teacher : User
    {
        public Teacher() : base()
        {
            superuser = true;
        }
    }



}

namespace TankCleaningProject.Data
{
    public class DataConsts
    {
        public class Company
        {

            public const int CompanyNameMaxLenght = 20;

            public const int CompanyPhoneNumberMaxLenght = 15;

            public const string EmailValidator = @"/^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,20}$/i";

        }

        public class Wash 
        {
            public const int RegistrationPlateMaxLenght = 15;

            public const int DriverPhoneNumberMaxLenght = 15;

            public const int DriverNameMaxLenght = 20;

        }

        public class User
        {            
            public const int FullNameMaxLength = 30;            
            public const int PasswordMaxLength = 50;
        }
    }
}

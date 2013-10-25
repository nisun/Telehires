using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telehire.BusinessLogic.Utility
{
    public class SystemEnums
    {
        public enum Roles
        {
            Administrator = 1,
            Contractor = 2,
            Freelancer = 3
        }

        public class EmailTypes
        {
            public static string NEW_ACCOUNT = "New Account Creation";
            public static string CHANGE_PASSWORD = "Password Changed";
            public static string PASSWORD_RECOVERY = "Password Recovery";
            public static string USER_UPDATED = "User Information Update";

        }

    }
}

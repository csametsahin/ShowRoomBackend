using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR.Core.Utilities.Messages
{
    public static class Messages
    {
        //Create your backend messages here
        //User
        public static string ErrorWhileAddingUserEmailAlreadyExists = "This email already exists please login";
        public static string ErrorWhileAddingUser = "Error while adding user";


        public static string UserRegisteredSuccessfully = "User added successfully";


        //Plan
        public static string ErrorWhileAddingPlan = "Error while adding plan";

        public static string PlanAddedSuccessfully = "Plan added succesfully";
        //Model 
        public static string ModelError = "Model is not correct type";

    }
}

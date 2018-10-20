using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace workFlowApp.Models
{
    public class AuthValidator
    {
        private WorkFlowDBEntities db = new WorkFlowDBEntities();


        /// <summary>
        /// valiadate emmployee login
        /// </summary>
        /// <param name="login"><see cref="Login"/></param>
        /// <returns><see cref="tbl_empoyee"/> The login </returns>
        public tbl_empoyee IsvalidUser(Login login)
        {
            // cheack whether emploayee is availabale 

            tbl_empoyee tbl_Empoyee = db.tbl_empoyee.ToList().Where(
                employee => employee.email.Equals(login.Email, StringComparison.Ordinal) &&
                employee.password.Equals(login.Password, StringComparison.Ordinal)
                ).FirstOrDefault();
            if (tbl_Empoyee != null)
            {
                return tbl_Empoyee;
            }
            else
            {
                InvalidUserException  invalidUserException = new InvalidUserException("User not found in System");
                throw invalidUserException;

            }

        }
    }
}
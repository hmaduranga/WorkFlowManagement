using System;
using System.Linq;
using System.Data.Entity;
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

            tbl_empoyee tbl_Empoyee = db.tbl_empoyee.Include(
                emp => emp.tbl_role).ToList().Where(
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

        public static bool IsAdministrator(string email, string role)
        {
            if (email != null && role == "Administrator")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsMannager(string email, string role)
        {
            if (email != null && role == "Administrator")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
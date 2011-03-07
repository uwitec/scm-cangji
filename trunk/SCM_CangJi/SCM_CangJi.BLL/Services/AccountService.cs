using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using SCM_CangJi.DAL;
namespace SCM_CangJi.BLL.Services
{
    public interface IMembershipService
    {
        int MinPasswordLength { get; }
        bool ValidateUser(string userName, string password);
        MembershipCreateStatus CreateUser(string userName, string password, string email);
        bool ChangePassword(string userName, string oldPassword, string newPassword);
    }
    public class AccountService : BaseService<AccountService>, IMembershipService
    {

        private readonly MembershipProvider _provider;

        public AccountService()
            : this(null)
        {
        }

        public AccountService(MembershipProvider provider)
        {
            _provider = provider ?? Membership.Provider;
        }

        public int MinPasswordLength
        {
            get
            {
                return _provider.MinRequiredPasswordLength;
            }
        }

        public bool ValidateUser(string userName, string password)
        {
            if (String.IsNullOrEmpty(userName)) throw new ArgumentException("Value cannot be null or empty.", "userName");
            if (String.IsNullOrEmpty(password)) throw new ArgumentException("Value cannot be null or empty.", "password");

            if (_provider.ValidateUser(userName, password))
            {
                Security.SecurityContext.Current.CurrentyUser = this._provider.GetUser(userName,true);
                return true;
            }
            else
            {
                return false;
            }
        }

        public MembershipCreateStatus CreateUser(string userName, string password, string email)
        {
            if (String.IsNullOrEmpty(userName)) throw new ArgumentException("Value cannot be null or empty.", "userName");
            if (String.IsNullOrEmpty(password)) throw new ArgumentException("Value cannot be null or empty.", "password");
            //if (String.IsNullOrEmpty(email)) throw new ArgumentException("Value cannot be null or empty.", "email");

            MembershipCreateStatus status;
            _provider.CreateUser(userName, password, "demo@demo.com", null, null, true, null, out status);
            return status;
        }

        public bool ChangePassword(string userName, string oldPassword, string newPassword)
        {
            if (String.IsNullOrEmpty(userName)) throw new ArgumentException("Value cannot be null or empty.", "userName");
            if (String.IsNullOrEmpty(oldPassword)) throw new ArgumentException("Value cannot be null or empty.", "oldPassword");
            if (String.IsNullOrEmpty(newPassword)) throw new ArgumentException("Value cannot be null or empty.", "newPassword");

            // The underlying ChangePassword() will throw an exception rather
            // than return false in certain failure scenarios.
            try
            {
                MembershipUser currentUser = _provider.GetUser(userName, true /* userIsOnline */);
                return currentUser.ChangePassword(oldPassword, newPassword);
            }
            catch (ArgumentException)
            {
                return false;
            }
            catch (MembershipPasswordException)
            {
                return false;
            }
        }
        public object GetUsers()
        {
            object result=null;
            Using<CangJiDataDataContext>(new CangJiDataDataContext(), context =>
            {
                result = (from ur in context.aspnet_UsersInRoles
                          select new
                          {
                              UserId = ur.aspnet_User.UserId,
                              UserName = ur.aspnet_User.UserName,
                              LastActivityDate = ur.aspnet_User.LastActivityDate,
                              RoleName = ur.aspnet_Role.RoleName,
                              RoleId=ur.aspnet_Role.RoleId
                          }).ToList();
            });
            //Using<CangJiDataDataContext>(new CangJiDataDataContext(connectionString), context =>
            //    {
            //        users = context.aspnet_Users.ToList();
            //    });
            //int total=0;
            ////return users;
            //foreach (MembershipUser item in _provider.GetAllUsers(0, 100, out total))
            //{
            //    users.Add(item);
            //}
            //return users;
            return result;
        }

        public string[] GetAllRoles()
        {
           return Roles.GetAllRoles();
        }

        public object GetRoles()
        {
            object result = null;
            Using<CangJiDataDataContext>(new CangJiDataDataContext(), context =>
            {
                result = (from r in context.aspnet_Roles
                          select new
                          {
                              //UserId = ur.aspnet_User.UserId,
                              RoleId = r.RoleId,
                              RoleName = r.RoleName
                          }).ToList();
            });
            return result;
        }

        public bool DeleteRole(string roleName,out string message)
        {
            bool result = true;
            string MessageResult = "删除成功";
            Using<CangJiDataDataContext>(new CangJiDataDataContext(), context =>
            {
                var userRole = context.aspnet_UsersInRoles.Where(o => o.aspnet_Role.RoleName.ToLower() == roleName.ToLower());
                if (userRole.Count() > 0)
                {
                    MessageResult = "角色删除失败,该角色还已经被使用了。请确认没有用户属于该角色后再删除该角色！";
                    result = false;
                }
                else
                {
                    var role = context.aspnet_Roles.SingleOrDefault(o => o.RoleName.ToLower() == roleName.ToLower());
                    context.aspnet_Roles.DeleteOnSubmit(role);
                    context.SubmitChanges();
                }
            });
            message = MessageResult;
            return result;
        }

        public void CreateRole(string roleName)
        {
            Roles.CreateRole(roleName);
        }
    }

    public interface IFormsAuthenticationService
    {
        void SignIn(string userName, bool createPersistentCookie);
        void SignOut();
    }

    public class FormsAuthenticationService : IFormsAuthenticationService
    {
        public void SignIn(string userName, bool createPersistentCookie)
        {
            if (String.IsNullOrEmpty(userName)) throw new ArgumentException("Value cannot be null or empty.", "userName");

            FormsAuthentication.SetAuthCookie(userName, createPersistentCookie);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }

    public static class AccountValidation
    {
        public static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "用户名已经存在，请输入另一个用户名!";

                case MembershipCreateStatus.DuplicateEmail:
                    return "电子邮件已经被使用了!";

                case MembershipCreateStatus.InvalidPassword:
                    return "密码格式不正确，请输入正确格式";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "未知错误，请重试。如果还存在，请联系管理员";
            }
        }
    }
}
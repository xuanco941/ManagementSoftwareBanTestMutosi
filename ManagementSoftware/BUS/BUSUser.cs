using ManagementSoftware.ViewModels;
using ManagementSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagementSoftware.DAL;
using ManagementSoftware.BUS.Validate;
using ManagementSoftware.DAL.DALPagination;

namespace ManagementSoftware.BUS
{
    public class BUSUser
    {
        public static bool AuthLogin(string username, string password)
        {
            try
            {
                User? user = DALUser.AuthLogin(username, password);
                if (user != null)
                {
                    Common.USERSESSION = user;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

        }

        public static PaginationUser GetData(int page)
        {
            PaginationUser paginationUser = new PaginationUser();
            paginationUser.Set(page);
            return paginationUser;
        }


        public static List<UserHasGroupName>? GetAllUsersHasGroupName()
        {

            return DALUser.GetAllUsersHasGroupName();
        }

        public static List<User>? FindUserByFullNameOrUsername(string name)
        {
            return DALUser.FindUserByFullNameOrUsername(name);
        }


        public static User? GetUserFromID(int id)
        {

            return DALUser.GetUserFromID(id);
        }



        public static User? GetUserFromUsername(string username)
        {
            return DALUser.GetUserFromUsername(username);
        }

        public static List<string>? GetListUsername()
        {
            return DALUser.GetListUsername();
        }


        // Them TK
        public static AddUpdateDeleteResponse<User> AddUser(User user)
        {

            //validate data
            user.Username = ValidateUser.FormatUsernamePassword(user.Username);
            user.Password = ValidateUser.FormatUsernamePassword(user.Password);

            //response
            AddUpdateDeleteResponse<User> response = new AddUpdateDeleteResponse<User>();
            try
            {
                // số dòng thay đổi lớn hơn 0 thì thành công
                response.RowsNumberChanged = DALUser.AddUser(user);
                response.Status = response.RowsNumberChanged > 0 ? true : false;
                response.Message = response.Status == true ? $"Thêm thành công tài khoản {user.Username}." : $"Thêm tài khoản {user.Username} thất bại.";
                response.Data = user;
            }
            catch
            {
                response.Status = false;
                response.Message = "Lỗi hệ thống, không thể thêm tài khoản này.";
            }


            return response;
        }

        // Sua TK
        public static AddUpdateDeleteResponse<User> UpdateUser(User user)
        {
            //validate data
            user.Password = ValidateUser.FormatUsernamePassword(user.Password);

            AddUpdateDeleteResponse<User> response = new AddUpdateDeleteResponse<User>();

            //response
            // số dòng thay đổi lớn hơn 0 thì thành công
            try
            {
                response.RowsNumberChanged = DALUser.UpdateUser(user);
                response.Status = response.RowsNumberChanged > 0 ? true : false;
                response.Message = response.Status == true ? $"Cập nhật thành công tài khoản {user.Username}." : $"Cập nhật tài khoản {user.Username} thất bại.";
                response.Data = user;
                //Cập nhật lại tài khoản session
                if (Common.USERSESSION != null && Common.USERSESSION.Username == user.Username)
                {
                    user.UserID = Common.USERSESSION.UserID;
                    Common.USERSESSION = user;
                }
            }
            catch
            {
                response.Status = false;
                response.Message = "Lỗi hệ thống, không thể cập nhật tài khoản này.";
            }

            return response;
        }

        public static AddUpdateDeleteResponse<string> DeleteUser(string username)
        {
            //response
            AddUpdateDeleteResponse<string> response = new AddUpdateDeleteResponse<string>();
            // số dòng thay đổi lớn hơn 0 thì thành công
            try
            {
                //Cập nhật lại tài khoản session
                if (Common.USERSESSION != null && username != Common.USERSESSION.Username && username != Common.UserAdmin.Username)
                {
                    response.RowsNumberChanged = DALUser.DeleteUser(username);
                    response.Status = response.RowsNumberChanged > 0 ? true : false;
                    response.Message = response.Status == true ? $"Xóa tài khoản thành công." : $"Xóa tài khoản thất bại.";
                    response.Data = username;
                }
                else
                {
                    response.Status = false;
                    response.Message = "Tài khoản này đang được bạn sử dụng.";
                }

            }
            catch
            {
                response.Status = false;
                response.Message = "Lỗi hệ thống, không thể xóa tài khoản này.";
            }


            return response;



        }
    }
}

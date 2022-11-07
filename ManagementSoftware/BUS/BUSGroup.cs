using ManagementSoftware.BUS.Validate;
using ManagementSoftware.DAL;
using ManagementSoftware.DAL.DALPagination;
using ManagementSoftware.Models;
using ManagementSoftware.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.BUS
{
    public class BUSGroup
    {
        public static PaginationGroup GetData(int page)
        {
            PaginationGroup paginationGroup = new PaginationGroup();
            paginationGroup.Set(page);
            return paginationGroup;
        }




        public static Group? GetGroupFromID(int id)
        {
            return DALGroup.GetGroupFromID(id);
        }
        //Tìm kiếm group bằng tên
        public static List<Group> FindGroupByGroupName(string groupName)
        {
            return DALGroup.FindGroupByGroupName(groupName);
        }

        public static Group? GetGroupFromGroupName(string groupName)
        {
            return DALGroup.GetGroupFromGroupName(groupName);
        }

        public static List<string>? GetListGroupName()
        {
            return DALGroup.GetListGroupName();
        }
        public static Group? GetGroupFromUserID(int? UserID)
        {
            return GetGroupFromUserID(UserID);
        }









        // Them nhóm quyền
        public static AddUpdateDeleteResponse<Group> AddGroup(Group group)
        {
            //response
            AddUpdateDeleteResponse<Group> response = new AddUpdateDeleteResponse<Group>();
            try
            {
                // số dòng thay đổi lớn hơn 0 thì thành công
                response.RowsNumberChanged = DALGroup.AddGroup(group);
                response.Status = response.RowsNumberChanged > 0 ? true : false;
                response.Message = response.Status == true ? $"Thêm thành công nhóm quyền {group.GroupName}." : $"Thêm nhóm quyền {group.GroupName} thất bại.";
                response.Data = group;
            }
            catch
            {
                response.Status = false;
                response.Message = "Lỗi hệ thống, không thể thêm nhóm quyền này.";
            }


            return response;
        }

        // Sua group
        public static AddUpdateDeleteResponse<Group> UpdateGroup(Group group)
        {
            //response
            AddUpdateDeleteResponse<Group> response = new AddUpdateDeleteResponse<Group>();
            try
            {
                // số dòng thay đổi lớn hơn 0 thì thành công
                response.RowsNumberChanged = DALGroup.UpdateGroup(group);
                response.Status = response.RowsNumberChanged > 0 ? true : false;
                response.Message = response.Status == true ? $"Cập nhật thành công." : $"Cập nhật thất bại.";
                response.Data = group;
            }
            catch
            {
                response.Status = false;
                response.Message = "Lỗi hệ thống, không thể cập nhật nhóm quyền này.";
            }


            return response;
        }

        public static AddUpdateDeleteResponse<string> DeleteGroup(string grName)
        {
            //response
            AddUpdateDeleteResponse<string> response = new AddUpdateDeleteResponse<string>();
            try
            {
                // số dòng thay đổi lớn hơn 0 thì thành công
                response.RowsNumberChanged = DALGroup.DeleteGroup(grName);
                response.Status = response.RowsNumberChanged > 0 ? true : false;
                response.Message = response.Status == true ? $"Xóa thành công." : $"Xóa thất bại.";
                response.Data = grName;
            }
            catch
            {
                response.Status = false;
                response.Message = "Lỗi hệ thống, không thể xóa nhóm quyền này.";
            }


            return response;
        }
    }
}

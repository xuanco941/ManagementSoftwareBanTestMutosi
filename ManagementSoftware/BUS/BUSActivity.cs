using ManagementSoftware.DAL;
using ManagementSoftware.DAL.DALPagination;
using ManagementSoftware.ViewModels;
using ManagementSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.BUS
{
    internal class BUSActivity
    {
        public static PaginationActivity GetData(int page, DateTime? start, DateTime? end)
        {
            PaginationActivity paginationActivity = new PaginationActivity();
            paginationActivity.Set(page, start, end);
            return paginationActivity;
        }

        public static PaginationActivityAUser GetDataAUser(int page, DateTime? start, DateTime? end, string username)
        {
            PaginationActivityAUser paginationActivity = new PaginationActivityAUser();
            paginationActivity.Set(page, start, end, username);
            return paginationActivity;
        }

        public static List<string>? GetListActivityHasDistinctUsername()
        {
            return DALActivity.GetListActivityHasDistinctUsername();
        }

        public static AddUpdateDeleteResponse<List<Activity>> DeleteActivities(List<int> activityIDs)
        {
            //response
            AddUpdateDeleteResponse<List<Activity>> response = new AddUpdateDeleteResponse<List<Activity>>();
            try
            {
                //lay danh sach activity can xoa tu id
                List<Activity> listActivities = new List<Activity>();
                activityIDs.ForEach(a =>
                {
                    Activity? activity = DALActivity.GetActivityFromID(a);
                    if (activity != null)
                    {
                        listActivities.Add(activity);
                    }
                });

                // số dòng thay đổi lớn hơn 0 thì thành công
                response.RowsNumberChanged = DALActivity.DeleteActivities(listActivities);
                response.Status = response.RowsNumberChanged > 0 ? true : false;
                response.Message = response.Status == true ? $"Xóa thành công." : $"Xóa thất bại.";
            }
            catch
            {
                response.Status = false;
                response.Message = "Lỗi hệ thống, không thể xóa lịch sử hoạt động.";
            }


            return response;
        }

    }
}

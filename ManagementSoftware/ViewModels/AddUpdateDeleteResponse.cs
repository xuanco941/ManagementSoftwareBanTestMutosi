
namespace ManagementSoftware.ViewModels
{
    //mặc định chung các hành động thêm sửa xóa từ GUI sẽ nhận về response này từ BUS
    public class AddUpdateDeleteResponse<T>
    {
        public bool Status { get; set; } = false;
        public string? Message { get; set; } = "";
        public int? RowsNumberChanged { get; set; } = 0;
        public T? Data { get; set; }
    }
}

using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.ManageHistoryData
{
    public class SaveToFIleExcel
    {
        string nameDisk = "D";
        public void SaveLoiLoc(string nameBanTest, Models.LoiLocModel.LoiLoc loiLoc)
        {
            DateTime date = DateTime.Now;
            var folderPath = Path.Combine($"{nameDisk}:", "ExcelFiles", nameBanTest, date.Year.ToString(), date.Month.ToString("00"), date.Day.ToString("00"));
            Directory.CreateDirectory(folderPath);


            var fileName = $"{date:HH}.xlsx";

            // Tìm kiếm file Excel trong thư mục với tên tương ứng với giờ trong ngày
            var excelFile = Directory.GetFiles(folderPath, fileName).FirstOrDefault();


            if (excelFile != null)
            {
                // Nếu tìm thấy file Excel, thêm giá trị vào dòng tiếp theo trong file này
                try
                {
                    // Mở file Excel dùng làm bản mẫu
                    using (var templateWorkbook = new XLWorkbook(excelFile))
                    {
                        // Lấy worksheet đầu tiên trong file Excel
                        var ws = templateWorkbook.Worksheet(1);

                        // Tìm dòng cuối cùng đã sử dụng trong file Excel
                        var lastUsedRow = ws.LastRowUsed().RowNumber();

                        // Thêm giá trị vào ô tiếp theo trong dòng cuối cùng
                        ws.Cell(lastUsedRow, 1).Value = date.ToString($"HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);
                        ws.Cell(lastUsedRow, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        ws.Cell(lastUsedRow, 2).Value = loiLoc.LoiLocName;
                        ws.Cell(lastUsedRow, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        ws.Cell(lastUsedRow, 3).Value = loiLoc.SoLanTest;
                        ws.Cell(lastUsedRow, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        ws.Cell(lastUsedRow, 4).Value = loiLoc.ApSuatTest;
                        ws.Cell(lastUsedRow, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        ws.Cell(lastUsedRow, 5).Value = loiLoc.ThoiGianNen;
                        ws.Cell(lastUsedRow, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        ws.Cell(lastUsedRow, 6).Value = loiLoc.ThoiGianGiu;
                        ws.Cell(lastUsedRow, 6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        ws.Cell(lastUsedRow, 7).Value = loiLoc.ThoiGianXa;
                        ws.Cell(lastUsedRow, 7).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        ws.Cell(lastUsedRow, 8).Value = loiLoc.Error;
                        ws.Cell(lastUsedRow, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        // Lưu lại file Excel
                        templateWorkbook.SaveAs(excelFile);
                    }
                }
                catch (Exception ex)
                {

                }

            }
            else
            {
                // Nếu không tìm thấy file Excel, tạo file mới và thêm giá trị vào dòng đầu tiên

                try
                {
                    using (var workBook = new XLWorkbook())
                    {


                        var ws = workBook.Worksheets.Add("Lịch sử test");

                        ws.Range(ws.Cell("A1"), ws.Cell("B1")).Merge();
                        ws.Range(ws.Cell("A1"), ws.Cell("B1")).Value = nameBanTest;
                        ws.Range(ws.Cell("A1"), ws.Cell("B1")).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Range(ws.Cell("A1"), ws.Cell("B1")).Style.Font.Bold = true;
                        ws.Range(ws.Cell("A1"), ws.Cell("B1")).Style.Font.FontSize = 14;



                        ws.Cell(2, 1).Value = "ID-Date";
                        ws.Cell(2, 2).Value = "Lõi lọc";
                        ws.Cell(2, 3).Value = "Lần test thứ";
                        ws.Cell(2, 4).Value = "Áp suất test (bar)";
                        ws.Cell(2, 5).Value = "Thời gian cấp (giây)";
                        ws.Cell(2, 6).Value = "Thời gian giữ (giây)";
                        ws.Cell(2, 7).Value = "Thời gian xả (giây)";
                        ws.Cell(2, 8).Value = "Lỗi";





                        ws.Cell(3, 1).Value = date.ToString($"HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);
                        ws.Cell(3, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        ws.Cell(3, 2).Value = loiLoc.LoiLocName;
                        ws.Cell(3, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        ws.Cell(3, 3).Value = loiLoc.SoLanTest;
                        ws.Cell(3, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        ws.Cell(3, 4).Value = loiLoc.ApSuatTest;
                        ws.Cell(3, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        ws.Cell(3, 5).Value = loiLoc.ThoiGianNen;
                        ws.Cell(3, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        ws.Cell(3, 6).Value = loiLoc.ThoiGianGiu;
                        ws.Cell(3, 6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        ws.Cell(3, 7).Value = loiLoc.ThoiGianXa;
                        ws.Cell(3, 7).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        ws.Cell(3, 8).Value = loiLoc.Error;
                        ws.Cell(3, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;


                        workBook.SaveAs(excelFile);
                    }
                }
                catch
                {

                }
            }
        }














        public void SaveBepTu(string nameBanTest, List<Models.BepTuModel.BepTu> list)
        {
            DateTime date = DateTime.Now;
            var folderPath = Path.Combine($"{nameDisk}:", "ExcelFiles", nameBanTest, date.Year.ToString(), date.Month.ToString("00"), date.Day.ToString("00"));
            Directory.CreateDirectory(folderPath);


            var fileName = $"{date:HH}.xlsx";

            // Tìm kiếm file Excel trong thư mục với tên tương ứng với giờ trong ngày
            var excelFile = Directory.GetFiles(folderPath, fileName).FirstOrDefault();


            if (excelFile != null)
            {
                // Nếu tìm thấy file Excel, thêm giá trị vào dòng tiếp theo trong file này
                try
                {
                    // Mở file Excel dùng làm bản mẫu
                    using (var templateWorkbook = new XLWorkbook(excelFile))
                    {
                        // Lấy worksheet đầu tiên trong file Excel
                        var ws = templateWorkbook.Worksheet(1);

                        // Tìm dòng cuối cùng đã sử dụng trong file Excel
                        var lastUsedRow = ws.LastRowUsed().RowNumber();

                        // Thêm giá trị vào ô tiếp theo trong dòng cuối cùng
                        foreach (var item in list)
                        {
                            ws.Cell(lastUsedRow, 1).Value = date.ToString($"HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);
                            ws.Cell(lastUsedRow, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow, 2).Value = item.BepTuName;
                            ws.Cell(lastUsedRow, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow, 3).Value = item.LanTestThu;
                            ws.Cell(lastUsedRow, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow, 4).Value = item.NhietDo;
                            ws.Cell(lastUsedRow, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow, 5).Value = item.DienAp;
                            ws.Cell(lastUsedRow, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow, 6).Value = item.DongDien;
                            ws.Cell(lastUsedRow, 6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow, 7).Value = item.CongSuat;
                            ws.Cell(lastUsedRow, 7).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow, 8).Value = item.CongSuatTieuThu;
                            ws.Cell(lastUsedRow, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow, 9).Value = item.TrangThai == true ? "ON" : "OFF";
                            ws.Cell(lastUsedRow, 9).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow, 10).Value = item.Error;
                            ws.Cell(lastUsedRow, 10).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        }
                        // Lưu lại file Excel
                        templateWorkbook.SaveAs(excelFile);
                    }
                }
                catch (Exception ex)
                {

                }

            }
            else
            {
                // Nếu không tìm thấy file Excel, tạo file mới và thêm giá trị vào dòng đầu tiên

                try
                {
                    using (var workBook = new XLWorkbook())
                    {


                        var ws = workBook.Worksheets.Add("Lịch sử test");

                        ws.Range(ws.Cell("A1"), ws.Cell("B1")).Merge();
                        ws.Range(ws.Cell("A1"), ws.Cell("B1")).Value = nameBanTest;
                        ws.Range(ws.Cell("A1"), ws.Cell("B1")).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Range(ws.Cell("A1"), ws.Cell("B1")).Style.Font.Bold = true;
                        ws.Range(ws.Cell("A1"), ws.Cell("B1")).Style.Font.FontSize = 14;



                        ws.Cell(2, 1).Value = "ID-Date";
                        ws.Cell(2, 2).Value = "Bếp từ";
                        ws.Cell(2, 3).Value = "Lần test thứ";
                        ws.Cell(2, 4).Value = "Nhiệt độ (°C)";
                        ws.Cell(2, 5).Value = "Điện áp (V)";
                        ws.Cell(2, 6).Value = "Dòng điện (A)";
                        ws.Cell(2, 7).Value = "Công suất (Kw)";
                        ws.Cell(2, 8).Value = "Công suất tiêu thụ(Kwh)";
                        ws.Cell(2, 9).Value = "Trạng thái";
                        ws.Cell(2, 10).Value = "Lỗi";



                        foreach (var item in list)
                        {
                            ws.Cell(3, 1).Value = date.ToString($"HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);
                            ws.Cell(3, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3, 2).Value = item.BepTuName;
                            ws.Cell(3, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3, 3).Value = item.LanTestThu;
                            ws.Cell(3, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3, 4).Value = item.NhietDo;
                            ws.Cell(3, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3, 5).Value = item.DienAp;
                            ws.Cell(3, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3, 6).Value = item.DongDien;
                            ws.Cell(3, 6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3, 7).Value = item.CongSuat;
                            ws.Cell(3, 7).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3, 8).Value = item.CongSuatTieuThu;
                            ws.Cell(3, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3, 9).Value = item.TrangThai == true ? "ON" : "OFF";
                            ws.Cell(3, 9).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3, 10).Value = item.Error;
                            ws.Cell(3, 10).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        }




                        workBook.SaveAs(excelFile);
                    }
                }
                catch
                {

                }
            }
        }















        public void SaveNguon(string nameBanTest, List<Models.NguonModel.Nguon> list)
        {
            DateTime date = DateTime.Now;
            var folderPath = Path.Combine($"{nameDisk}:", "ExcelFiles", nameBanTest, date.Year.ToString(), date.Month.ToString("00"), date.Day.ToString("00"));
            Directory.CreateDirectory(folderPath);


            var fileName = $"{date:HH}.xlsx";

            // Tìm kiếm file Excel trong thư mục với tên tương ứng với giờ trong ngày
            var excelFile = Directory.GetFiles(folderPath, fileName).FirstOrDefault();


            if (excelFile != null)
            {
                // Nếu tìm thấy file Excel, thêm giá trị vào dòng tiếp theo trong file này
                try
                {
                    // Mở file Excel dùng làm bản mẫu
                    using (var templateWorkbook = new XLWorkbook(excelFile))
                    {
                        // Lấy worksheet đầu tiên trong file Excel
                        var ws = templateWorkbook.Worksheet(1);

                        // Tìm dòng cuối cùng đã sử dụng trong file Excel
                        var lastUsedRow = ws.LastRowUsed().RowNumber();

                        // Thêm giá trị vào ô tiếp theo trong dòng cuối cùng
                        foreach (var item in list)
                        {
                            ws.Cell(lastUsedRow, 1).Value = date.ToString($"HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);
                            ws.Cell(lastUsedRow, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow, 2).Value = item.NguonName;
                            ws.Cell(lastUsedRow, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow, 3).Value = item.LanTestThu;
                            ws.Cell(lastUsedRow, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow, 4).Value = item.DienApDC;
                            ws.Cell(lastUsedRow, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow, 5).Value = item.DongDC;
                            ws.Cell(lastUsedRow, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow, 6).Value = item.CongSuat;
                            ws.Cell(lastUsedRow, 6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow, 7).Value = item.ThoiGianTest;
                            ws.Cell(lastUsedRow, 7).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;


                            ws.Cell(lastUsedRow, 8).Value = item.Error;
                            ws.Cell(lastUsedRow, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        }
                        // Lưu lại file Excel
                        templateWorkbook.SaveAs(excelFile);
                    }
                }
                catch (Exception ex)
                {

                }

            }
            else
            {
                // Nếu không tìm thấy file Excel, tạo file mới và thêm giá trị vào dòng đầu tiên

                try
                {
                    using (var workBook = new XLWorkbook())
                    {


                        var ws = workBook.Worksheets.Add("Lịch sử test");

                        ws.Range(ws.Cell("A1"), ws.Cell("B1")).Merge();
                        ws.Range(ws.Cell("A1"), ws.Cell("B1")).Value = nameBanTest;
                        ws.Range(ws.Cell("A1"), ws.Cell("B1")).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Range(ws.Cell("A1"), ws.Cell("B1")).Style.Font.Bold = true;
                        ws.Range(ws.Cell("A1"), ws.Cell("B1")).Style.Font.FontSize = 14;



                        ws.Cell(2, 1).Value = "ID-Date";
                        ws.Cell(2, 2).Value = "Nguồn";
                        ws.Cell(2, 3).Value = "Lần test thứ";
                        ws.Cell(2, 4).Value = "Điện áp DC (V)";
                        ws.Cell(2, 5).Value = "Dòng DC (A)";
                        ws.Cell(2, 6).Value = "Công suất (W)";
                        ws.Cell(2, 7).Value = "Thời gian (giây)";
                        ws.Cell(2, 8).Value = "Lỗi";



                        foreach (var item in list)
                        {
                            ws.Cell(3, 1).Value = date.ToString($"HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);
                            ws.Cell(3, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3, 2).Value = item.NguonName;
                            ws.Cell(3, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3, 3).Value = item.LanTestThu;
                            ws.Cell(3, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3, 4).Value = item.DienApDC;
                            ws.Cell(3, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3, 5).Value = item.DongDC;
                            ws.Cell(3, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3, 6).Value = item.CongSuat;
                            ws.Cell(3, 6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3, 7).Value = item.ThoiGianTest;
                            ws.Cell(3, 7).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;


                            ws.Cell(3, 8).Value = item.Error;
                            ws.Cell(3, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        }




                        workBook.SaveAs(excelFile);
                    }
                }
                catch
                {

                }
            }
        }








        public void SaveLed(string nameBanTest, List<Models.LedModel.Led> list)
        {
            DateTime date = DateTime.Now;
            var folderPath = Path.Combine($"{nameDisk}:", "ExcelFiles", nameBanTest, date.Year.ToString(), date.Month.ToString("00"), date.Day.ToString("00"));
            Directory.CreateDirectory(folderPath);


            var fileName = $"{date:HH}.xlsx";

            // Tìm kiếm file Excel trong thư mục với tên tương ứng với giờ trong ngày
            var excelFile = Directory.GetFiles(folderPath, fileName).FirstOrDefault();


            if (excelFile != null)
            {
                // Nếu tìm thấy file Excel, thêm giá trị vào dòng tiếp theo trong file này
                try
                {
                    // Mở file Excel dùng làm bản mẫu
                    using (var templateWorkbook = new XLWorkbook(excelFile))
                    {
                        // Lấy worksheet đầu tiên trong file Excel
                        var ws = templateWorkbook.Worksheet(1);

                        // Tìm dòng cuối cùng đã sử dụng trong file Excel
                        var lastUsedRow = ws.LastRowUsed().RowNumber();

                        // Thêm giá trị vào ô tiếp theo trong dòng cuối cùng
                        foreach (var item in list)
                        {
                            ws.Cell(lastUsedRow, 1).Value = date.ToString($"HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);
                            ws.Cell(lastUsedRow, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow, 2).Value = item.LedName;
                            ws.Cell(lastUsedRow, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow, 3).Value = item.LanTestThu;
                            ws.Cell(lastUsedRow, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow, 4).Value = item.ThoiGianTest;
                            ws.Cell(lastUsedRow, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow, 5).Value = item.Error;
                            ws.Cell(lastUsedRow, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        }
                        // Lưu lại file Excel
                        templateWorkbook.SaveAs(excelFile);
                    }
                }
                catch (Exception ex)
                {

                }

            }
            else
            {
                // Nếu không tìm thấy file Excel, tạo file mới và thêm giá trị vào dòng đầu tiên

                try
                {
                    using (var workBook = new XLWorkbook())
                    {


                        var ws = workBook.Worksheets.Add("Lịch sử test");

                        ws.Range(ws.Cell("A1"), ws.Cell("B1")).Merge();
                        ws.Range(ws.Cell("A1"), ws.Cell("B1")).Value = nameBanTest;
                        ws.Range(ws.Cell("A1"), ws.Cell("B1")).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Range(ws.Cell("A1"), ws.Cell("B1")).Style.Font.Bold = true;
                        ws.Range(ws.Cell("A1"), ws.Cell("B1")).Style.Font.FontSize = 14;



                        ws.Cell(2, 1).Value = "ID-Date";
                        ws.Cell(2, 2).Value = "LED";
                        ws.Cell(2, 3).Value = "Lần test thứ";
                        ws.Cell(2, 4).Value = "Thời gian (giây)";
                        ws.Cell(2, 5).Value = "Lỗi";



                        foreach (var item in list)
                        {
                            ws.Cell(3, 1).Value = date.ToString($"HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);
                            ws.Cell(3, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3, 2).Value = item.LedName;
                            ws.Cell(3, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3, 3).Value = item.LanTestThu;
                            ws.Cell(3, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3, 4).Value = item.ThoiGianTest;
                            ws.Cell(3, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;


                            ws.Cell(3, 5).Value = item.Error;
                            ws.Cell(3, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        }




                        workBook.SaveAs(excelFile);
                    }
                }
                catch
                {

                }
            }
        }














        public void SaveJigMachNguon(string nameBanTest, List<Models.JigMachModel.JigMachNguon> list)
        {
            DateTime date = DateTime.Now;
            var folderPath = Path.Combine($"{nameDisk}:", "ExcelFiles", nameBanTest, date.Year.ToString(), date.Month.ToString("00"), date.Day.ToString("00"));
            Directory.CreateDirectory(folderPath);


            var fileName = $"{date:HH}.xlsx";

            // Tìm kiếm file Excel trong thư mục với tên tương ứng với giờ trong ngày
            var excelFile = Directory.GetFiles(folderPath, fileName).FirstOrDefault();


            if (excelFile != null)
            {
                // Nếu tìm thấy file Excel, thêm giá trị vào dòng tiếp theo trong file này
                try
                {
                    // Mở file Excel dùng làm bản mẫu
                    using (var templateWorkbook = new XLWorkbook(excelFile))
                    {
                        // Lấy worksheet đầu tiên trong file Excel
                        var ws = templateWorkbook.Worksheet(1);

                        // Tìm dòng cuối cùng đã sử dụng trong file Excel
                        var lastUsedRow = ws.LastRowUsed().RowNumber();

                        // Thêm giá trị vào ô tiếp theo trong dòng cuối cùng
                        foreach (var item in list)
                        {
                            ws.Cell(lastUsedRow, 1).Value = date.ToString($"HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);
                            ws.Cell(lastUsedRow, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow, 2).Value = item.JigMachNguonName;
                            ws.Cell(lastUsedRow, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow, 3).Value = item.LanTestThu;
                            ws.Cell(lastUsedRow, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow, 4).Value = item.DienApDC;
                            ws.Cell(lastUsedRow, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow, 5).Value = item.DongDienDC;
                            ws.Cell(lastUsedRow, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow, 6).Value = item.CongSuat;
                            ws.Cell(lastUsedRow, 6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow, 7).Value = item.ThoiGian;
                            ws.Cell(lastUsedRow, 7).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow, 8).Value = item.Error;
                            ws.Cell(lastUsedRow, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        }
                        // Lưu lại file Excel
                        templateWorkbook.SaveAs(excelFile);
                    }
                }
                catch (Exception ex)
                {

                }

            }
            else
            {
                // Nếu không tìm thấy file Excel, tạo file mới và thêm giá trị vào dòng đầu tiên

                try
                {
                    using (var workBook = new XLWorkbook())
                    {


                        var ws = workBook.Worksheets.Add("Lịch sử test");

                        ws.Range(ws.Cell("A1"), ws.Cell("B1")).Merge();
                        ws.Range(ws.Cell("A1"), ws.Cell("B1")).Value = nameBanTest;
                        ws.Range(ws.Cell("A1"), ws.Cell("B1")).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Range(ws.Cell("A1"), ws.Cell("B1")).Style.Font.Bold = true;
                        ws.Range(ws.Cell("A1"), ws.Cell("B1")).Style.Font.FontSize = 14;



                        ws.Cell(2, 1).Value = "ID-Date";
                        ws.Cell(2, 2).Value = "Jig";
                        ws.Cell(2, 3).Value = "Lần test thứ";
                        ws.Cell(2, 4).Value = "Dòng áp DC (V)";
                        ws.Cell(2, 5).Value = "Dòng điện DC (A)";
                        ws.Cell(2, 6).Value = "Công suất (W)";
                        ws.Cell(2, 7).Value = "Thời gian (giây)";
                        ws.Cell(2, 8).Value = "Lỗi";



                        foreach (var item in list)
                        {
                            ws.Cell(3, 1).Value = date.ToString($"HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);
                            ws.Cell(3, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3, 2).Value = item.JigMachNguonName;
                            ws.Cell(3, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3, 3).Value = item.LanTestThu;
                            ws.Cell(3, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3, 4).Value = item.DienApDC;
                            ws.Cell(3, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3, 5).Value = item.DongDienDC;
                            ws.Cell(3, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3, 6).Value = item.CongSuat;
                            ws.Cell(3, 6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3, 7).Value = item.ThoiGian;
                            ws.Cell(3, 7).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3, 8).Value = item.Error;
                            ws.Cell(3, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        }




                        workBook.SaveAs(excelFile);
                    }
                }
                catch
                {

                }
            }
        }



















        public void SaveJigMachTDS(string nameBanTest, List<Models.JigMachModel.JigMachTDS> list)
        {
            DateTime date = DateTime.Now;
            var folderPath = Path.Combine($"{nameDisk}:", "ExcelFiles", nameBanTest, date.Year.ToString(), date.Month.ToString("00"), date.Day.ToString("00"));
            Directory.CreateDirectory(folderPath);


            var fileName = $"{date:HH}.xlsx";

            // Tìm kiếm file Excel trong thư mục với tên tương ứng với giờ trong ngày
            var excelFile = Directory.GetFiles(folderPath, fileName).FirstOrDefault();


            if (excelFile != null)
            {
                // Nếu tìm thấy file Excel, thêm giá trị vào dòng tiếp theo trong file này
                try
                {
                    // Mở file Excel dùng làm bản mẫu
                    using (var templateWorkbook = new XLWorkbook(excelFile))
                    {
                        // Lấy worksheet đầu tiên trong file Excel
                        var ws = templateWorkbook.Worksheet(1);

                        // Tìm dòng cuối cùng đã sử dụng trong file Excel
                        var lastUsedRow = ws.LastRowUsed().RowNumber();

                        // Thêm giá trị vào ô tiếp theo trong dòng cuối cùng
                        foreach (var item in list)
                        {
                            ws.Cell(lastUsedRow, 1).Value = date.ToString($"HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);
                            ws.Cell(lastUsedRow, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow, 2).Value = item.JigMachTDSName;
                            ws.Cell(lastUsedRow, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow, 3).Value = item.LanTestThu;
                            ws.Cell(lastUsedRow, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow, 4).Value = item.VanDienTu == true ? "ON" : "OFF";
                            ws.Cell(lastUsedRow, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow, 5).Value = item.VanApCao == true ? "ON" : "OFF";
                            ws.Cell(lastUsedRow, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow, 6).Value = item.ThoiGian;
                            ws.Cell(lastUsedRow, 6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow, 7).Value = item.Error;
                            ws.Cell(lastUsedRow, 7).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        }
                        // Lưu lại file Excel
                        templateWorkbook.SaveAs(excelFile);
                    }
                }
                catch (Exception ex)
                {

                }

            }
            else
            {
                // Nếu không tìm thấy file Excel, tạo file mới và thêm giá trị vào dòng đầu tiên

                try
                {
                    using (var workBook = new XLWorkbook())
                    {


                        var ws = workBook.Worksheets.Add("Lịch sử test");

                        ws.Range(ws.Cell("A1"), ws.Cell("B1")).Merge();
                        ws.Range(ws.Cell("A1"), ws.Cell("B1")).Value = nameBanTest;
                        ws.Range(ws.Cell("A1"), ws.Cell("B1")).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Range(ws.Cell("A1"), ws.Cell("B1")).Style.Font.Bold = true;
                        ws.Range(ws.Cell("A1"), ws.Cell("B1")).Style.Font.FontSize = 14;



                        ws.Cell(2, 1).Value = "ID-Date";
                        ws.Cell(2, 2).Value = "Jig";
                        ws.Cell(2, 3).Value = "Lần test thứ";
                        ws.Cell(2, 4).Value = "Van điện từ";
                        ws.Cell(2, 5).Value = "Van áp cao";
                        ws.Cell(2, 6).Value = "Thời gian (giây)";
                        ws.Cell(2, 7).Value = "Lỗi";



                        foreach (var item in list)
                        {
                            ws.Cell(3, 1).Value = date.ToString($"HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);
                            ws.Cell(3, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3, 2).Value = item.JigMachTDSName;
                            ws.Cell(3, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3, 3).Value = item.LanTestThu;
                            ws.Cell(3, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3, 4).Value = item.VanDienTu == true ? "ON" : "OFF";
                            ws.Cell(3, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3, 5).Value = item.VanApCao == true ? "ON" : "OFF";
                            ws.Cell(3, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3, 6).Value = item.ThoiGian;
                            ws.Cell(3, 6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3, 7).Value = item.Error;
                            ws.Cell(3, 7).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        }




                        workBook.SaveAs(excelFile);
                    }
                }
                catch
                {

                }
            }
        }










        public void SaveCongTac(string nameBanTest, List<Models.CongTacModel.CongTac> list)
        {
            DateTime date = DateTime.Now;
            var folderPath = Path.Combine($"{nameDisk}:", "ExcelFiles", nameBanTest, date.Year.ToString(), date.Month.ToString("00"), date.Day.ToString("00"));
            Directory.CreateDirectory(folderPath);


            var fileName = $"{date:HH}.xlsx";

            // Tìm kiếm file Excel trong thư mục với tên tương ứng với giờ trong ngày
            var excelFile = Directory.GetFiles(folderPath, fileName).FirstOrDefault();


            if (excelFile != null)
            {
                // Nếu tìm thấy file Excel, thêm giá trị vào dòng tiếp theo trong file này
                try
                {
                    // Mở file Excel dùng làm bản mẫu
                    using (var templateWorkbook = new XLWorkbook(excelFile))
                    {
                        // Lấy worksheet đầu tiên trong file Excel
                        var ws = templateWorkbook.Worksheet(1);

                        // Tìm dòng cuối cùng đã sử dụng trong file Excel
                        var lastUsedRow = ws.LastRowUsed().RowNumber();

                        // Thêm giá trị vào ô tiếp theo trong dòng cuối cùng
                        foreach (var item in list)
                        {
                            ws.Cell(lastUsedRow, 1).Value = date.ToString($"HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);
                            ws.Cell(lastUsedRow, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow, 2).Value = item.CongTacName;
                            ws.Cell(lastUsedRow, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow, 3).Value = item.TrangThai == true ? "ON" : "OFF";
                            ws.Cell(lastUsedRow, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow, 4).Value = item.LanTestThu;
                            ws.Cell(lastUsedRow, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow, 5).Value = item.Error;
                            ws.Cell(lastUsedRow, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        }
                        // Lưu lại file Excel
                        templateWorkbook.SaveAs(excelFile);
                    }
                }
                catch (Exception ex)
                {

                }

            }
            else
            {
                // Nếu không tìm thấy file Excel, tạo file mới và thêm giá trị vào dòng đầu tiên

                try
                {
                    using (var workBook = new XLWorkbook())
                    {


                        var ws = workBook.Worksheets.Add("Lịch sử test");

                        ws.Range(ws.Cell("A1"), ws.Cell("B1")).Merge();
                        ws.Range(ws.Cell("A1"), ws.Cell("B1")).Value = nameBanTest;
                        ws.Range(ws.Cell("A1"), ws.Cell("B1")).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Range(ws.Cell("A1"), ws.Cell("B1")).Style.Font.Bold = true;
                        ws.Range(ws.Cell("A1"), ws.Cell("B1")).Style.Font.FontSize = 14;



                        ws.Cell(2, 1).Value = "ID-Date";
                        ws.Cell(2, 2).Value = "Công tắc";
                        ws.Cell(2, 3).Value = "Trạng thái";
                        ws.Cell(2, 4).Value = "Lần test thứ";
                        ws.Cell(2, 5).Value = "Lỗi";



                        foreach (var item in list)
                        {
                            ws.Cell(3, 1).Value = date.ToString($"HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);
                            ws.Cell(3, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3, 2).Value = item.CongTacName;
                            ws.Cell(3, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3, 3).Value = item.TrangThai == true ? "ON" : "OFF";
                            ws.Cell(3, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3, 4).Value = item.LanTestThu;
                            ws.Cell(3, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3, 5).Value = item.Error;
                            ws.Cell(3, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        }




                        workBook.SaveAs(excelFile);
                    }
                }
                catch
                {

                }
            }
        }











        public void SaveBauNong(string nameBanTest, List<Models.BauNongModel.BauNong> list)
        {
            DateTime date = DateTime.Now;
            var folderPath = Path.Combine($"{nameDisk}:", "ExcelFiles", nameBanTest, date.Year.ToString(), date.Month.ToString("00"), date.Day.ToString("00"));
            Directory.CreateDirectory(folderPath);


            var fileName = $"{date:HH}.xlsx";

            // Tìm kiếm file Excel trong thư mục với tên tương ứng với giờ trong ngày
            var excelFile = Directory.GetFiles(folderPath, fileName).FirstOrDefault();


            if (excelFile != null)
            {
                // Nếu tìm thấy file Excel, thêm giá trị vào dòng tiếp theo trong file này
                try
                {
                    // Mở file Excel dùng làm bản mẫu
                    using (var templateWorkbook = new XLWorkbook(excelFile))
                    {
                        // Lấy worksheet đầu tiên trong file Excel
                        var ws = templateWorkbook.Worksheet(1);

                        // Tìm dòng cuối cùng đã sử dụng trong file Excel
                        var lastUsedRow = ws.LastRowUsed().RowNumber();

                        // Thêm giá trị vào ô tiếp theo trong dòng cuối cùng
                        foreach (var item in list)
                        {
                            ws.Cell(lastUsedRow, 1).Value = date.ToString($"HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);
                            ws.Cell(lastUsedRow, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow, 2).Value = item.BauNongName;
                            ws.Cell(lastUsedRow, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow, 3).Value = item.LanTestThu;
                            ws.Cell(lastUsedRow, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow, 4).Value = item.DongDien;
                            ws.Cell(lastUsedRow, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow, 5).Value = item.NhietDo;
                            ws.Cell(lastUsedRow, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow, 6).Value = item.NhietDoNgatCBNhiet;
                            ws.Cell(lastUsedRow, 6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow, 7).Value = item.TrangThaiCBNhiet == true ? "ON" : "OFF";
                            ws.Cell(lastUsedRow, 7).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow, 8).Value = item.Error;
                            ws.Cell(lastUsedRow, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        }
                        // Lưu lại file Excel
                        templateWorkbook.SaveAs(excelFile);
                    }
                }
                catch (Exception ex)
                {

                }

            }
            else
            {
                // Nếu không tìm thấy file Excel, tạo file mới và thêm giá trị vào dòng đầu tiên

                try
                {
                    using (var workBook = new XLWorkbook())
                    {


                        var ws = workBook.Worksheets.Add("Lịch sử test");

                        ws.Range(ws.Cell("A1"), ws.Cell("B1")).Merge();
                        ws.Range(ws.Cell("A1"), ws.Cell("B1")).Value = nameBanTest;
                        ws.Range(ws.Cell("A1"), ws.Cell("B1")).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Range(ws.Cell("A1"), ws.Cell("B1")).Style.Font.Bold = true;
                        ws.Range(ws.Cell("A1"), ws.Cell("B1")).Style.Font.FontSize = 14;



                        ws.Cell(2, 1).Value = "ID-Date";
                        ws.Cell(2, 2).Value = "Bầu nóng";
                        ws.Cell(2, 3).Value = "Lần test thứ";
                        ws.Cell(2, 4).Value = "Dòng điện AC (A)";
                        ws.Cell(2, 5).Value = "Nhiệt độ (°C)";
                        ws.Cell(2, 6).Value = "Nhiệt độ ngắt cb nhiệt (°C)";
                        ws.Cell(2, 7).Value = "Trạng thái cb nhiệt";
                        ws.Cell(2, 8).Value = "Lỗi";



                        foreach (var item in list)
                        {
                            ws.Cell(3, 1).Value = date.ToString($"HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);
                            ws.Cell(3, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3, 2).Value = item.BauNongName;
                            ws.Cell(3, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3, 3).Value = item.LanTestThu;
                            ws.Cell(3, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3, 4).Value = item.DongDien;
                            ws.Cell(3, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3, 5).Value = item.NhietDo;
                            ws.Cell(3, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3, 6).Value = item.NhietDoNgatCBNhiet;
                            ws.Cell(3, 6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3, 7).Value = item.TrangThaiCBNhiet == true ? "ON" : "OFF";
                            ws.Cell(3, 7).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3, 8).Value = item.Error;
                            ws.Cell(3, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        }




                        workBook.SaveAs(excelFile);
                    }
                }
                catch
                {

                }
            }
        }









    }
}
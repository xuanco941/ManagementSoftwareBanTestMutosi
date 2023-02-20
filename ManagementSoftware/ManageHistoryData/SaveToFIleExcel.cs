using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.ManageHistoryData
{
    public class SaveToFIleExcel
    {


        static bool checkColorLoiLoc = true;
        bool checkColor = true;



        string nameDisk = "D";
        public void SaveLoiLoc(string nameBanTest, Models.LoiLocModel.LoiLoc loiLoc)
        {
            DateTime date = DateTime.Now;
            var folderPath = Path.Combine($"{nameDisk}:", "ExcelFiles", nameBanTest, date.Year.ToString(), date.Month.ToString("00"));
            Directory.CreateDirectory(folderPath);


            var fileName = $"{date.Day.ToString("00")}.xlsx";

            // Tìm kiếm file Excel trong thư mục với tên tương ứng với giờ trong ngày
            var excelFile = Directory.GetFiles(folderPath, fileName).FirstOrDefault();

            if (excelFile != null)
            {
                // Nếu tìm thấy file Excel, thêm giá trị vào dòng tiếp theo trong file này
                // Mở file Excel dùng làm bản mẫu
                try
                {


                    using (var templateWorkbook = new XLWorkbook(excelFile))
                    {

                        // Lấy worksheet đầu tiên trong file Excel
                        var ws = templateWorkbook.Worksheet(1);

                        // Tìm dòng cuối cùng đã sử dụng trong file Excel
                        var lastUsedRow = ws.LastRowUsed().RowNumber() + 1;

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

                        ws.Cell(lastUsedRow, 9).Value = loiLoc.isOn == true ? "ON" : "OFF";
                        ws.Cell(lastUsedRow, 9).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        ws.Range(lastUsedRow, 1, lastUsedRow, 9).Style.Font.FontSize = 14;


                        if (loiLoc.isOn == false)
                        {
                            ws.Cell(lastUsedRow, 8).Value = " ";
                        }

                        if (checkColorLoiLoc == true)
                        {
                            ws.Range(lastUsedRow, 1, lastUsedRow, 9).Style.Fill.BackgroundColor = XLColor.FromHtml("#dfe8f2");
                        }
                        checkColorLoiLoc = !checkColorLoiLoc;


                        ws.Columns(1, 9).AdjustToContents();

                        // Lưu lại file Excel
                        templateWorkbook.SaveAs(excelFile);
                    }
                }
                catch
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


                        var ws = workBook.Worksheets.Add(nameBanTest + " (" + date.ToString("dd-MM-yyyy") + ")");

                        ws.Range(1, 1, 1, 9).Merge();
                        ws.Range(1, 1, 1, 9).Value = nameBanTest;
                        ws.Range(1, 1, 1, 9).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Range(1, 1, 1, 9).Style.Font.Bold = true;
                        ws.Range(1, 1, 1, 9).Style.Font.FontSize = 18;
                        ws.Range(1, 1, 1, 9).Style.Fill.BackgroundColor = XLColor.Purple;
                        ws.Range(1, 1, 1, 9).Style.Font.FontColor = XLColor.White;


                        ws.Cell(2, 1).Value = "ID-Date";
                        ws.Cell(2, 2).Value = "Lõi lọc";
                        ws.Cell(2, 3).Value = "Lần test thứ";
                        ws.Cell(2, 4).Value = "Áp suất test (bar)";
                        ws.Cell(2, 5).Value = "Thời gian cấp (giây)";
                        ws.Cell(2, 6).Value = "Thời gian giữ (giây)";
                        ws.Cell(2, 7).Value = "Thời gian xả (giây)";
                        ws.Cell(2, 8).Value = "Tình trạng";
                        ws.Cell(2, 9).Value = "Bật/Tắt";

                        for (int i = 1; i < 10; i++)
                        {
                            ws.Cell(2, i).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                            ws.Cell(2, i).Style.Fill.BackgroundColor = XLColor.Yellow;

                        }

                        ws.Range(2, 1, 2, 9).Style.Font.Bold = true;
                        ws.Range(2, 1, 2, 9).Style.Font.FontSize = 16;




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

                        ws.Cell(3, 9).Value = loiLoc.isOn == true ? "ON" : "OFF";
                        ws.Cell(3, 9).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;


                        ws.Range(3, 1, 3, 9).Style.Font.FontSize = 14;

                        if (loiLoc.isOn == false)
                        {
                            ws.Cell(3, 8).Value = " ";
                        }

                        if (checkColorLoiLoc == true)
                        {
                            ws.Range(3, 1, 3, 9).Style.Fill.BackgroundColor = XLColor.FromHtml("#dfe8f2");
                        }
                        checkColorLoiLoc = !checkColorLoiLoc;

                        ws.Columns(1, 9).AdjustToContents();


                        workBook.SaveAs(Path.Combine(folderPath, fileName));
                        workBook.Dispose();
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
            var folderPath = Path.Combine($"{nameDisk}:", "ExcelFiles", nameBanTest, date.Year.ToString(), date.Month.ToString("00"));
            Directory.CreateDirectory(folderPath);


            var fileName = $"{date.Day.ToString("00")}.xlsx";

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
                        var lastUsedRow = ws.LastRowUsed().RowNumber() + 1;

                        // Thêm giá trị vào ô tiếp theo trong dòng cuối cùng
                        ws.Cell(lastUsedRow, 1).Value = "#";
                        ws.Cell(lastUsedRow, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        int i = 1;
                        foreach (var item in list)
                        {
                            ws.Cell(lastUsedRow + i, 1).Value = date.ToString($"HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);
                            ws.Cell(lastUsedRow + i, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow + i, 2).Value = item.BepTuName;
                            ws.Cell(lastUsedRow + i, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow + i, 3).Value = item.LanTestThu;
                            ws.Cell(lastUsedRow + i, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow + i, 4).Value = item.NhietDo;
                            ws.Cell(lastUsedRow + i, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow + i, 5).Value = item.DienAp;
                            ws.Cell(lastUsedRow + i, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow + i, 6).Value = item.DongDien;
                            ws.Cell(lastUsedRow + i, 6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow + i, 7).Value = item.CongSuat;
                            ws.Cell(lastUsedRow + i, 7).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow + i, 8).Value = item.CongSuatTieuThu;
                            ws.Cell(lastUsedRow + i, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow + i, 9).Value = item.Error;
                            ws.Cell(lastUsedRow + i, 9).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow + i, 10).Value = item.isOn == true ? "ON" : "OFF";
                            ws.Cell(lastUsedRow + i, 10).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Range(lastUsedRow+i, 1, lastUsedRow+i, 10).Style.Font.FontSize = 14;


                            if (item.isOn == false)
                            {
                                ws.Cell(lastUsedRow + i, 9).Value = " ";
                            }

                            if (checkColor == true)
                            {
                                ws.Range(lastUsedRow + i, 1, lastUsedRow + i, 10).Style.Fill.BackgroundColor = XLColor.FromHtml("#dfe8f2");
                            }
                            checkColor = !checkColor;

                            i++;
                        }

                        ws.Columns(1, 10).AdjustToContents();

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


                        var ws = workBook.Worksheets.Add(nameBanTest + " (" + date.ToString("dd-MM-yyyy") + ")");

                        ws.Range(1, 1, 1, 10).Merge();
                        ws.Range(1, 1, 1, 10).Value = nameBanTest;
                        ws.Range(1, 1, 1, 10).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Range(1, 1, 1, 10).Style.Font.Bold = true;
                        ws.Range(1, 1, 1, 10).Style.Font.FontSize = 18;
                        ws.Range(1, 1, 1, 10).Style.Fill.BackgroundColor = XLColor.Purple;
                        ws.Range(1, 1, 1, 10).Style.Font.FontColor = XLColor.White;


                        ws.Cell(2, 1).Value = "ID-Date";
                        ws.Cell(2, 2).Value = "Bếp từ";
                        ws.Cell(2, 3).Value = "Lần test thứ";
                        ws.Cell(2, 4).Value = "Nhiệt độ (°C)";
                        ws.Cell(2, 5).Value = "Điện áp (V)";
                        ws.Cell(2, 6).Value = "Dòng điện (A)";
                        ws.Cell(2, 7).Value = "Công suất (Kw)";
                        ws.Cell(2, 8).Value = "Công suất tiêu thụ(Kwh)";
                        ws.Cell(2, 9).Value = "Tình trạng";
                        ws.Cell(2, 10).Value = "Bặt/Tắt";


                        for (int z = 1; z < 11; z++)
                        {
                            ws.Cell(2, z).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                            ws.Cell(2, z).Style.Fill.BackgroundColor = XLColor.Yellow;

                        }

                        ws.Range(2, 1, 2, 10).Style.Font.Bold = true;
                        ws.Range(2, 1, 2, 10).Style.Font.FontSize = 16;

                        ws.Cell(3, 1).Value = "#";
                        ws.Cell(3, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        int i = 1;
                        foreach (var item in list)
                        {
                            ws.Cell(3 + i, 1).Value = date.ToString($"HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);
                            ws.Cell(3 + i, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3 + i, 2).Value = item.BepTuName;
                            ws.Cell(3 + i, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3 + i, 3).Value = item.LanTestThu;
                            ws.Cell(3 + i, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3 + i, 4).Value = item.NhietDo;
                            ws.Cell(3 + i, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3 + i, 5).Value = item.DienAp;
                            ws.Cell(3 + i, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3 + i, 6).Value = item.DongDien;
                            ws.Cell(3 + i, 6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3 + i, 7).Value = item.CongSuat;
                            ws.Cell(3 + i, 7).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3 + i, 8).Value = item.CongSuatTieuThu;
                            ws.Cell(3 + i, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3 + i, 9).Value = item.Error;
                            ws.Cell(3 + i, 9).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3 + i, 10).Value = item.isOn == true ? "ON" : "OFF";
                            ws.Cell(3 + i, 10).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Range(3 + i, 1, 3 + i, 10).Style.Font.FontSize = 14;


                            if (item.isOn == false)
                            {
                                ws.Cell(3 + i, 9).Value = " ";
                            }

                            if (checkColor == true)
                            {
                                ws.Range(3 + i, 1, 3 + i, 10).Style.Fill.BackgroundColor = XLColor.FromHtml("#dfe8f2");
                            }
                            checkColor = !checkColor;

                            i++;
                        }


                        ws.Columns(1, 10).AdjustToContents();

                        workBook.SaveAs(Path.Combine(folderPath, fileName));
                        workBook.Dispose();

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
            var folderPath = Path.Combine($"{nameDisk}:", "ExcelFiles", nameBanTest, date.Year.ToString(), date.Month.ToString("00"));
            Directory.CreateDirectory(folderPath);


            var fileName = $"{date.Day.ToString("00")}.xlsx";

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
                        var lastUsedRow = ws.LastRowUsed().RowNumber() + 1;

                        // Thêm giá trị vào ô tiếp theo trong dòng cuối cùng
                        ws.Cell(lastUsedRow, 1).Value = "#";
                        ws.Cell(lastUsedRow, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        int i = 1;
                        foreach (var item in list)
                        {
                            ws.Cell(lastUsedRow + i, 1).Value = date.ToString($"HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);
                            ws.Cell(lastUsedRow + i, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow + i, 2).Value = item.NguonName;
                            ws.Cell(lastUsedRow + i, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow + i, 3).Value = item.LanTestThu;
                            ws.Cell(lastUsedRow + i, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow + i, 4).Value = item.DienApDC;
                            ws.Cell(lastUsedRow + i, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow + i, 5).Value = item.DongDC;
                            ws.Cell(lastUsedRow + i, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow + i, 6).Value = item.CongSuat;
                            ws.Cell(lastUsedRow + i, 6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow + i, 7).Value = item.ThoiGianTest;
                            ws.Cell(lastUsedRow + i, 7).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;


                            ws.Cell(lastUsedRow + i, 8).Value = item.Error;
                            ws.Cell(lastUsedRow + i, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow + i, 9).Value = item.isOn == true ? "ON" : "OFF";
                            ws.Cell(lastUsedRow + i, 9).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Range(lastUsedRow + i, 1, lastUsedRow + i, 9).Style.Font.FontSize = 14;

                            if (item.isOn == false)
                            {
                                ws.Cell(lastUsedRow + i, 8).Value = " ";
                            }
                            if (checkColor == true)
                            {
                                ws.Range(lastUsedRow + i, 1, lastUsedRow + i, 9).Style.Fill.BackgroundColor = XLColor.FromHtml("#dfe8f2");
                            }
                            checkColor = !checkColor;

                            i++;
                        }
                        ws.Columns(1, 9).AdjustToContents();


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


                        var ws = workBook.Worksheets.Add(nameBanTest + " (" + date.ToString("dd-MM-yyyy") + ")");

                        ws.Range(1, 1, 1, 9).Merge();
                        ws.Range(1, 1, 1, 9).Value = nameBanTest;
                        ws.Range(1, 1, 1, 9).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Range(1, 1, 1, 9).Style.Font.Bold = true;
                        ws.Range(1, 1, 1, 9).Style.Font.FontSize = 18;
                        ws.Range(1, 1, 1, 9).Style.Fill.BackgroundColor = XLColor.Purple;
                        ws.Range(1, 1, 1, 9).Style.Font.FontColor = XLColor.White;


                        ws.Cell(2, 1).Value = "ID-Date";
                        ws.Cell(2, 2).Value = "Nguồn";
                        ws.Cell(2, 3).Value = "Lần test thứ";
                        ws.Cell(2, 4).Value = "Điện áp DC (V)";
                        ws.Cell(2, 5).Value = "Dòng DC (A)";
                        ws.Cell(2, 6).Value = "Công suất (W)";
                        ws.Cell(2, 7).Value = "Thời gian (giây)";
                        ws.Cell(2, 8).Value = "Tình trạng";
                        ws.Cell(2, 9).Value = "Bật/Tắt";

                        for (int z = 1; z < 10; z++)
                        {
                            ws.Cell(2, z).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                            ws.Cell(2, z).Style.Fill.BackgroundColor = XLColor.Yellow;

                        }

                        ws.Range(2, 1, 2, 9).Style.Font.Bold = true;
                        ws.Range(2, 1, 2, 9).Style.Font.FontSize = 16;

                        ws.Cell(3, 1).Value = "#";
                        ws.Cell(3, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        int i = 1;
                        foreach (var item in list)
                        {
                            ws.Cell(3 + i, 1).Value = date.ToString($"HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);
                            ws.Cell(3 + i, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3 + i, 2).Value = item.NguonName;
                            ws.Cell(3 + i, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3 + i, 3).Value = item.LanTestThu;
                            ws.Cell(3 + i, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3 + i, 4).Value = item.DienApDC;
                            ws.Cell(3 + i, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3 + i, 5).Value = item.DongDC;
                            ws.Cell(3 + i, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3 + i, 6).Value = item.CongSuat;
                            ws.Cell(3 + i, 6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3 + i, 7).Value = item.ThoiGianTest;
                            ws.Cell(3 + i, 7).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;


                            ws.Cell(3 + i, 8).Value = item.Error;
                            ws.Cell(3 + i, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3 + i, 9).Value = item.isOn == true ? "ON" : "OFF";
                            ws.Cell(3 + i, 9).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Range(3 + i, 1, 3 + i, 9).Style.Font.FontSize = 14;


                            if (item.isOn == false)
                            {
                                ws.Cell(3 + i, 8).Value = " ";
                            }
                            if (checkColor == true)
                            {
                                ws.Range(3 + i, 1, 3 + i, 9).Style.Fill.BackgroundColor = XLColor.FromHtml("#dfe8f2");
                            }
                            checkColor = !checkColor;

                            i++;
                        }


                        ws.Columns(1, 9).AdjustToContents();


                        workBook.SaveAs(Path.Combine(folderPath, fileName));
                        workBook.Dispose();

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
            var folderPath = Path.Combine($"{nameDisk}:", "ExcelFiles", nameBanTest, date.Year.ToString(), date.Month.ToString("00"));
            Directory.CreateDirectory(folderPath);


            var fileName = $"{date.Day.ToString("00")}.xlsx";

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
                        var lastUsedRow = ws.LastRowUsed().RowNumber() + 1;

                        // Thêm giá trị vào ô tiếp theo trong dòng cuối cùng
                        ws.Cell(lastUsedRow, 1).Value = "#";
                        ws.Cell(lastUsedRow, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        int i = 1;
                        foreach (var item in list)
                        {
                            ws.Cell(lastUsedRow + i, 1).Value = date.ToString($"HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);
                            ws.Cell(lastUsedRow + i, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow + i, 2).Value = item.LedName;
                            ws.Cell(lastUsedRow + i, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow + i, 3).Value = item.LanTestThu;
                            ws.Cell(lastUsedRow + i, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow + i, 4).Value = item.ThoiGianTest;
                            ws.Cell(lastUsedRow + i, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow + i, 5).Value = item.Error;
                            ws.Cell(lastUsedRow + i, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow + i, 6).Value = item.isOn == true ? "ON" : "OFF";
                            ws.Cell(lastUsedRow + i, 6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Range(lastUsedRow + i, 1, lastUsedRow + i, 6).Style.Font.FontSize = 14;


                            if (item.isOn == false)
                            {
                                ws.Cell(lastUsedRow + i, 5).Value = " ";
                            }

                            if (checkColor == true)
                            {
                                ws.Range(lastUsedRow + i, 1, lastUsedRow + i, 6).Style.Fill.BackgroundColor = XLColor.FromHtml("#dfe8f2");
                            }
                            checkColor = !checkColor;

                            i++;
                        }

                        ws.Columns(1, 6).AdjustToContents();

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


                        var ws = workBook.Worksheets.Add(nameBanTest + " (" + date.ToString("dd-MM-yyyy") + ")");

                        ws.Range(1, 1, 1, 6).Merge();
                        ws.Range(1, 1, 1, 6).Value = nameBanTest;
                        ws.Range(1, 1, 1, 6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Range(1, 1, 1, 6).Style.Font.Bold = true;
                        ws.Range(1, 1, 1, 6).Style.Font.FontSize = 18;
                        ws.Range(1, 1, 1, 6).Style.Fill.BackgroundColor = XLColor.Purple;
                        ws.Range(1, 1, 1, 6).Style.Font.FontColor = XLColor.White;


                        ws.Cell(2, 1).Value = "ID-Date";
                        ws.Cell(2, 2).Value = "LED";
                        ws.Cell(2, 3).Value = "Lần test thứ";
                        ws.Cell(2, 4).Value = "Thời gian (giây)";
                        ws.Cell(2, 5).Value = "Tình trạng";
                        ws.Cell(2, 6).Value = "Bật/Tắt";

                        for (int z = 1; z < 7; z++)
                        {
                            ws.Cell(2, z).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                            ws.Cell(2, z).Style.Fill.BackgroundColor = XLColor.Yellow;

                        }
                        ws.Range(2, 1, 2, 6).Style.Font.Bold = true;
                        ws.Range(2, 1, 2, 6).Style.Font.FontSize = 16;

                        ws.Cell(3, 1).Value = "#";
                        ws.Cell(3, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        int i = 1;
                        foreach (var item in list)
                        {
                            ws.Cell(3 + i, 1).Value = date.ToString($"HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);
                            ws.Cell(3 + i, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3 + i, 2).Value = item.LedName;
                            ws.Cell(3 + i, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3 + i, 3).Value = item.LanTestThu;
                            ws.Cell(3 + i, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3 + i, 4).Value = item.ThoiGianTest;
                            ws.Cell(3 + i, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;


                            ws.Cell(3 + i, 5).Value = item.Error;
                            ws.Cell(3 + i, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3 + i, 6).Value = item.isOn == true ? "ON" : "OFF";
                            ws.Cell(3 + i, 6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Range(3 + i, 1, 3 + i, 6).Style.Font.FontSize = 14;


                            if (item.isOn == false)
                            {
                                ws.Cell(3 + i, 5).Value = " ";
                            }

                            if (checkColor == true)
                            {
                                ws.Range(3 + i, 1, 3 + i, 6).Style.Fill.BackgroundColor = XLColor.FromHtml("#dfe8f2");
                            }
                            checkColor = !checkColor;


                            i++;
                        }


                        ws.Columns(1, 6).AdjustToContents();


                        workBook.SaveAs(Path.Combine(folderPath, fileName));
                        workBook.Dispose();
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
            var folderPath = Path.Combine($"{nameDisk}:", "ExcelFiles", nameBanTest, date.Year.ToString(), date.Month.ToString("00"));
            Directory.CreateDirectory(folderPath);


            var fileName = $"{date.Day.ToString("00")}.xlsx";

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
                        var lastUsedRow = ws.LastRowUsed().RowNumber() + 1;

                        // Thêm giá trị vào ô tiếp theo trong dòng cuối cùng
                        ws.Cell(lastUsedRow, 1).Value = "#";
                        ws.Cell(lastUsedRow, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        int i = 1;
                        foreach (var item in list)
                        {
                            ws.Cell(lastUsedRow + i, 1).Value = date.ToString($"HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);
                            ws.Cell(lastUsedRow + i, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow + i, 2).Value = item.JigMachNguonName;
                            ws.Cell(lastUsedRow + i, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow + i, 3).Value = item.LanTestThu;
                            ws.Cell(lastUsedRow + i, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow + i, 4).Value = item.DienApDC;
                            ws.Cell(lastUsedRow + i, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow + i, 5).Value = item.DongDienDC;
                            ws.Cell(lastUsedRow + i, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow + i, 6).Value = item.CongSuat;
                            ws.Cell(lastUsedRow + i, 6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow + i, 7).Value = item.ThoiGian;
                            ws.Cell(lastUsedRow + i, 7).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow + i, 8).Value = item.Error;
                            ws.Cell(lastUsedRow + i, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow + i, 9).Value = item.isOn == true ? "ON" : "OFF";
                            ws.Cell(lastUsedRow + i, 9).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Range(lastUsedRow + i, 1, lastUsedRow + i, 9).Style.Font.FontSize = 14;


                            if (item.isOn == false)
                            {
                                ws.Cell(lastUsedRow + i, 8).Value = " ";
                            }


                            if (checkColor == true)
                            {
                                ws.Range(lastUsedRow + i, 1, lastUsedRow + i, 9).Style.Fill.BackgroundColor = XLColor.FromHtml("#dfe8f2");
                            }
                            checkColor = !checkColor;


                            i++;


                        }

                        ws.Columns(1, 9).AdjustToContents();


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


                        var ws = workBook.Worksheets.Add(nameBanTest + " (" + date.ToString("dd-MM-yyyy") + ")");

                        ws.Range(1, 1, 1, 9).Merge();
                        ws.Range(1, 1, 1, 9).Value = nameBanTest;
                        ws.Range(1, 1, 1, 9).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Range(1, 1, 1, 9).Style.Font.Bold = true;
                        ws.Range(1, 1, 1, 9).Style.Font.FontSize = 18;
                        ws.Range(1, 1, 1, 9).Style.Fill.BackgroundColor = XLColor.Purple;
                        ws.Range(1, 1, 1, 9).Style.Font.FontColor = XLColor.White;


                        ws.Cell(2, 1).Value = "ID-Date";
                        ws.Cell(2, 2).Value = "Jig";
                        ws.Cell(2, 3).Value = "Lần test thứ";
                        ws.Cell(2, 4).Value = "Dòng áp DC (V)";
                        ws.Cell(2, 5).Value = "Dòng điện DC (A)";
                        ws.Cell(2, 6).Value = "Công suất (W)";
                        ws.Cell(2, 7).Value = "Thời gian (giây)";
                        ws.Cell(2, 8).Value = "Tình trạng";
                        ws.Cell(2, 9).Value = "Bật/Tắt";

                        for (int z = 1; z < 10; z++)
                        {
                            ws.Cell(2, z).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                            ws.Cell(2, z).Style.Fill.BackgroundColor = XLColor.Yellow;

                        }

                        ws.Range(2, 1, 2, 9).Style.Font.Bold = true;
                        ws.Range(2, 1, 2, 9).Style.Font.FontSize = 16;

                        ws.Cell(3, 1).Value = "#";
                        ws.Cell(3, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        int i = 1;
                        foreach (var item in list)
                        {
                            ws.Cell(3 + i, 1).Value = date.ToString($"HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);
                            ws.Cell(3 + i, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3 + i, 2).Value = item.JigMachNguonName;
                            ws.Cell(3 + i, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3 + i, 3).Value = item.LanTestThu;
                            ws.Cell(3 + i, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3 + i, 4).Value = item.DienApDC;
                            ws.Cell(3 + i, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3 + i, 5).Value = item.DongDienDC;
                            ws.Cell(3 + i, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3 + i, 6).Value = item.CongSuat;
                            ws.Cell(3 + i, 6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3 + i, 7).Value = item.ThoiGian;
                            ws.Cell(3 + i, 7).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3 + i, 8).Value = item.Error;
                            ws.Cell(3 + i, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3 + i, 9).Value = item.isOn == true ? "ON" : "OFF";
                            ws.Cell(3 + i, 9).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Range(3 + i, 1, 3 + i, 9).Style.Font.FontSize = 14;


                            if (item.isOn == false)
                            {
                                ws.Cell(3 + i, 8).Value = " ";
                            }


                            if (checkColor == true)
                            {
                                ws.Range(3 + i, 1, 3 + i, 9).Style.Fill.BackgroundColor = XLColor.FromHtml("#dfe8f2");
                            }
                            checkColor = !checkColor;

                            i++;
                        }

                        ws.Columns(1, 9).AdjustToContents();



                        workBook.SaveAs(Path.Combine(folderPath, fileName));
                        workBook.Dispose();
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
            var folderPath = Path.Combine($"{nameDisk}:", "ExcelFiles", nameBanTest, date.Year.ToString(), date.Month.ToString("00"));
            Directory.CreateDirectory(folderPath);


            var fileName = $"{date.Day.ToString("00")}.xlsx";

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
                        var lastUsedRow = ws.LastRowUsed().RowNumber() + 1;

                        // Thêm giá trị vào ô tiếp theo trong dòng cuối cùng
                        ws.Cell(lastUsedRow, 1).Value = "#";
                        ws.Cell(lastUsedRow, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        int i = 1;
                        foreach (var item in list)
                        {
                            ws.Cell(lastUsedRow + i, 1).Value = date.ToString($"HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);
                            ws.Cell(lastUsedRow + i, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow + i, 2).Value = item.JigMachTDSName;
                            ws.Cell(lastUsedRow + i, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow + i, 3).Value = item.LanTestThu;
                            ws.Cell(lastUsedRow + i, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow + i, 4).Value = item.VanDienTu == true ? "ON" : "OFF";
                            ws.Cell(lastUsedRow + i, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow + i, 5).Value = item.VanApCao == true ? "ON" : "OFF";
                            ws.Cell(lastUsedRow + i, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow + i, 6).Value = item.ThoiGian;
                            ws.Cell(lastUsedRow + i, 6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow + i, 7).Value = item.Error;
                            ws.Cell(lastUsedRow + i, 7).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow + i, 8).Value = item.isOn == true ? "ON" : "OFF";
                            ws.Cell(lastUsedRow + i, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Range(lastUsedRow + i, 1, lastUsedRow + i, 8).Style.Font.FontSize = 14;


                            if (checkColor == true)
                            {
                                ws.Range(lastUsedRow + i, 1, lastUsedRow + i, 8).Style.Fill.BackgroundColor = XLColor.FromHtml("#dfe8f2");
                            }
                            checkColor = !checkColor;


                            if (item.isOn == false)
                            {
                                ws.Cell(lastUsedRow + i, 7).Value = " ";
                            }

                            i++;
                        }

                        ws.Columns(1, 8).AdjustToContents();


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


                        var ws = workBook.Worksheets.Add(nameBanTest + " (" + date.ToString("dd-MM-yyyy") + ")");

                        ws.Range(1, 1, 1, 8).Merge();
                        ws.Range(1, 1, 1, 8).Value = nameBanTest;
                        ws.Range(1, 1, 1, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Range(1, 1, 1, 8).Style.Font.Bold = true;
                        ws.Range(1, 1, 1, 8).Style.Font.FontSize = 18;
                        ws.Range(1, 1, 1, 8).Style.Fill.BackgroundColor = XLColor.Purple;
                        ws.Range(1, 1, 1, 8).Style.Font.FontColor = XLColor.White;


                        ws.Cell(2, 1).Value = "ID-Date";
                        ws.Cell(2, 2).Value = "Jig";
                        ws.Cell(2, 3).Value = "Lần test thứ";
                        ws.Cell(2, 4).Value = "Van điện từ";
                        ws.Cell(2, 5).Value = "Van áp cao";
                        ws.Cell(2, 6).Value = "Thời gian (giây)";
                        ws.Cell(2, 7).Value = "Tình trạng";
                        ws.Cell(2, 8).Value = "Bật/Tắt";

                        for (int z = 1; z < 9; z++)
                        {
                            ws.Cell(2, z).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                            ws.Cell(2, z).Style.Fill.BackgroundColor = XLColor.Yellow;

                        }

                        ws.Range(2, 1, 2, 8).Style.Font.Bold = true;
                        ws.Range(2, 1, 2, 8).Style.Font.FontSize = 16;

                        ws.Cell(3, 1).Value = "#";
                        ws.Cell(3, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        int i = 1;
                        foreach (var item in list)
                        {
                            ws.Cell(3 + i, 1).Value = date.ToString($"HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);
                            ws.Cell(3 + i, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3 + i, 2).Value = item.JigMachTDSName;
                            ws.Cell(3 + i, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3 + i, 3).Value = item.LanTestThu;
                            ws.Cell(3 + i, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3 + i, 4).Value = item.VanDienTu == true ? "ON" : "OFF";
                            ws.Cell(3 + i, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3 + i, 5).Value = item.VanApCao == true ? "ON" : "OFF";
                            ws.Cell(3 + i, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3 + i, 6).Value = item.ThoiGian;
                            ws.Cell(3 + i, 6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3 + i, 7).Value = item.Error;
                            ws.Cell(3 + i, 7).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3 + i, 8).Value = item.isOn == true ? "ON" : "OFF";
                            ws.Cell(3 + i, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Range(3 + i, 1, 3 + i, 8).Style.Font.FontSize = 14;


                            if (item.isOn == false)
                            {
                                ws.Cell(3 + i, 7).Value = " ";
                            }


                            if (checkColor == true)
                            {
                                ws.Range(3 + i, 1, 3 + i, 8).Style.Fill.BackgroundColor = XLColor.FromHtml("#dfe8f2");
                            }
                            checkColor = !checkColor;

                            i++;
                        }

                        ws.Columns(1, 8).AdjustToContents();



                        workBook.SaveAs(Path.Combine(folderPath, fileName));
                        workBook.Dispose();
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
            var folderPath = Path.Combine($"{nameDisk}:", "ExcelFiles", nameBanTest, date.Year.ToString(), date.Month.ToString("00"));
            Directory.CreateDirectory(folderPath);


            var fileName = $"{date.Day.ToString("00")}.xlsx";

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
                        var lastUsedRow = ws.LastRowUsed().RowNumber() + 1;

                        // Thêm giá trị vào ô tiếp theo trong dòng cuối cùng
                        ws.Cell(lastUsedRow, 1).Value = "#";
                        ws.Cell(lastUsedRow, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        int i = 1;
                        foreach (var item in list)
                        {
                            ws.Cell(lastUsedRow + i, 1).Value = date.ToString($"HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);
                            ws.Cell(lastUsedRow + i, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow + i, 2).Value = item.CongTacName + " - " + item.JigCongTac;
                            ws.Cell(lastUsedRow + i, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow + i, 3).Value = item.TrangThai == true ? "ON" : "OFF";
                            ws.Cell(lastUsedRow + i, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow + i, 4).Value = item.LanTestThu;
                            ws.Cell(lastUsedRow + i, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow + i, 5).Value = item.Error;
                            ws.Cell(lastUsedRow + i, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow + i, 6).Value = item.isOn == true ? "ON" : "OFF";
                            ws.Cell(lastUsedRow + i, 6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Range(lastUsedRow + i, 1, lastUsedRow + i, 6).Style.Font.FontSize = 14;


                            if (checkColor == true)
                            {
                                ws.Range(lastUsedRow + i, 1, lastUsedRow + i, 6).Style.Fill.BackgroundColor = XLColor.FromHtml("#dfe8f2");
                            }
                            checkColor = !checkColor;


                            if (item.isOn == false)
                            {
                                ws.Cell(lastUsedRow + i, 5).Value = " ";
                            }

                            i++;
                        }

                        ws.Columns(1, 6).AdjustToContents();


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


                        var ws = workBook.Worksheets.Add(nameBanTest + " (" + date.ToString("dd-MM-yyyy") + ")");

                        ws.Range(1, 1, 1, 6).Merge();
                        ws.Range(1, 1, 1, 6).Value = nameBanTest;
                        ws.Range(1, 1, 1, 6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Range(1, 1, 1, 6).Style.Font.Bold = true;
                        ws.Range(1, 1, 1, 6).Style.Font.FontSize = 18;
                        ws.Range(1, 1, 1, 6).Style.Fill.BackgroundColor = XLColor.Purple;
                        ws.Range(1, 1, 1, 6).Style.Font.FontColor = XLColor.White;


                        ws.Cell(2, 1).Value = "ID-Date";
                        ws.Cell(2, 2).Value = "Công tắc";
                        ws.Cell(2, 3).Value = "Trạng thái";
                        ws.Cell(2, 4).Value = "Lần test thứ";
                        ws.Cell(2, 5).Value = "Tình trạng";
                        ws.Cell(2, 6).Value = "Bật/Tắt";

                        for (int z = 1; z < 7; z++)
                        {
                            ws.Cell(2, z).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                            ws.Cell(2, z).Style.Fill.BackgroundColor = XLColor.Yellow;

                        }

                        ws.Range(2, 1, 2, 6).Style.Font.Bold = true;
                        ws.Range(2, 1, 2, 6).Style.Font.FontSize = 16;

                        ws.Cell(3, 1).Value = "#";
                        ws.Cell(3, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        int i = 1;
                        foreach (var item in list)
                        {
                            ws.Cell(3 + i, 1).Value = date.ToString($"HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);
                            ws.Cell(3 + i, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3 + i, 2).Value = item.CongTacName + " - " + item.JigCongTac;
                            ws.Cell(3 + i, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3 + i, 3).Value = item.TrangThai == true ? "ON" : "OFF";
                            ws.Cell(3 + i, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3 + i, 4).Value = item.LanTestThu;
                            ws.Cell(3 + i, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3 + i, 5).Value = item.Error;
                            ws.Cell(3 + i, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3 + i, 6).Value = item.isOn == true ? "ON" : "OFF";
                            ws.Cell(3 + i, 6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Range(3 + i, 1, 3 + i, 6).Style.Font.FontSize = 14;

                            if (item.isOn == false)
                            {
                                ws.Cell(3 + i, 5).Value = " ";
                            }


                            if (checkColor == true)
                            {
                                ws.Range(3 + i, 1, 3 + i, 6).Style.Fill.BackgroundColor = XLColor.FromHtml("#dfe8f2");
                            }
                            checkColor = !checkColor;

                            i++;
                        }

                        ws.Columns(1, 6).AdjustToContents();



                        workBook.SaveAs(Path.Combine(folderPath, fileName));
                        workBook.Dispose();
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
            var folderPath = Path.Combine($"{nameDisk}:", "ExcelFiles", nameBanTest, date.Year.ToString(), date.Month.ToString("00"));
            Directory.CreateDirectory(folderPath);


            var fileName = $"{date.Day.ToString("00")}.xlsx";

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
                        var lastUsedRow = ws.LastRowUsed().RowNumber() + 1;

                        // Thêm giá trị vào ô tiếp theo trong dòng cuối cùng
                        ws.Cell(lastUsedRow, 1).Value = "#";
                        ws.Cell(lastUsedRow, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        int i = 1;
                        foreach (var item in list)
                        {
                            ws.Cell(lastUsedRow + i, 1).Value = date.ToString($"HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);
                            ws.Cell(lastUsedRow + i, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow + i, 2).Value = item.BauNongName;
                            ws.Cell(lastUsedRow + i, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow + i, 3).Value = item.LanTestThu;
                            ws.Cell(lastUsedRow + i, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow + i, 4).Value = item.DongDien;
                            ws.Cell(lastUsedRow + i, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow + i, 5).Value = item.NhietDo;
                            ws.Cell(lastUsedRow + i, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow + i, 6).Value = item.NhietDoNgatCBNhiet;
                            ws.Cell(lastUsedRow + i, 6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow + i, 7).Value = item.TrangThaiCBNhiet == true ? "ON" : "OFF";
                            ws.Cell(lastUsedRow + i, 7).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow + i, 8).Value = item.Error;
                            ws.Cell(lastUsedRow + i, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(lastUsedRow + i, 9).Value = item.isOn == true ? "ON" : "OFF";
                            ws.Cell(lastUsedRow + i, 9).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Range(lastUsedRow + i, 1, lastUsedRow + i, 9).Style.Font.FontSize = 14;


                            if (checkColor == true)
                            {
                                ws.Range(lastUsedRow + i, 1, lastUsedRow + i, 9).Style.Fill.BackgroundColor = XLColor.FromHtml("#dfe8f2");
                            }
                            checkColor = !checkColor;


                            if (item.isOn == false)
                            {
                                ws.Cell(lastUsedRow + i, 8).Value = " ";
                            }

                            i++;
                        }


                        ws.Columns(1, 9).AdjustToContents();


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


                        var ws = workBook.Worksheets.Add(nameBanTest + " (" + date.ToString("dd-MM-yyyy") + ")");

                        ws.Range(1, 1, 1, 9).Merge();
                        ws.Range(1, 1, 1, 9).Value = nameBanTest;
                        ws.Range(1, 1, 1, 9).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Range(1, 1, 1, 9).Style.Font.Bold = true;
                        ws.Range(1, 1, 1, 9).Style.Font.FontSize = 18;
                        ws.Range(1, 1, 1, 9).Style.Fill.BackgroundColor = XLColor.Purple;
                        ws.Range(1, 1, 1, 9).Style.Font.FontColor = XLColor.White;


                        ws.Cell(2, 1).Value = "ID-Date";
                        ws.Cell(2, 2).Value = "Bầu nóng";
                        ws.Cell(2, 3).Value = "Lần test thứ";
                        ws.Cell(2, 4).Value = "Dòng điện AC (A)";
                        ws.Cell(2, 5).Value = "Nhiệt độ (°C)";
                        ws.Cell(2, 6).Value = "Nhiệt độ ngắt cb nhiệt (°C)";
                        ws.Cell(2, 7).Value = "Trạng thái cb nhiệt";
                        ws.Cell(2, 8).Value = "Tình trạng";
                        ws.Cell(2, 9).Value = "Bật/Tắt";

                        for (int z = 1; z < 10; z++)
                        {
                            ws.Cell(2, z).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                            ws.Cell(2, z).Style.Fill.BackgroundColor = XLColor.Yellow;

                        }

                        ws.Range(2, 1, 2, 9).Style.Font.Bold = true;
                        ws.Range(2, 1, 2, 9).Style.Font.FontSize = 16;

                        ws.Cell(3, 1).Value = "#";
                        ws.Cell(3, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        int i = 1;
                        foreach (var item in list)
                        {
                            ws.Cell(3 + i, 1).Value = date.ToString($"HH:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture);
                            ws.Cell(3 + i, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3 + i, 2).Value = item.BauNongName;
                            ws.Cell(3 + i, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3 + i, 3).Value = item.LanTestThu;
                            ws.Cell(3 + i, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3 + i, 4).Value = item.DongDien;
                            ws.Cell(3 + i, 4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3 + i, 5).Value = item.NhietDo;
                            ws.Cell(3 + i, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3 + i, 6).Value = item.NhietDoNgatCBNhiet;
                            ws.Cell(3 + i, 6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3 + i, 7).Value = item.TrangThaiCBNhiet == true ? "ON" : "OFF";
                            ws.Cell(3 + i, 7).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3 + i, 8).Value = item.Error;
                            ws.Cell(3 + i, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(3 + i, 9).Value = item.isOn == true ? "ON" : "OFF";
                            ws.Cell(3 + i, 9).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Range(3 + i, 1, 3 + i, 9).Style.Font.FontSize = 14;


                            if (item.isOn == false)
                            {
                                ws.Cell(3 + i, 8).Value = " ";
                            }


                            if (checkColor == true)
                            {
                                ws.Range(3 + i, 1, 3 + i, 9).Style.Fill.BackgroundColor = XLColor.FromHtml("#dfe8f2");
                            }
                            checkColor = !checkColor;


                            i++;
                        }


                        ws.Columns(1, 9).AdjustToContents();


                        workBook.SaveAs(Path.Combine(folderPath, fileName));
                        workBook.Dispose();
                    }
                }
                catch
                {

                }
            }
        }









    }
}
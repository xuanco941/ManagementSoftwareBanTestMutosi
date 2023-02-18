using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.GUI
{
    public class XuatExcel
    {
        public void Xuat(string title, DataGridView dgv)
        {
            if (dgv.Rows != null && dgv.Rows.Count != 0)
            {

                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel | *.xlsx | Excel 2016 | *.xls" })
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            using (var workBook = new XLWorkbook())
                            {


                                var ws = workBook.Worksheets.Add("Lịch sử test");


                                ws.Range(1, 1, 1, dgv.Columns.Count).Merge();
                                ws.Range(1, 1, 1, dgv.Columns.Count).Value = title;
                                ws.Range(1, 1, 1, dgv.Columns.Count).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                                ws.Range(1, 1, 1, dgv.Columns.Count).Style.Font.Bold = true;
                                ws.Range(1, 1, 1, dgv.Columns.Count).Style.Font.FontSize = 16;



                                for (int i = 0; i < dgv.Columns.Count; i++)
                                {
                                    ws.Cell(2, 1 + i).Value = dgv.Columns[i].HeaderText;
                                    ws.Cell(2, 1 + i).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                                    ws.Cell(2, 1 + i).Style.Font.Bold = true;
                                    ws.Cell(2, 1 + i).Style.Font.FontSize = 12;
                                }



                                for (int i = 0; i < dgv.Rows.Count; i++)
                                {
                                    for (int j = 0; j < dgv.Columns.Count; j++)
                                    {
                                        if (dgv.Rows[i].Cells[j].Value != null)
                                        {
                                            ws.Cell(i + 3, j + 1).Value = dgv.Rows[i].Cells[j].Value.ToString();
                                            ws.Cell(i + 3, j + 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                                        }
                                        else
                                        {
                                            continue;
                                        }
                                    }
                                }

                                ws.Columns(1, dgv.Columns.Count).AdjustToContents();


                                string tenfile = ".xlsx";
                                workBook.SaveAs(sfd.FileName + DateTime.Now.ToString("dd_mm_yyyy_hhmmss") + tenfile);
                                MessageBox.Show($"Xuất file {title} thành công.");
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Không thể xuất file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

            }
            else
            {
                MessageBox.Show("Không tìm thấy dữ liệu để xuất Excel.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}

using ClosedXML.Excel;
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

                                ws.Range(ws.Cell("A1"), ws.Cell("B1")).Merge();
                                ws.Range(ws.Cell("A1"), ws.Cell("B1")).Value = title;
                                ws.Range(ws.Cell("A1"), ws.Cell("B1")).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                                ws.Range(ws.Cell("A1"), ws.Cell("B1")).Style.Font.Bold = true;
                                ws.Range(ws.Cell("A1"), ws.Cell("B1")).Style.Font.FontSize = 14;


                                for (int i = 0; i < dgv.Columns.Count; i++)
                                {
                                    ws.Cell(2, 1 + i).Value = dgv.Columns[i].HeaderText;
                                }

                                for (int i = 0; i < dgv.Rows.Count; i++)
                                {
                                    for (int j = 0; j < dgv.Columns.Count; j++)
                                    {
                                        if(dgv.Rows[i].Cells[j].Value != null)
                                        {
                                            ws.Cell(i + 3, j + 1).Value = dgv.Rows[i].Cells[j].Value.ToString();
                                            ws.Cell(i + 3, j + 1).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                                        }
                                        else
                                        {
                                            continue;
                                        }
                                    }
                                }

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

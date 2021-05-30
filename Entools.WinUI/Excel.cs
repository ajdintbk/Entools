using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _Excel = Microsoft.Office.Interop.Excel;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace Entools.WinUI
{
    public class Excel
    {
        string path = "";
        _Application excel = new _Excel.Application();
        Workbook wb;
        Worksheet ws;
        public Excel(string path, int sheet)
        {
            this.path = path;
            wb = excel.Workbooks.Open(path);
            ws = wb.Worksheets[sheet];
        }

        public string ReadCell(int i, int j)
        {
            if (ws.Cells[i, j].Value2 != null)
                return Convert.ToString(ws.Cells[i, j].Value2);
            else
                return null;
        }

        public void InsertCell(int i, int j, string s)
        {
            ws.Cells[i, j].Value2 = s;
            wb.Save();
        }

        public int LastRowRecorded()
        {
            Range last = ws.Cells.SpecialCells(XlCellType.xlCellTypeLastCell, Type.Missing);
            return last.Row;
        }

        public int LastColumnRecorded()
        {
            Range last = ws.Cells.SpecialCells(XlCellType.xlCellTypeLastCell, Type.Missing);
            return last.Column;
        }

        public void Save()
        {
            wb.Save();
        }
        public void Close()
        {
            wb.Close();
        }
    }
}

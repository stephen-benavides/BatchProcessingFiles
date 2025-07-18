using OfficeOpenXml;
using source.Model;

namespace source.Services
{
    public class ExcelFileReader
    {
        private string _filePath;

        public ExcelFileReader(string filePath)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            _filePath = filePath;
        }

        public List<ExcelCell> GetAllColumnValues(int worksheetIndex, int columnIndex)
        {
            List<ExcelCell> lstExcelColumnsValue = new List<ExcelCell>();
            //Check if the file exists
            if (File.Exists(_filePath))
            {
                //Load the Excel File
                //Get the file form the path
                FileInfo fileInfo = new FileInfo(_filePath);
                using (ExcelPackage excelPackage = new ExcelPackage(fileInfo))
                {
                    //get the first worksheet in excel
                    ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets[worksheetIndex];

                    //Read the values from the worksheet (from the first row to the last (skip the first ro HEADERSw)
                    for (int row = excelWorksheet.Dimension.Start.Row + 1; row <= excelWorksheet.Dimension.End.Row; row++)
                    {
                        //Get the value of the row and second column
                        var cellValue = excelWorksheet.Cells[row, columnIndex].Text;
                        lstExcelColumnsValue.Add(new ExcelCell()
                        {
                            Value = cellValue,
                            Column = columnIndex,
                            Row = row
                        });
                    }


                    /*//For each for get from the second column onwards 
                    for (int column = excelWorksheet.Dimension.Start.Column + 1; column < excelWorksheet.Dimension.End.Column; row++)
                    {
                        //get the value of the row and column
                        var cellValue = excelWorksheet.Cells[row, column].Text;
                    }*/
                }
            }

            return lstExcelColumnsValue;
        }
    }
}

using NPOI.HSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

namespace JSYCRM.DAL
{
    public class NpoiExcel
    {
        public static Stream RenderWorkerTableToExcelWorkers(DataTable SourceTable)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            MemoryStream ms = new MemoryStream();
            HSSFSheet sheet = workbook.CreateSheet("mysheet");

            HSSFCellStyle StyleHeader = workbook.CreateCellStyle();
            HSSFFont fontHeader = workbook.CreateFont();
            fontHeader.FontHeightInPoints = 10;
            fontHeader.FontName = "Arial";
            fontHeader.Boldweight = (short)HSSFFont.BOLDWEIGHT_BOLD;
            StyleHeader.SetFont(fontHeader);

            HSSFCellStyle StyleHighLight = workbook.CreateCellStyle();

            /*
            StyleHighLight.BorderBottom = CellBorderType.THIN;
            StyleHighLight.BottomBorderColor = HSSFColor.BLACK.index;
            StyleHighLight.BorderLeft = CellBorderType.DASH_DOT_DOT;
            StyleHighLight.LeftBorderColor = HSSFColor.GREEN.index;
            StyleHighLight.BorderRight = CellBorderType.HAIR;
            StyleHighLight.RightBorderColor = HSSFColor.BLUE.index;
            StyleHighLight.BorderTop = CellBorderType.MEDIUM_DASHED;
            StyleHighLight.TopBorderColor = HSSFColor.ORANGE.index;
            */

            StyleHighLight.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.LIGHT_YELLOW.index;
            StyleHighLight.FillPattern = CellFillPattern.SOLID_FOREGROUND;

            // handling header.
            HSSFRow headerRow = sheet.CreateRow(0);
            headerRow.CreateCell(0).SetCellValue("姓名");
            headerRow.CreateCell(1).SetCellValue("性别");
            headerRow.CreateCell(2).SetCellValue("联系方式");
            headerRow.CreateCell(3).SetCellValue("联系地址");
            headerRow.CreateCell(4).SetCellValue("创建地区");
            headerRow.CreateCell(5).SetCellValue("到期时间");
            headerRow.CreateCell(6).SetCellValue("身份证号");
            headerRow.CreateCell(7).SetCellValue("管道");
            headerRow.CreateCell(8).SetCellValue("工作地点");
            headerRow.CreateCell(9).SetCellValue("是否输送");
            headerRow.CreateCell(10).SetCellValue("输送日期");
            headerRow.CreateCell(11).SetCellValue("是否通过面试");
            headerRow.CreateCell(12).SetCellValue("通过面试日期");
            headerRow.CreateCell(13).SetCellValue("是否报道");
            headerRow.CreateCell(14).SetCellValue("报道日期");
            headerRow.CreateCell(15).SetCellValue("是否离职");
            headerRow.CreateCell(16).SetCellValue("离职日期");
            headerRow.CreateCell(17).SetCellValue("毕业年份");
            headerRow.CreateCell(18).SetCellValue("户籍");
            headerRow.CreateCell(19).SetCellValue("学历");
            headerRow.CreateCell(20).SetCellValue("家庭电话");
            headerRow.CreateCell(21).SetCellValue("家庭地址");
            headerRow.CreateCell(22).SetCellValue("创建人");
            headerRow.CreateCell(23).SetCellValue("创建时间");
            headerRow.CreateCell(24).SetCellValue("更新人");
            headerRow.CreateCell(25).SetCellValue("更新时间");

            headerRow.GetCell(0).CellStyle = StyleHeader;
            headerRow.GetCell(1).CellStyle = StyleHeader;
            headerRow.GetCell(2).CellStyle = StyleHeader;
            headerRow.GetCell(3).CellStyle = StyleHeader;
            headerRow.GetCell(4).CellStyle = StyleHeader;
            headerRow.GetCell(5).CellStyle = StyleHeader;
            headerRow.GetCell(6).CellStyle = StyleHeader;
            headerRow.GetCell(7).CellStyle = StyleHeader;
            headerRow.GetCell(8).CellStyle = StyleHeader;
            headerRow.GetCell(9).CellStyle = StyleHeader;
            headerRow.GetCell(10).CellStyle = StyleHeader;
            headerRow.GetCell(11).CellStyle = StyleHeader;
            headerRow.GetCell(12).CellStyle = StyleHeader;
            headerRow.GetCell(13).CellStyle = StyleHeader;
            headerRow.GetCell(14).CellStyle = StyleHeader;
            headerRow.GetCell(15).CellStyle = StyleHeader;
            headerRow.GetCell(16).CellStyle = StyleHeader;
            headerRow.GetCell(17).CellStyle = StyleHeader;
            headerRow.GetCell(18).CellStyle = StyleHeader;
            headerRow.GetCell(19).CellStyle = StyleHeader;
            headerRow.GetCell(20).CellStyle = StyleHeader;
            headerRow.GetCell(21).CellStyle = StyleHeader;
            headerRow.GetCell(22).CellStyle = StyleHeader;
            headerRow.GetCell(23).CellStyle = StyleHeader;
            headerRow.GetCell(24).CellStyle = StyleHeader;
            headerRow.GetCell(25).CellStyle = StyleHeader;

            // handling value.
            int rowIndex = 1;

            foreach (DataRow row in SourceTable.Rows)
            {
                HSSFRow dataRow = sheet.CreateRow(rowIndex);

                dataRow.CreateCell(0).SetCellValue(row["B_NAME"].ToString());
                dataRow.CreateCell(1).SetCellValue(row["B_GENDER"].ToString());
                dataRow.CreateCell(2).SetCellValue(row["B_TEL"].ToString());
                dataRow.CreateCell(3).SetCellValue(row["B_ADDRESS"].ToString());
                dataRow.CreateCell(4).SetCellValue(row["B_CREATE_AREA"].ToString());
                dataRow.CreateCell(5).SetCellValue(row["B_EXPIRY_DATA"].ToString());
                dataRow.CreateCell(6).SetCellValue(row["B_ID_CARD"].ToString());
                dataRow.CreateCell(7).SetCellValue(row["B_ASSOCIATED_USER"].ToString());
                dataRow.CreateCell(8).SetCellValue(row["W_WORK_AREA"].ToString());
                dataRow.CreateCell(9).SetCellValue(row["W_IS_DELIVERY"].ToString() == "1" ? "是" : "否");
                dataRow.CreateCell(10).SetCellValue(row["W_DELIVERY_DATA"].ToString());
                dataRow.CreateCell(11).SetCellValue(row["W_IS_PASS_INTERVIEW"].ToString() == "1" ? "是" : "否");
                dataRow.CreateCell(12).SetCellValue(row["W_INTERVIEW_DATA"].ToString());
                dataRow.CreateCell(13).SetCellValue(row["W_IS_ONBOARD"].ToString() == "1" ? "是" : "否");
                dataRow.CreateCell(14).SetCellValue(row["W_ONBOARD_DATA"].ToString());
                dataRow.CreateCell(15).SetCellValue(row["W_IS_RESIGNATION"].ToString() == "1" ? "是" : "否");
                dataRow.CreateCell(16).SetCellValue(row["W_RESIGNATION_DATA"].ToString());
                dataRow.CreateCell(17).SetCellValue(row["A_GRADUATE_DATA"].ToString());
                dataRow.CreateCell(18).SetCellValue(row["A_CENSUS"].ToString());
                dataRow.CreateCell(19).SetCellValue(row["A_EDU_BACKGROUND"].ToString());
                dataRow.CreateCell(20).SetCellValue(row["A_HOME_TEL"].ToString());
                dataRow.CreateCell(21).SetCellValue(row["A_HOME_ADDRESS"].ToString());
                dataRow.CreateCell(22).SetCellValue(row["CREATE_USER"].ToString());
                dataRow.CreateCell(23).SetCellValue(row["CREATE_DATETIME"].ToString());
                dataRow.CreateCell(24).SetCellValue(row["UPDATE_USER"].ToString());
                dataRow.CreateCell(25).SetCellValue(row["UPDATE_DATETIME"].ToString());

                /*
                if (row["SYNCHRONOUS"].ToString() == "0")
                {
                    dataRow.GetCell(0).CellStyle = StyleHighLight;
                    dataRow.GetCell(1).CellStyle = StyleHighLight;
                    dataRow.GetCell(2).CellStyle = StyleHighLight;
                    dataRow.GetCell(3).CellStyle = StyleHighLight;
                    dataRow.GetCell(4).CellStyle = StyleHighLight;
                    dataRow.GetCell(5).CellStyle = StyleHighLight;
                    dataRow.GetCell(6).CellStyle = StyleHighLight;
                }
                */
                rowIndex++;
            }

            workbook.Write(ms);
            ms.Flush();
            ms.Position = 0;

            sheet = null;
            headerRow = null;
            workbook = null;

            return ms;
        }

        public static Stream RenderWorkerTableToExcelFee(DataTable SourceTable)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            MemoryStream ms = new MemoryStream();
            HSSFSheet sheet = workbook.CreateSheet("mysheet");

            HSSFCellStyle StyleHeader = workbook.CreateCellStyle();
            HSSFFont fontHeader = workbook.CreateFont();
            fontHeader.FontHeightInPoints = 10;
            fontHeader.FontName = "Arial";
            fontHeader.Boldweight = (short)HSSFFont.BOLDWEIGHT_BOLD;
            StyleHeader.SetFont(fontHeader);

            HSSFCellStyle StyleHighLight = workbook.CreateCellStyle();

            /*
            StyleHighLight.BorderBottom = CellBorderType.THIN;
            StyleHighLight.BottomBorderColor = HSSFColor.BLACK.index;
            StyleHighLight.BorderLeft = CellBorderType.DASH_DOT_DOT;
            StyleHighLight.LeftBorderColor = HSSFColor.GREEN.index;
            StyleHighLight.BorderRight = CellBorderType.HAIR;
            StyleHighLight.RightBorderColor = HSSFColor.BLUE.index;
            StyleHighLight.BorderTop = CellBorderType.MEDIUM_DASHED;
            StyleHighLight.TopBorderColor = HSSFColor.ORANGE.index;
            */

            StyleHighLight.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.LIGHT_YELLOW.index;
            StyleHighLight.FillPattern = CellFillPattern.SOLID_FOREGROUND;

            // handling header.
            HSSFRow headerRow = sheet.CreateRow(0);
            headerRow.CreateCell(0).SetCellValue("姓名");
            headerRow.CreateCell(1).SetCellValue("性别");
            headerRow.CreateCell(2).SetCellValue("联系方式");
            headerRow.CreateCell(3).SetCellValue("联系地址");
            headerRow.CreateCell(4).SetCellValue("创建地区");
            headerRow.CreateCell(5).SetCellValue("管道");
            headerRow.CreateCell(6).SetCellValue("创建时间");
            headerRow.CreateCell(7).SetCellValue("当前状态");
            headerRow.CreateCell(8).SetCellValue("状态时间");
            headerRow.CreateCell(9).SetCellValue("适用规则");
            headerRow.CreateCell(10).SetCellValue("规则详细");
            headerRow.CreateCell(11).SetCellValue("返费");

            headerRow.GetCell(0).CellStyle = StyleHeader;
            headerRow.GetCell(1).CellStyle = StyleHeader;
            headerRow.GetCell(2).CellStyle = StyleHeader;
            headerRow.GetCell(3).CellStyle = StyleHeader;
            headerRow.GetCell(4).CellStyle = StyleHeader;
            headerRow.GetCell(5).CellStyle = StyleHeader;
            headerRow.GetCell(6).CellStyle = StyleHeader;
            headerRow.GetCell(7).CellStyle = StyleHeader;
            headerRow.GetCell(8).CellStyle = StyleHeader;
            headerRow.GetCell(9).CellStyle = StyleHeader;
            headerRow.GetCell(10).CellStyle = StyleHeader;
            headerRow.GetCell(11).CellStyle = StyleHeader;



            // handling value.
            int rowIndex = 1;

            foreach (DataRow row in SourceTable.Rows)
            {
                HSSFRow dataRow = sheet.CreateRow(rowIndex);

                dataRow.CreateCell(0).SetCellValue(row["B_NAME"].ToString());
                dataRow.CreateCell(1).SetCellValue(row["B_GENDER"].ToString());
                dataRow.CreateCell(2).SetCellValue(row["B_TEL"].ToString());
                dataRow.CreateCell(3).SetCellValue(row["B_ADDRESS"].ToString());
                dataRow.CreateCell(4).SetCellValue(row["B_CREATE_AREA"].ToString());
                dataRow.CreateCell(5).SetCellValue(row["B_ASSOCIATED_USER"].ToString());
                dataRow.CreateCell(6).SetCellValue(DateTime.Parse(row["CREATE_DATETIME"].ToString()).ToString("yyyy-MM-dd"));
                dataRow.CreateCell(7).SetCellValue(JSYCRM.Common.Common.getWorkerStatus(int.Parse(row["STATUS"].ToString())));
                dataRow.CreateCell(8).SetCellValue(DateTime.Parse(row["STATUS_DATA"].ToString()).ToString("yyyy-MM-dd"));
                dataRow.CreateCell(9).SetCellValue(row["RULE_NAME"].ToString());
                dataRow.CreateCell(10).SetCellValue(row["RULE_DETAIL"].ToString());

                if (row["B_GENDER"].ToString() == "男")
                {
                    dataRow.CreateCell(11).SetCellValue(row["FEE_MAN"].ToString());
                }
                else if (row["B_GENDER"].ToString() == "女")
                {
                    dataRow.CreateCell(11).SetCellValue(row["FEE_WOMEN"].ToString());
                }
                else
                {
                    dataRow.CreateCell(11).SetCellValue("0");
                }
                rowIndex++;
            }

            workbook.Write(ms);
            ms.Flush();
            ms.Position = 0;

            sheet = null;
            headerRow = null;
            workbook = null;

            return ms;
        }

        /*

        public static Stream RenderDataTableToExcel(DataTable SourceTable)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            MemoryStream ms = new MemoryStream();
            HSSFSheet sheet = workbook.CreateSheet();
            HSSFRow headerRow = sheet.CreateRow(0);

            // handling header.
            foreach (DataColumn column in SourceTable.Columns)
                headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);

            // handling value.
            int rowIndex = 1;

            foreach (DataRow row in SourceTable.Rows)
            {
                HSSFRow dataRow = sheet.CreateRow(rowIndex);

                foreach (DataColumn column in SourceTable.Columns)
                {
                    dataRow.CreateCell(column.Ordinal).SetCellValue(row[column].ToString());
                }

                rowIndex++;
            }

            workbook.Write(ms);
            ms.Flush();
            ms.Position = 0;

            sheet = null;
            headerRow = null;
            workbook = null;

            return ms;
        }

        public static void RenderDataTableToExcel(DataTable SourceTable, string FileName)
        {
            MemoryStream ms = RenderDataTableToExcel(SourceTable) as MemoryStream;
            FileStream fs = new FileStream(FileName, FileMode.Create, FileAccess.Write);
            byte[] data = ms.ToArray();

            fs.Write(data, 0, data.Length);
            fs.Flush();
            fs.Close();

            data = null;
            ms = null;
            fs = null;
        }

        */

        public static DataTable RenderDataTableFromExcel(Stream ExcelFileStream, string SheetName, int HeaderRowIndex)
        {
            HSSFWorkbook workbook = null;
            HSSFSheet sheet = null;
            HSSFRow headerRow = null;
            DataTable table = new DataTable();
            try
            {
                workbook = new HSSFWorkbook(ExcelFileStream);
            }
            catch
            {
                throw new Exception("exNotSupportFileType");
            }
            try
            {
                sheet = workbook.GetSheet(SheetName);
                headerRow = sheet.GetRow(HeaderRowIndex);
            }
            catch
            {
                throw new Exception("exSheetNotFound");
            }
            try
            {
                int cellCount = headerRow.LastCellNum;

                for (int i = headerRow.FirstCellNum; i < cellCount; i++)
                {
                    DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                    table.Columns.Add(column);
                }

                int rowCount = sheet.LastRowNum;

                for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
                {
                    HSSFRow row = sheet.GetRow(i);
                    DataRow dataRow = table.NewRow();

                    for (int j = row.FirstCellNum; j < cellCount; j++)
                    {
                        if (row.GetCell(j) != null)
                            dataRow[j] = row.GetCell(j).ToString();
                    }

                    table.Rows.Add(dataRow);
                }
            }
            catch
            {
                throw new Exception("exSheetCanNotAnalyze");
            }
            ExcelFileStream.Close();
            workbook = null;
            sheet = null;
            return table;
        }

        public static DataTable RenderDataTableFromExcel(Stream ExcelFileStream, int SheetIndex, int HeaderRowIndex)
        {
            HSSFWorkbook workbook = new HSSFWorkbook(ExcelFileStream);
            HSSFSheet sheet = workbook.GetSheetAt(SheetIndex);

            DataTable table = new DataTable();

            HSSFRow headerRow = sheet.GetRow(HeaderRowIndex);
            int cellCount = headerRow.LastCellNum;

            for (int i = headerRow.FirstCellNum; i < cellCount; i++)
            {
                DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                table.Columns.Add(column);
            }

            int rowCount = sheet.LastRowNum;

            for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
            {
                HSSFRow row = sheet.GetRow(i);
                DataRow dataRow = table.NewRow();

                for (int j = row.FirstCellNum; j < cellCount; j++)
                {
                    if (row.GetCell(j) != null)
                        dataRow[j] = row.GetCell(j).ToString();
                }

                table.Rows.Add(dataRow);
            }

            ExcelFileStream.Close();
            workbook = null;
            sheet = null;
            return table;
        }
    }
}
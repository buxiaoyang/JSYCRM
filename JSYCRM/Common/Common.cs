using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace JSYCRM.Common
{
    public class Common
    {
        public static string MD5(string str)
        {
            MD5 m = new MD5CryptoServiceProvider();
            byte[] s = m.ComputeHash(UnicodeEncoding.UTF8.GetBytes(str));
            return BitConverter.ToString(s);
        }

        public static string FilteSQLStr(string Str)
        {
            Str = Str.Replace("'", "");
            Str = Str.Replace("\"", "");
            Str = Str.Replace("&", "&amp");
            Str = Str.Replace("<", "&lt");
            Str = Str.Replace(">", "&gt");
            Str = Str.Replace("delete", "");
            Str = Str.Replace("update", "");
            Str = Str.Replace("insert", "");
            Str = Str.Replace("select", "");
            return Str;
        }

        public static int getPageNum(string page)
        {
            int pageNum = 1;
            try
            {
                pageNum = int.Parse(page);
            }
            catch
            {
                pageNum = 1;
            }
            if (pageNum >= 1)
            {
                pageNum = pageNum - 1;
            }
            else
            {
                pageNum = 0;
            }
            return pageNum;
        }

        public static string getImportErrorMessage(Exception ex)
        {
            if (ex.Message == "exNotSupportFileType")
            {
                return "导入失败。文件格式不支持，只支持Excel 97-2003 Workbooks (.xls) 格式。您可以下载“专有数据模版”，填入您需要导入的数据，然后再次导入。";
            }
            else if (ex.Message == "exSheetNotFound")
            {
                return "导入失败。没有发现名称为<b>导入数据</b>的Excel工作表。请确保您导入的Excel文件里面导入数据在<b>导入数据</b>工作表内。注意该表名前后不能有空格。";
            }
            else if (ex.Message == "exSheetCanNotAnalyze")
            {
                return "导入失败。Excel工作表<b>导入数据</b>内数据格式错误。请确保使用和“专有数据模版”里面一样格式。";
            }
            else
            {
                return "导入失败。发生未知错误：" + ex.Message + "<br>错误详细：" + ex.StackTrace;
            }
        }

        public static string getChineseNumber(int num)
        {
            switch (num)
            { 
                case 0:
                    return "零";
                case 1:
                    return "一";
                case 2:
                    return "二";
                case 3:
                    return "三";
                case 4:
                    return "四";
                case 5:
                    return "五";
                case 6:
                    return "六";
                case 7:
                    return "七";
                case 8:
                    return "八";
                case 9:
                    return "九";
                case 10:
                    return "十";
                default:
                    return "";
            }

        }

        public static int getWorkerStatus(string status)
        {
            switch (status)
            {
                case "在工友库":
                    return Variables.WORKER_STATUS_IN_POOL;
                case "已领取":
                    return Variables.WORKER_STATUS_ON_HOLD;
                case "已输送":
                    return Variables.WORKER_STATUS_IS_DELIVERY;
                case "已通过面试":
                    return Variables.WORKER_STATUS_PASS_INTERVIEW;
                case "已报到":
                    return Variables.WORKER_STATUS_IS_ONBOARD;
                case "已离职":
                    return Variables.WORKER_STATUS_IS_RESIGNATION;
                default:
                    return Variables.WORKER_STATUS_ERROR;
            }
        }

        public static string getWorkerStatus(int status)
        {
            switch (status)
            {
                case 1:
                    return "在工友库";
                case 2:
                    return "已领取";
                case 3:
                    return "已输送";
                case 4:
                    return "已通过面试";
                case 5:
                    return "已报到";
                case 6:
                    return "已离职";
                default:
                    return "";
            }
        }

        public static string getWorkerStatusField(int status)
        {
            switch (status)
            {
                case 3:
                    return "W_DELIVERY_DATA";
                case 4:
                    return "W_INTERVIEW_DATA";
                case 5:
                    return "W_ONBOARD_DATA";
                case 6:
                    return "W_RESIGNATION_DATA";
                default:
                    return "";
            }
        }

    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace JSYCRM.DAL
{
    /// <summary>
    /// z_user
    /// </summary>
    public class z_user
    {
        public z_user()
        { }
        #region

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from z_user");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public Guid GetID(string LAST_NAME)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select ID from dbo.z_user ");
            strSql.Append(" where LAST_NAME = @LAST_NAME ");
            SqlParameter[] parameters = {
					                        new SqlParameter("@LAST_NAME", SqlDbType.NVarChar,50)
                                        };
            parameters[0].Value = LAST_NAME;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return new Guid(ds.Tables[0].Rows[0]["ID"].ToString());
            }
            else
            {
                return Guid.Empty;
            }
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(JSYCRM.Models.z_user model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into z_user(");
            strSql.Append("ID,USER_CD,PASSWORD,FIRST_NAME,LAST_NAME,GENDER,EMAIL,COMPANY_TEL,COMPANY_ID,MOBILE_NUM,POSITION_ID,DESCRIPTION,CREATE_DATETIME,UPDATE_DATETIME,DELETE_FLG)");
            strSql.Append(" values (");
            strSql.Append("@ID,@USER_CD,@PASSWORD,@FIRST_NAME,@LAST_NAME,@GENDER,@EMAIL,@COMPANY_TEL,@COMPANY_ID,@MOBILE_NUM,@POSITION_ID,@DESCRIPTION,@CREATE_DATETIME,@UPDATE_DATETIME,@DELETE_FLG)");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@USER_CD", SqlDbType.NVarChar,50),
					new SqlParameter("@PASSWORD", SqlDbType.NVarChar,50),
					new SqlParameter("@FIRST_NAME", SqlDbType.NVarChar,50),
					new SqlParameter("@LAST_NAME", SqlDbType.NVarChar,50),
					new SqlParameter("@GENDER", SqlDbType.NVarChar,50),
					new SqlParameter("@EMAIL", SqlDbType.NVarChar,250),
					new SqlParameter("@COMPANY_TEL", SqlDbType.NVarChar,50),
					new SqlParameter("@COMPANY_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@MOBILE_NUM", SqlDbType.NVarChar,50),
					new SqlParameter("@POSITION_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@DESCRIPTION", SqlDbType.NVarChar,500),
					new SqlParameter("@CREATE_DATETIME", SqlDbType.DateTime),
					new SqlParameter("@UPDATE_DATETIME", SqlDbType.DateTime),
					new SqlParameter("@DELETE_FLG", SqlDbType.Char,1)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.USER_CD;
            parameters[2].Value = model.PASSWORD;
            parameters[3].Value = model.FIRST_NAME;
            parameters[4].Value = model.LAST_NAME;
            parameters[5].Value = model.GENDER;
            parameters[6].Value = model.EMAIL;
            parameters[7].Value = model.COMPANY_TEL;
            parameters[8].Value = model.COMPANY_ID;
            parameters[9].Value = model.MOBILE_NUM;
            parameters[10].Value = model.POSITION_ID;
            parameters[11].Value = model.DESCRIPTION;
            parameters[12].Value = model.CREATE_DATETIME;
            parameters[13].Value = model.UPDATE_DATETIME;
            parameters[14].Value = model.DELETE_FLG;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(JSYCRM.Models.z_user model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update z_user set ");
            strSql.Append("USER_CD=@USER_CD,");
            strSql.Append("PASSWORD=@PASSWORD,");
            strSql.Append("FIRST_NAME=@FIRST_NAME,");
            strSql.Append("LAST_NAME=@LAST_NAME,");
            strSql.Append("GENDER=@GENDER,");
            strSql.Append("EMAIL=@EMAIL,");
            strSql.Append("COMPANY_TEL=@COMPANY_TEL,");
            strSql.Append("COMPANY_ID=@COMPANY_ID,");
            strSql.Append("MOBILE_NUM=@MOBILE_NUM,");
            strSql.Append("POSITION_ID=@POSITION_ID,");
            strSql.Append("DESCRIPTION=@DESCRIPTION,");
            strSql.Append("CREATE_DATETIME=@CREATE_DATETIME,");
            strSql.Append("UPDATE_DATETIME=@UPDATE_DATETIME,");
            strSql.Append("DELETE_FLG=@DELETE_FLG");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@USER_CD", SqlDbType.NVarChar,50),
					new SqlParameter("@PASSWORD", SqlDbType.NVarChar,50),
					new SqlParameter("@FIRST_NAME", SqlDbType.NVarChar,50),
					new SqlParameter("@LAST_NAME", SqlDbType.NVarChar,50),
					new SqlParameter("@GENDER", SqlDbType.NVarChar,50),
					new SqlParameter("@EMAIL", SqlDbType.NVarChar,250),
					new SqlParameter("@COMPANY_TEL", SqlDbType.NVarChar,50),
					new SqlParameter("@COMPANY_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@MOBILE_NUM", SqlDbType.NVarChar,50),
					new SqlParameter("@POSITION_ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@DESCRIPTION", SqlDbType.NVarChar,500),
					new SqlParameter("@CREATE_DATETIME", SqlDbType.DateTime),
					new SqlParameter("@UPDATE_DATETIME", SqlDbType.DateTime),
					new SqlParameter("@DELETE_FLG", SqlDbType.Char,1),
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.USER_CD;
            parameters[1].Value = model.PASSWORD;
            parameters[2].Value = model.FIRST_NAME;
            parameters[3].Value = model.LAST_NAME;
            parameters[4].Value = model.GENDER;
            parameters[5].Value = model.EMAIL;
            parameters[6].Value = model.COMPANY_TEL;
            parameters[7].Value = model.COMPANY_ID;
            parameters[8].Value = model.MOBILE_NUM;
            parameters[9].Value = model.POSITION_ID;
            parameters[10].Value = model.DESCRIPTION;
            parameters[11].Value = model.CREATE_DATETIME;
            parameters[12].Value = model.UPDATE_DATETIME;
            parameters[13].Value = model.DELETE_FLG;
            parameters[14].Value = model.ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from z_user ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from z_user ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public Models.z_user GetLoginModel(String userName, String password)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,USER_CD,PASSWORD,FIRST_NAME,LAST_NAME,GENDER,EMAIL,COMPANY_TEL,COMPANY_ID,MOBILE_NUM,POSITION_ID,DESCRIPTION,CREATE_DATETIME,UPDATE_DATETIME,DELETE_FLG from z_user ");
            strSql.Append(" where USER_CD=@USER_CD ");
            strSql.Append(" and PASSWORD=@PASSWORD and DELETE_FLG <> 1");
            SqlParameter[] parameters = {
				new SqlParameter("@USER_CD", SqlDbType.NVarChar),
                new SqlParameter("@PASSWORD", SqlDbType.NVarChar)
            };
            parameters[0].Value = userName;
            parameters[1].Value = password;

            JSYCRM.Models.z_user model = new JSYCRM.Models.z_user();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public JSYCRM.Models.z_user DataRowToModel(DataRow row)
        {
            JSYCRM.Models.z_user model = new JSYCRM.Models.z_user();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = new Guid(row["ID"].ToString());
                }
                if (row["USER_CD"] != null)
                {
                    model.USER_CD = row["USER_CD"].ToString();
                }
                if (row["PASSWORD"] != null)
                {
                    model.PASSWORD = row["PASSWORD"].ToString();
                }
                if (row["FIRST_NAME"] != null)
                {
                    model.FIRST_NAME = row["FIRST_NAME"].ToString();
                }
                if (row["LAST_NAME"] != null)
                {
                    model.LAST_NAME = row["LAST_NAME"].ToString();
                }
                if (row["GENDER"] != null)
                {
                    model.GENDER = row["GENDER"].ToString();
                }
                if (row["EMAIL"] != null)
                {
                    model.EMAIL = row["EMAIL"].ToString();
                }
                if (row["COMPANY_TEL"] != null)
                {
                    model.COMPANY_TEL = row["COMPANY_TEL"].ToString();
                }
                if (row["COMPANY_ID"] != null && row["COMPANY_ID"].ToString() != "")
                {
                    model.COMPANY_ID = new Guid(row["COMPANY_ID"].ToString());
                }
                if (row["MOBILE_NUM"] != null)
                {
                    model.MOBILE_NUM = row["MOBILE_NUM"].ToString();
                }
                if (row["POSITION_ID"] != null && row["POSITION_ID"].ToString() != "")
                {
                    model.POSITION_ID = new Guid(row["POSITION_ID"].ToString());
                }
                if (row["DESCRIPTION"] != null)
                {
                    model.DESCRIPTION = row["DESCRIPTION"].ToString();
                }
                if (row["CREATE_DATETIME"] != null && row["CREATE_DATETIME"].ToString() != "")
                {
                    model.CREATE_DATETIME = DateTime.Parse(row["CREATE_DATETIME"].ToString());
                }
                if (row["UPDATE_DATETIME"] != null && row["UPDATE_DATETIME"].ToString() != "")
                {
                    model.UPDATE_DATETIME = DateTime.Parse(row["UPDATE_DATETIME"].ToString());
                }
                if (row["DELETE_FLG"] != null)
                {
                    model.DELETE_FLG = row["DELETE_FLG"].ToString();
                }
                try
                {
                    if (row["POSITION"] != null)
                    {
                        model.POSITION = row["POSITION"].ToString();
                    }
                    if (row["COMPANY"] != null)
                    {
                        model.COMPANY = row["COMPANY"].ToString();
                    }
                    if (row["ROLE"] != null)
                    {
                        model.ROLE = row["ROLE"].ToString();
                    }
                }
                catch
                { 
                
                }
            }
            return model;
        }

        /// <summary>
        /// 
        /// </summary>
        public Models.z_user GetLoginModel(String USER_CD)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,USER_CD,PASSWORD,FIRST_NAME,LAST_NAME,GENDER,EMAIL,COMPANY_TEL,COMPANY_ID,MOBILE_NUM,POSITION_ID,DESCRIPTION,CREATE_DATETIME,UPDATE_DATETIME,DELETE_FLG from z_user ");
            strSql.Append(" where USER_CD=@USER_CD ");
            strSql.Append(" and DELETE_FLG <> 1");
            SqlParameter[] parameters = {
				new SqlParameter("@USER_CD", SqlDbType.NVarChar)
            };
            parameters[0].Value = USER_CD;

            JSYCRM.Models.z_user model = new JSYCRM.Models.z_user();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public JSYCRM.Models.z_user GetModel(Guid ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT top 1 TT.*, CC.VALUE as COMPANY, PP.VALUE as POSITION ");
            strSql.Append(" from z_user as TT  ");
            strSql.Append(" left join z_parameter as CC on TT.COMPANY_ID = CC.ID ");
            strSql.Append(" left join z_parameter as PP on TT.POSITION_ID = PP.ID ");
            strSql.Append(" where TT.ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = ID;

            JSYCRM.Models.z_user model = new JSYCRM.Models.z_user();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,USER_CD,PASSWORD,FIRST_NAME,LAST_NAME,GENDER,EMAIL,COMPANY_TEL,COMPANY_ID,MOBILE_NUM,POSITION_ID,DESCRIPTION,CREATE_DATETIME,UPDATE_DATETIME,DELETE_FLG ");
            strSql.Append(" FROM z_user ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by LAST_NAME ");
            return DbHelperSQL.Query(strSql.ToString());
        }


        public Boolean isCdDuplicate(string userCD)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from z_user where USER_CD = '" + userCD + "' and DELETE_FLG <> 1");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean isCdDuplicate(string userCD, string userID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from z_user ");
            strSql.Append(" where USER_CD = '" + userCD + "' and ID <> '" + userID + "' ");
            strSql.Append(" and DELETE_FLG <> 1 ");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ID,USER_CD,PASSWORD,FIRST_NAME,LAST_NAME,GENDER,EMAIL,COMPANY_TEL,COMPANY_ID,MOBILE_NUM,POSITION_ID,DESCRIPTION,CREATE_DATETIME,UPDATE_DATETIME,DELETE_FLG ");
            strSql.Append(" FROM z_user ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(String LAST_NAME)
        {
            
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM z_user ");
            if (LAST_NAME != "" && LAST_NAME != null)
            {
                strSql.Append("where LAST_NAME like '%" + LAST_NAME.Trim() + "%'");
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TT.*, CC.VALUE as COMPANY, PP.VALUE as POSITION FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from z_user T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.Append(" left join z_parameter as CC on TT.COMPANY_ID = CC.ID ");
            strSql.Append(" left join z_parameter as PP on TT.POSITION_ID = PP.ID ");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<Models.z_user> GetListModel()
        {
            List<Models.z_user> z_user_list = new List<Models.z_user>();
            DataSet ds = GetList("");
            DataTable dt = ds.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                Models.z_user model_z_user = DataRowToModel(row);
                z_user_list.Add(model_z_user);
            }
            return z_user_list;
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<Models.z_user> GetListModelByPage(string LAST_NAME, int startIndex, int endIndex)
        {
            String where = "";
            if (LAST_NAME != "" && LAST_NAME != null)
            {
                where = "LAST_NAME like '%" + LAST_NAME.Trim()+ "%'";
            }
            List<Models.z_user> z_user_list = new List<Models.z_user>();
            DataSet ds = GetListByPage(where, "LAST_NAME", startIndex, endIndex);
            DataTable dt = ds.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                Models.z_user model_z_user = DataRowToModel(row);
                z_user_list.Add(model_z_user);
            }
            return z_user_list;
        }

        #endregion
    }
}
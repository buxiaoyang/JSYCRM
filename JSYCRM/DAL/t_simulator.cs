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
    /// 数据访问类:t_simulator
    /// </summary>
    public partial class t_simulator
    {
        public t_simulator()
        { }
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Models.t_simulator model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_simulator(");
            strSql.Append("ID,IP,BROWSER,LANGUAGE,DATA,OPERATION,CREATED)");
            strSql.Append(" values (");
            strSql.Append("@ID,@IP,@BROWSER,@LANGUAGE,@DATA,@OPERATION,@CREATED)");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@IP", SqlDbType.NVarChar,50),
					new SqlParameter("@BROWSER", SqlDbType.NVarChar,50),
					new SqlParameter("@LANGUAGE", SqlDbType.NVarChar,50),
					new SqlParameter("@DATA", SqlDbType.NVarChar,-1),
					new SqlParameter("@OPERATION", SqlDbType.NVarChar,50),
					new SqlParameter("@CREATED", SqlDbType.DateTime)};
            parameters[0].Value = Guid.NewGuid();
            parameters[1].Value = model.IP;
            parameters[2].Value = model.BROWSER;
            parameters[3].Value = model.LANGUAGE;
            parameters[4].Value = model.DATA;
            parameters[5].Value = model.OPERATION;
            parameters[6].Value = model.CREATED;

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
        #endregion  BasicMethod
    }
}
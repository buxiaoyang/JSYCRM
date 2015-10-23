using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JSYCRM.Models
{
    /// <summary>
    /// t_simulator:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class t_simulator
    {
        public t_simulator()
        { }
        #region Model
        private Guid _id;
        private string _ip;
        private string _browser;
        private string _language;
        private string _data;
        private string _operation;
        private DateTime _created;
        /// <summary>
        /// 
        /// </summary>
        public Guid ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IP
        {
            set { _ip = value; }
            get { return _ip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BROWSER
        {
            set { _browser = value; }
            get { return _browser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LANGUAGE
        {
            set { _language = value; }
            get { return _language; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DATA
        {
            set { _data = value; }
            get { return _data; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OPERATION
        {
            set { _operation = value; }
            get { return _operation; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CREATED
        {
            set { _created = value; }
            get { return _created; }
        }
        #endregion Model

    }
}
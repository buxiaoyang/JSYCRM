using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JSYCRM.Models
{
    /// <summary>
    /// m_worker_history:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class m_worker_history
    {
        public m_worker_history()
        { }
        #region Model
        private Guid _id;
        private Guid _worker_id;
        private string _comments;
        private Guid _create_user_id;
        private DateTime _create_datetime;
        private Guid _update_user_id;
        private DateTime _update_datetime;
        private string _delete_flg;
        public string CREATE_USER { get; set; }
        public string UPDATE_USER { get; set; }
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
        public Guid WORKER_ID
        {
            set { _worker_id = value; }
            get { return _worker_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string COMMENTS
        {
            set { _comments = value; }
            get { return _comments; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid CREATE_USER_ID
        {
            set { _create_user_id = value; }
            get { return _create_user_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CREATE_DATETIME
        {
            set { _create_datetime = value; }
            get { return _create_datetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid UPDATE_USER_ID
        {
            set { _update_user_id = value; }
            get { return _update_user_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime UPDATE_DATETIME
        {
            set { _update_datetime = value; }
            get { return _update_datetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DELETE_FLG
        {
            set { _delete_flg = value; }
            get { return _delete_flg; }
        }
        #endregion Model

    }
}
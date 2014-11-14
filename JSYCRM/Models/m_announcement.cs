using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JSYCRM.Models
{
    /// <summary>
    /// m_announcement:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class m_announcement
    {
        public m_announcement()
        { }
        #region Model
        private Guid _id;
        private string _title;
        private string _title_color;
        private string _publish;
        private string _show_in_login;
        private string _department;
        private string _body;
        private Guid _create_user_id;
        public string CREATE_USER { get; set; }
        private DateTime _create_datetime;
        private Guid _update_user_id;
        public string UPDATE_USER { get; set; }
        private DateTime _update_datetime;
        private string _delete_flg;
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
        public string TITLE
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TITLE_COLOR
        {
            set { _title_color = value; }
            get { return _title_color; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PUBLISH
        {
            set { _publish = value; }
            get { return _publish; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SHOW_IN_LOGIN
        {
            set { _show_in_login = value; }
            get { return _show_in_login; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DEPARTMENT
        {
            set { _department = value; }
            get { return _department; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BODY
        {
            set { _body = value; }
            get { return _body; }
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
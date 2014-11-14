using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JSYCRM.Models
{
    /// <summary>
    /// z_company ()
    /// </summary>
    [Serializable]
    public class z_company
    {
        public z_company()
        { }
        #region Model
        private Guid _id;
        private string _company_name;
        private string _company_description;
        private string _po_number;
        private string _company_info;
        private Guid _create_user_id;
        private DateTime _create_datetime;
        private Guid _update_user_id;
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
        public string COMPANY_NAME
        {
            set { _company_name = value; }
            get { return _company_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string COMPANY_DESCRIPTION
        {
            set { _company_description = value; }
            get { return _company_description; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PO_NUMBER
        {
            set { _po_number = value; }
            get { return _po_number; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string COMPANY_INFO
        {
            set { _company_info = value; }
            get { return _company_info; }
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
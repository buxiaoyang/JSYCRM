using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JSYCRM.Models
{
    public class z_role
    {
        public z_role()
        { }
        #region Model
        private Guid _id;
        private string _name;
        private string _description;
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
        public string NAME
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DESCRIPTION
        {
            set { _description = value; }
            get { return _description; }
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
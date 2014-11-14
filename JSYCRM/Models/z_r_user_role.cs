using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JSYCRM.Models
{
    public class z_r_user_role
    {
        public z_r_user_role()
        { }
        #region Model
        private Guid _user_id;
        private Guid _role_id;
        /// <summary>
        /// 
        /// </summary>
        public Guid USER_ID
        {
            set { _user_id = value; }
            get { return _user_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid ROLE_ID
        {
            set { _role_id = value; }
            get { return _role_id; }
        }
        #endregion Model

    }
}
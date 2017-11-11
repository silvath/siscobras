namespace Altsoft.PDFO
{
    using System;

    public class EncryptionConfig
    {
        // Methods
        public EncryptionConfig()
        {
            this.m_IsEncrypt = false;
            this.m_OwnerPassword = null;
            this.m_UserPassword = null;
            this.m_Permissions = -4;
        }

        public EncryptionConfig(UserAccessPermissions perms)
        {
            this.m_IsEncrypt = false;
            this.m_OwnerPassword = null;
            this.m_UserPassword = null;
            this.m_Permissions = perms;
        }


        // Properties
        public bool IsEncrypt
        {
            get
            {
                return this.m_IsEncrypt;
            }
            set
            {
                this.m_IsEncrypt = value;
            }
        }

        public string OwnerPassword
        {
            get
            {
                return this.m_OwnerPassword;
            }
            set
            {
                this.m_OwnerPassword = value;
            }
        }

        public UserAccessPermissions Permissions
        {
            get
            {
                return this.m_Permissions;
            }
            set
            {
                this.m_Permissions = value;
            }
        }

        public string UserPassword
        {
            get
            {
                return this.m_UserPassword;
            }
            set
            {
                this.m_UserPassword = value;
            }
        }


        // Fields
        protected bool m_IsEncrypt;
        protected string m_OwnerPassword;
        protected UserAccessPermissions m_Permissions;
        protected string m_UserPassword;
    }
}


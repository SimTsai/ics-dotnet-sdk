using System.Configuration;
using Ics.OpenApi.Options;

namespace Ics.OpenApi.ConfigurationSection
{
    /// <summary>
    /// ICS账号配置元素
    /// </summary>
    public partial class IcsAccountConfigurationElement : ConfigurationElement
    {
        private const string UserPropertyName = "user";
        private const string PasswordPropertyName = "password";

        /// <summary>
        /// 用户名
        /// </summary>
        [ConfigurationProperty(UserPropertyName, IsRequired = true)]
        public virtual string User
        {
            get
            {
                return (string)base[UserPropertyName];
            }
            set
            {
                base[UserPropertyName] = value;
            }
        }

        /// <summary>
        /// 密码
        /// </summary>
        [ConfigurationProperty(PasswordPropertyName, IsRequired = true)]
        public virtual string Password
        {
            get
            {
                return (string)base[PasswordPropertyName];
            }
            set
            {
                base[PasswordPropertyName] = value;
            }
        }

        /// <summary>
        /// 将配置元素转换为对应Options
        /// </summary>
        /// <returns></returns>
        public virtual IcsAccountOptions ToOptions()
        {
            return new IcsAccountOptions
            {
                Password = this.Password,
                User = this.User
            };
        }

        /// <summary>
        /// 隐式转换为Options
        /// </summary>
        /// <param name="configurationElement">配置节元素</param>
        public static implicit operator IcsAccountOptions(IcsAccountConfigurationElement configurationElement)
        {
            return configurationElement.ToOptions();
        }
    }
}

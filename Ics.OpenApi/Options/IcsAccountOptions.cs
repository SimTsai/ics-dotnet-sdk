namespace Ics.OpenApi.Options
{
    /// <summary>
    /// ICS 账号 Options
    /// </summary>
    public partial class IcsAccountOptions
    {
        /// <summary>
        /// 默认Options名
        /// </summary>
        public const string DefaultOptionsName = "Ics:Account";

        /// <summary>
        /// 用户名
        /// </summary>
        public virtual string User { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public virtual string Password { get; set; }
    }
}

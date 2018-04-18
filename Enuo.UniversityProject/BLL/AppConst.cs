using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Enuo.UniversityProject.BLL
{
    public enum RoleTypes
    {
        /// <summary>
        /// 匿名用户
        /// </summary>
        Anonymous = 1,
        /// <summary>
        /// 注册用户
        /// </summary>
        RegisterUser = 2,
        /// <summary>
        /// 高级用户
        /// </summary>
        Administrator = 3,
    }
    /// <summary>
    /// 性别
    /// </summary>
    public enum SexType
    {
        FeMale = 0,
        Male = 1

    }
    /// <summary>
    /// 课程性质
    /// </summary>
    public enum CourseNature
    {
        Required,
        Optional
    }
    public static class AppConst
    {
        public const string AdminUserName = "Terrence";
        public const string AdminUserPSW = "sunjipeng";
        public const string AdminEmail = "sunji0peng@aliyun.com";
        public const string AdminPhone = "15570095167";
        public const int DefaultPageSize = 4;
        public const int DefaultPageNumber = 1;
    }
}
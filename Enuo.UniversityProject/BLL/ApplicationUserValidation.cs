using Enuo.UniversityProject.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Enuo.UniversityProject.BLL
{
    /// <summary>
    /// 标题：用户名验证
    /// 描述：自定义用户名验证
    /// 作者：孙继鹏
    /// 日期：2015-1-27
    /// </summary>
    public class ApplicationUserValidation : IIdentityValidator<ApplicationUser>
    {
        public Task<IdentityResult> ValidateAsync(ApplicationUser item)
        {
            if (item.UserName.ToLower().Contains("bad"))
            {
                return Task.FromResult(IdentityResult.Failed("UserName cannot contain bad"));
            }
            else
            {
                return Task.FromResult(IdentityResult.Success);
            }
        }
    }
    /// <summary>
    /// 标题：用户密码验证
    /// 描述：自定义用户密码验证规则
    /// 作者：孙继鹏
    /// 日期：2015-1-27
    /// </summary>
    public class ApplicationPasswordValidation : IIdentityValidator<string>
    {

        public Task<IdentityResult> ValidateAsync(string item)
        {
            if (item.ToLower().Contains("111111"))
            {
                return Task.FromResult(IdentityResult.Failed("Password Cannot contain 6 consecutive digits"));
            }
            else
            {
                return Task.FromResult(IdentityResult.Success);
            }
        }
    }
    /// <summary>
    /// 标题：用户密码哈希算法
    /// 描述：自定义用户密码的哈希算法规则
    /// 作者：孙继鹏
    /// 日期：2015-1-27
    /// </summary>
    public class ApplicationPasswordHasher : IPasswordHasher
    {

        public string HashPassword(string password)
        {
            return password + "testpranav";
        }

        public PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            if (hashedPassword == providedPassword + "testpranav")
                return PasswordVerificationResult.Success;
            else
                return PasswordVerificationResult.Failed;
        }
    }
}
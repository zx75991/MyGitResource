using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.IO;
using System.Xml;
using Wicresoft.Framework.Applications;
using Wicresoft.Framework.Authentication;
using Wicresoft.Framework.Common;
using Wicresoft.Common;
using System.Configuration;
using WebServiceSoapHeaderAuth;
using System.Web.Services.Protocols;

/// <summary>
/// AuthenticationService 的摘要说明
/// </summary>
[WebService(Namespace = "http://wsaf.OceanData.com/", Description = "统一平台身份验证服务")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
// [System.Web.Script.Services.ScriptService]
public class AuthenticationService : System.Web.Services.WebService
{
    public MySoapHeader header;
    public AuthenticationService()
    {
        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }

    [WebMethod(Description = "对UserID进行解密操作")]
    [SoapHeader("header")]
    public Guid DecryptUserID(string EncryptUserID, Guid ApplicationID)
    {
        if (!header.VerifyCredentials(header.UserName, header.Password, header.Type))
            return Guid.Empty;

        Application app = ApplicationsHelper.GetApplicationInfo(ApplicationID);

        if (app != null)
        {
            string strUserID = Util.Decrypt(EncryptUserID);

            return new Guid(strUserID);
        }
        return Guid.Empty;

    }

    [WebMethod(Description = "验证用户名帐号，通过则返回用户ID，未通过则返回Guid.Empty('00000000-0000-0000-0000-000000000000')")]
    [SoapHeader("header")]
    public Guid CheckUserPassword(string UserName, string Password)
    {
        if (!header.VerifyCredentials(header.UserName, header.Password, header.Type))
            return Guid.Empty;

        Guid result = Guid.Empty;

        try
        {
            //string SQL = string.Format(@"SELECT TOP 1 [UserID]
            //    FROM [WSAF].[dbo].[DepartmentUserView2] WHERE [UserName]='{0}'", UserName);

            //string ID = DataAccess.ExecuteSql("Wicresoft.Framework.ConnectionString", SQL).Tables[0].Rows[0][0].ToString();

            Wicresoft.Framework.Organization.User user = Wicresoft.Framework.Organization.OrganizationPublicHelper.GetUserInfo(UserName);
            //user.ID

            UserLogin userLogin = AuthenticationHelper.GetUserLogin(user.ID, AuthenticationHelper.GetDefaultDomain().ID);

            if (AuthenticationHelper.CheckUserPassword(ConfigurationManager.AppSettings["FiledName"].ToString() + @"\" + UserName, Password) == Guid.Empty)
            {
                return result;
            }
            else
            {
                return user.ID;
            }
        }
        catch (Exception ex)
        {
            return result;
        }
    }

}

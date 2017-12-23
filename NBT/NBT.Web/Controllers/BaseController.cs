using NBT.Core.Services.ApplicationServices.System;
using NBT.Infra.Services.Blog;
using NBT.Infra.Services.System;
using NBT.Web.Framework.Core;
using NBT.Web.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NBT.Web.Controllers
{
    public class BaseController : Controller
    {
        protected WebSettingsVm webSettingsVm { set; get; }
        public BaseController()
        {
            if (string.IsNullOrEmpty(WebSettings.CompanyName))
                LoadSettings();
            UpdateWebSettings();
        }

        private void UpdateWebSettings()
        {
            webSettingsVm = new WebSettingsVm();
            webSettingsVm.Address = WebSettings.Address;
            webSettingsVm.Address1 = WebSettings.Address1;
            webSettingsVm.CompanyEmail = WebSettings.CompanyEmail;
            webSettingsVm.CompanyEmail1 = WebSettings.CompanyEmail1;
            webSettingsVm.CompanyName = WebSettings.CompanyName;
            webSettingsVm.CompanyName1 = WebSettings.CompanyName1;
            webSettingsVm.EmailAdmin = WebSettings.EmailAdmin;
            webSettingsVm.EmailNoti = WebSettings.EmailNoti;
            webSettingsVm.Facebook = WebSettings.Facebook;
            webSettingsVm.Instagram = WebSettings.Instagram;
            webSettingsVm.MetaDescription = WebSettings.MetaDescription;
            webSettingsVm.MetaKeyword = WebSettings.MetaKeyword;
            webSettingsVm.MetaTitle = WebSettings.MetaTitle;
            webSettingsVm.PasswordEmail = WebSettings.PasswordEmail;
            webSettingsVm.Phone = WebSettings.Phone;
            webSettingsVm.Phone1 = WebSettings.Phone1;
            webSettingsVm.Twitter = WebSettings.Twitter;
        }

        private void LoadSettings()
        {
            var settings = ServiceFactory.Get<ISettingsService>().GetAll();
            WebSettings.Address = settings.First(x => x.Id == SettingsProvider.Address.Id).Value;
            WebSettings.Address1 = settings.First(x => x.Id == SettingsProvider.Address1.Id).Value;
            WebSettings.CompanyEmail = settings.First(x => x.Id == SettingsProvider.CompanyEmail.Id).Value;
            WebSettings.CompanyEmail1 = settings.First(x => x.Id == SettingsProvider.CompanyEmail1.Id).Value;
            WebSettings.CompanyName = settings.First(x => x.Id == SettingsProvider.CompanyName.Id).Value;
            WebSettings.CompanyName1 = settings.First(x => x.Id == SettingsProvider.CompanyName1.Id).Value;
            WebSettings.EmailAdmin = settings.First(x => x.Id == SettingsProvider.EmailAdmin.Id).Value;
            WebSettings.EmailNoti = settings.First(x => x.Id == SettingsProvider.EmailNoti.Id).Value;
            WebSettings.Facebook = settings.First(x => x.Id == SettingsProvider.Facebook.Id).Value;
            WebSettings.Instagram = settings.First(x => x.Id == SettingsProvider.Instagram.Id).Value;
            WebSettings.MetaDescription = settings.First(x => x.Id == SettingsProvider.MetaDescription.Id).Value;
            WebSettings.MetaKeyword = settings.First(x => x.Id == SettingsProvider.MetaKeyword.Id).Value;
            WebSettings.MetaTitle = settings.First(x => x.Id == SettingsProvider.MetaTitle.Id).Value;
            WebSettings.PasswordEmail = settings.First(x => x.Id == SettingsProvider.PasswordEmail.Id).Value;
            WebSettings.Phone = settings.First(x => x.Id == SettingsProvider.Phone.Id).Value;
            WebSettings.Phone1 = settings.First(x => x.Id == SettingsProvider.Phone1.Id).Value;
            WebSettings.Twitter = settings.First(x => x.Id == SettingsProvider.Twitter.Id).Value;

        }
    }
}
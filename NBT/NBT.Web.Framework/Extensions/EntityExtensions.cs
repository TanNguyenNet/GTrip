using NBT.Core.Domain.Identity;
using NBT.Web.Framework.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBT.Web.Framework.Extensions
{
    public static class EntityExtensions
    {
        public static void UpdateAppGroup(this AppGroup appGroup, AppGroupVm appGroupViewModel)
        {
            appGroup.Id = appGroupViewModel.Id;
            appGroup.Name = appGroupViewModel.Name;
        }

        public static void UpdateUser(this AppUser appUser, AppUserVm appUserVm, string action = "add")
        {
            //public string Id { set; get; }
            appUser.Id = appUserVm.Id;
            //public string UserName { set; get; }
            appUser.UserName = appUserVm.UserName;
            //public string PhoneNumber { set; get; }
            appUser.PhoneNumber = appUserVm.PhoneNumber;
            //public string Email { set; get; }
            appUser.Email = appUserVm.Email;
            //public string FullName { set; get; }
            appUser.FullName = appUserVm.FullName;
            //public string Address { set; get; }
            appUser.Address = appUserVm.Address;
            //public DateTimeOffset BirthDay { set; get; }
            appUser.BirthDay = appUserVm.BirthDay;
            //public bool Gender { set; get; }
            appUser.Gender = appUserVm.Gender;
            //public bool IsActive { set; get; }
            appUser.IsActive = appUserVm.IsActive;
            //public bool IsSystemAccount { set; get; }
            appUser.IsSystemAccount = appUserVm.IsSystemAccount;
            //public DateTimeOffset CreatedDate { set; get; }
            appUser.CreatedDate = appUserVm.CreatedDate;
            //public DateTimeOffset UpdatedDate { set; get; }
            appUser.UpdatedDate = appUserVm.UpdatedDate;
            //public string CreatedBy { set; get; }
            appUser.CreatedBy = appUserVm.CreatedBy;

        }
    }
}
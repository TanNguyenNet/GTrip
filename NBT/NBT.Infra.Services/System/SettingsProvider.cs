using NBT.Core.Domain.System;
using NBT.Core.Services.ApplicationServices.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Infra.Services.System
{
    public class SettingsProvider : ISettingsProvider
    {
        public static readonly Settings MetaTitle = new Settings { Id = 1, Name = "Meta title" };
        public static readonly Settings MetaDescription = new Settings { Id = 2, Name = "Meta description" };
        public static readonly Settings MetaKeyword = new Settings { Id = 3, Name = "Meta keywork" };
        public static readonly Settings CompanyName = new Settings { Id = 4, Name = "Tên công ty" };
        public static readonly Settings Phone = new Settings { Id = 5, Name = "Điện thoại" };
        public static readonly Settings Address = new Settings { Id = 6, Name = "Địa chỉ" };
        public static readonly Settings Email = new Settings { Id = 7, Name = "Email" };
        public static readonly Settings Facebook = new Settings { Id = 8, Name = "Facebook" };
        public static readonly Settings Twitter = new Settings { Id = 9, Name = "Twitter" };
        public static readonly Settings Instagram = new Settings { Id = 10, Name = "Instagram" };
        public IEnumerable<Settings> GetAll()
        {
            return new[]
            {
                MetaTitle,
                MetaDescription,
                MetaKeyword,
                CompanyName,
                Phone,
                Address,
                Email,
                Facebook,
                Twitter,
                Instagram
            };
        }
    }
}

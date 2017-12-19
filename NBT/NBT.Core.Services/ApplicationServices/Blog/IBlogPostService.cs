﻿using NBT.Core.Domain.Blog;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Core.Services.ApplicationServices.Blog
{
    public interface IBlogPostService:IService<BlogPost>
    {
        IPagedList<BlogPost> GetAll(int pageIndex = 1, int pageSize = 20, string filter = "",bool? isShow= null);
        BlogPost GetByAlias(string alias);
    }
}

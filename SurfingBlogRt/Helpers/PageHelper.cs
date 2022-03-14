using Microsoft.AspNetCore.Http;
using SurfingBlogRt.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SurfingBlogRt.Helpers
{
    public class PageHelper
    {
        private const int pageSize = 15;

        public static List<Announcement> GetItemsPage(List<Announcement> announcements, int page = 0)
        {
            var itemsToSkip = page * pageSize;

            return announcements
                .Skip(itemsToSkip)
                .Take(pageSize)
                .ToList();
        }

    }
}

using SurfingBlogRt.DAL;
using SurfingBlogRt.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SurfingBlogRt.Helpers
{
    public class DataGenerator
    {
        private static List<string> themes = new List<string>()
            {
                "QA",
                "Java",
                "Python",
                "Data Science",
                "Big Data",
                "C++",
                "AI",
                "BA",
                "Management",
                "SoftwareArchitect",
                "SDET",
                "Stud",
                "Frontend",
                "Backend",
            };

        private static List<string> locations = new List<string>()
            {
                "Samara",
                "Samara University",
                "Moscow",
                "Holiday Inn",
                "Lotte",
                "Strelka Hall",
                "Точка кипения",
                "14А мкр.",
                "15 мкр.",
                "429 аудитория"
            };

        private static List<string> formats = new List<string>()
            {
                "Очно",
                "Онлайн",
                "Смешанно",
            };

        public static Announcement generateAnnouncement(DataContext context)
        {     
            var types = context.AnnoucementTypes.ToList();
            var companies = context.Comnpanies.ToList();
            var r = new Random();
            var theme = getRandomTheme();
            var type = types[r.Next(0, types.Count)];
            var name = String.Join("_", theme, type);

            return new Announcement()
            {
                CompanyId = companies[r.Next(0,companies.Count)].Id,
                TypeId = type.Id,
                CreateDate = DateTime.Now,
                Description = "Test Data Test Data Test Data Test Data Test Data Test DataTest Data Test Data Test DataTest Data Test Data Test DataTest Data Test Data Test DatavvvvvvTest Data Test Data Test DataTest Data Test Data Test DatavvvTest Data Test Data Test Data",
                Name = name,
                Theme = theme,
                Location = getRandomLocation(),
                Format = getRandomFormat(),
                StartDate = DateTime.Now.AddDays(r.Next(10, 40)),
                DurationInDays = r.Next(1, 14)
            };
        }


        public static List<Announcement> generateAnnouncements(int count,DataContext context)
        {
            var announcements = new List<Announcement>();
            for(int i = 0; i < count; i++)
            {
                announcements.Add(generateAnnouncement(context));
            }
            return announcements;
        }

        public static string getRandomFormat()
        {
            return getRandom(formats);
        }

        public static string getRandomLocation()
        {
            return getRandom(locations);
        }

        public static string getRandomTheme()
        {
            return getRandom(themes);
        }

        public static string getRandom(List<string> elems)
        {
            Random r = new Random();
            return elems[r.Next(0, elems.Count)];
        }
    }
}

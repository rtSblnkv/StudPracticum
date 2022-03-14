using SurfingBlogRt.Helpers;
using SurfingBlogRt.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SurfingBlogRt.DAL
{
    public class DBInitializer
    {
        public static void Initialize(DataContext context)
        { 
            initializeRoles(context);
            initializeAnnoucementTypes(context);
            initializeSystemUsers(context);
            initializeTestAnnouncement(context);
        }

        public static void initializeSystemUsers(DataContext context)
        {
            if (!context.Users.Any())
            {
                context.Users.AddRange(new List<User>()
                {
                    new User()
                    {
                        Email = "SystemUser",
                        Nickname = "SystemUser",
                        Password = "54kk32",
                        RoleId = 2
                    },
                    new User()
                    {
                        Email = "SystemCompany",
                        Nickname = "SystemCompany",
                        Password = "54kk32",
                        RoleId = 1
                    }
                });
                context.SaveChanges();
            }
        }

        public static void initializeTestAnnouncement(DataContext context)
        {

            if (!context.Announcements.Any())
            {
                context.Announcements.Add(
                    new Announcement()
                    {
                        CompanyId = 2,
                        TypeId = 1,
                        CreateDate = DateTime.Now,
                        Description = "Test Data Test Data Test Data",
                        Name = "QA обучение Сбер",
                        Theme = "QA",
                        Location = "Samara University",
                        Format = "Очно",
                        StartDate = DateTime.Now.AddDays(40),
                        DurationInDays = 14
                    }
                ) ;
                context.SaveChanges();
            }
        }

        public static void initializeRoles(DataContext context)
        {
            if (!context.Roles.Any())
            {
                context.Roles.AddRange(new List<Role>()
                {
                    new Role()
                    {
                        RoleName = "Company"
                    },
                    new Role()
                    {
                        RoleName = "User"
                    }
                });
                context.SaveChanges();
            }
        }

        public static void initializeTestAnnouncements(DataContext context)
        {
            context.Announcements.AddRange(DataGenerator.generateAnnouncements(100, context));
            context.SaveChanges();
        }

        public static void initializeAnnoucementTypes(DataContext context)
        {
            if (!context.AnnoucementTypes.Any())
            {
                context.AnnoucementTypes.AddRange(new List<AnnoucementType>()
                {
                    new AnnoucementType()
                    {
                        TypeName = "Internship"
                    },
                    new AnnoucementType()
                    {
                        TypeName = "Practicum"
                    },
                    new AnnoucementType()
                    {
                        TypeName = "Hackaton"
                    }
                });
                context.SaveChanges();
            }
        }
    }
}

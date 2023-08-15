using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GymWeb.Context;
using System;
using System.Linq;


namespace GymWeb.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new GymContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<GymContext>>()))
        {
            // Look for any members
            if (context.Members.Any())
            {
                return;   // DB has been seeded
            }
            context.Members.AddRange(
                new Members
                {
                    Id = 0,
                    Name = string.Empty,
                    Surname = string.Empty,
                    Birthday = DateTime.Now,
                    Registration = DateTime.Now,
                    Email = string.Empty,
                    IsDeleted = string.Empty,



                }



            );
             context.SaveChanges();
        }
    }
}
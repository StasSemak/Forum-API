using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data
{
    public static class MockData
    {
        public static List<Topic> GetTopics()
        {
            return new List<Topic>()
            {
                new Topic()
                {
                    Id = 1,
                    Name = "Programming"
                },
                new Topic()
                {
                    Id = 2,
                    Name = "Computers"
                },
                new Topic()
                {
                    Id = 3,
                    Name = "Cooking"
                },
                new Topic()
                {
                    Id = 4,
                    Name = "Household appliances"
                },
                new Topic()
                {
                    Id = 5,
                    Name = "Books"
                },
                new Topic()
                {
                    Id = 6,
                    Name = "Films"
                },
                new Topic()
                {
                    Id = 7,
                    Name = "Sports"
                },
                new Topic()
                {
                    Id = 8,
                    Name = "Other"
                }
            };
        }
    }
}

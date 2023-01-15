using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace BookApp.Models.Configs
{
    public class TagModelConfigs : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            List<Tag> tags = new List<Tag>()
{
    new Tag() { TagId = 1, TagName = "Agile" },
    new Tag() { TagId = 2, TagName = "Algorithms" },
    new Tag() { TagId = 3, TagName = "Best Practices" },
    new Tag() { TagId = 4, TagName = "Career Advancement" },
    new Tag() { TagId = 5, TagName = "Clean Code" },
    new Tag() { TagId = 6, TagName = "Computer Programming" },
    new Tag() { TagId = 7, TagName = "Computer Science" },
    new Tag() { TagId = 8, TagName = "Compiler Design" },
    new Tag() { TagId = 9, TagName = "C Programming" },
    new Tag() { TagId = 10, TagName = "Data Structures" },
    new Tag() { TagId = 11, TagName = "Design Patterns" },
    new Tag() { TagId = 12, TagName = "Java" },
    new Tag() { TagId = 13, TagName = "JavaScript" },
    new Tag() { TagId = 14, TagName = "Job Preparation" },
    new Tag() { TagId = 15, TagName = "Object-Oriented Design" },
    new Tag() { TagId = 16, TagName = "Programming Language" },
    new Tag() { TagId = 17, TagName = "Programming Languages" },
    new Tag() { TagId = 18, TagName = "Project Management" },
    new Tag() { TagId = 19, TagName = "Software Construction" },
    new Tag() { TagId = 20, TagName = "Software Design" },
    new Tag() { TagId = 21, TagName = "Software Development" },
    new Tag() { TagId = 22, TagName = "Software Development Process" },
    new Tag() { TagId = 23, TagName = "Software Engineering" },
    new Tag() { TagId = 24, TagName = "Technical Interviews" },
    new Tag() { TagId = 25, TagName = "Web Development" },
};



            builder.HasData(tags);
        }
    }
}

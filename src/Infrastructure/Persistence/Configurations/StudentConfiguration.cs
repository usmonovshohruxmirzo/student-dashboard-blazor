using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManagement.Domain.Entities;

namespace StudentManagement.Infrastructure.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
  public void Configure(EntityTypeBuilder<Student> builder)
  {
    builder.ToTable("Students");
    builder.HasKey(x => x.Id);
    builder
      .Property(x => x.Name)
      .HasMaxLength(100)
      .IsRequired();
  }
}

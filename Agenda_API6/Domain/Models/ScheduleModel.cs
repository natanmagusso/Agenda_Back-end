using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agenda_API6.Domain.Models
{
    /// <summary>
    /// Template class to manage schedule data.
    /// </summary>
    public class ScheduleModel
    {
        /// <summary>
        /// Column Id.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Column Name.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Column Email.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Column CellPhone.
        /// </summary>
        public string? CellPhone { get; set; }
    }

    /// <summary>
    /// Template class for setting the table in the database.
    /// </summary>
    public class ScheduleConfiguration : IEntityTypeConfiguration<ScheduleModel>
    {
        public void Configure(EntityTypeBuilder<ScheduleModel> builder)
        {
            builder.ToTable("Schedules");
            builder.Property(Sch => Sch.Name).HasColumnType("varchar(200)").IsRequired();
            builder.Property(Sch => Sch.Email).HasColumnType("varchar(100)").IsRequired();
            builder.Property(Sch => Sch.CellPhone).HasColumnType("varchar(11)").IsRequired();
        }
    }
}
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

[Table("instructor")]
public class Instructor
{
    [Column("instructor_id")]
    [Key]
    public long InstructorId { get; set; }

    [Column("first_name")]
    public string FirstName { get; set; }

    [Column("middle_initial")]
    public char MiddleInitial { get; set; }

    [Column("last_name")]
    public string LastName { get; set; }
}
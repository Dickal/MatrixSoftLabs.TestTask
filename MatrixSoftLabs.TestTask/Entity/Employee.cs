using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MatrixSoftLabs.TestTask.Entity;

public class Employee
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
    public Guid Id { get; set; }
    public string NameFirst { get; set; }
    public string NameLast { get; set; }
    public string? Biography { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime? DateOfEmployment { get; set; }
    public int EmploymentStatus { get; set; }
    public string Title { get; set; }
    public string? ImageUrl { get; set; }
    public Guid UserId { get; set; }
    public AspNetUser AspNetUser { get; set; }
    public Guid? DepartmentId { get; set; }
    public Guid? BossId { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public Guid? ImageModelId { get; set; }
    public bool IsConsultant { get; set; }
}
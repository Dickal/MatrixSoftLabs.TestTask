using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MatrixSoftLabs.TestTask.Entity;

public class Vacancy
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
    public Guid Id { get; set; }
    public DateTime Created { get; set; }
    public string? Comment { get; set; }
    public Guid VacancyCategoryId { get; set; }
    public VacancyCategory VacancyCategory { get; set; }
    public bool Approved { get; set; }
    public DateTime? DateApproved { get; set; }
    public Guid UserApprovedId { get; set; }
    public AspNetUser UserApproved{ get; set; }
    public DateTime From { get; set; }
    public DateTime? To { get; set; }
    public Guid EmployeeId { get; set; }
    public int VacancyStatus { get; set; }
}
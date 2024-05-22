using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MatrixSoftLabs.TestTask.Entity;

public class VacancyCategory
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<Vacancy> Vacancies { get; set; }
}
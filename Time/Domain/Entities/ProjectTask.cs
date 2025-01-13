using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Time.Domain
{
    public class ProjectTask
    {
        public ProjectTask() {}
         [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public bool IsEnabled { get; private set; } = true;
        public int ProjectId { get; set; }
        public DateTime CreatedOn { get; private set; } = DateTime.UtcNow;
        private readonly List<Appointment> _appointments = new List<Appointment>();
        public IReadOnlyCollection<Appointment> Appointments => _appointments;
    }
}
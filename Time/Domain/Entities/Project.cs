using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Time.Domain
{
    public class Project
    {
         public Project() {}
         [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal TotalHours { get; set; }
        public decimal Balance { get; set; }
        public bool IsSharedGlobally { get; set; }
        public DateTime? BalanceUpdatedOn { get; private set; } = DateTime.UtcNow;
        public DateTime? ClosedOn { get; set; }
        private readonly List<ProjectTask> _tasks = new List<ProjectTask>();
        public IReadOnlyCollection<ProjectTask> Tasks => _tasks;
    }
}
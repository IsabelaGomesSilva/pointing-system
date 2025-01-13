using Time.Domain;
using Time.Domain.Interfaces;
using Time.Domain.Request;

namespace Time.Service
{
   public class ProjectService : IProjectService
    {
        private readonly Context _context;

        public ProjectService(Context context)
        {
            _context = context;
        }

        public Project GetProjectById(int id)
        {
            return _context.Projects.Find(id);
        }

        public IEnumerable<Project> GetAllProjects()
        {
            return _context.Projects.ToList();
        }

        public int CreateProject(ProjectRequest projectRequest)
        {
            Project project = new Project{
                Name = projectRequest.Name,
                Balance = projectRequest.Balance,
                ClosedOn = projectRequest.ClosedOn,
                IsSharedGlobally = projectRequest.IsSharedGlobally,
                TotalHours = projectRequest.TotalHours,
            };

            _context.Projects.Add(project);
            _context.SaveChanges();

            return project.Id;
        }

    }
}
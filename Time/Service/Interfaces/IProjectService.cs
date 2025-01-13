using Time.Domain.Request;

namespace Time.Domain.Interfaces
{
    public interface IProjectService
    {
        Project GetProjectById(int id);
        IEnumerable<Project> GetAllProjects();
        int CreateProject(ProjectRequest project);
    }
}
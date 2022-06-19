
namespace Agro.Interfaces.Base.Repositories
{
    public interface IGroupRepository<Group>
    {
        Task<IEnumerable<Group>> GetAllAsync(CancellationToken cancel = default);

        Task<Group> AddAsync(Group item, CancellationToken cancel = default);

        Task<Group> UpdateAsync(Group item, CancellationToken cancel = default);

        Task<Group> DeleteAsync(Group item, CancellationToken cancel = default);
    }
}

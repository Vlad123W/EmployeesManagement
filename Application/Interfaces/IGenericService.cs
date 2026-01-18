namespace EmployeesManagement.Application.Interfaces
{
    public interface IGenericService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> CreateAsync(T dto);
        Task<T> UpdateAsync(long id, T dto);
        Task<T> DeleteAsync(long id);
    }
}

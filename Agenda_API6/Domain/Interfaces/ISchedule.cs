using Agenda_API6.Repositories.Requests;
using Agenda_API6.Repositories.Responses;

namespace Agenda_API6.Domain.Interfaces
{
    /// <summary>
    /// Class interface for creating schedule data transaction methods.
    /// </summary>
    public interface ISchedule
    {
        /// <summary>
        /// Method GetAll.
        /// </summary>
        Task<List<ScheduleResponse>> GetAllAsync();

        /// <summary>
        /// Method Insert.
        /// </summary>
        /// <param name="request">Class request.</param>
        Task<int> InsertAsync(ScheduleRequest request);

        /// <summary>
        /// Method Update.
        /// </summary>
        /// <param name="request">Class request.</param>
        /// <param name="id">Field id.</param>
        Task UpdateAsync(ScheduleRequest request, int id);

        /// <summary>
        /// Method Delete.
        /// </summary>
        /// <param name="id">Field id.</param>
        Task DeleteAsync(int id);
    }
}
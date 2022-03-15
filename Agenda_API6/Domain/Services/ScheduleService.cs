using Agenda_API6.Domain.Interfaces;
using Agenda_API6.Domain.Models;
using Agenda_API6.Persistence;
using Agenda_API6.Repositories.Requests;
using Agenda_API6.Repositories.Responses;
using Microsoft.EntityFrameworkCore;

namespace Agenda_API6.Domain.Services
{
    public class ScheduleService : ISchedule
    {
        /// <summary>
        /// Variable declaration referring to the DataContext class.
        /// </summary>
        private readonly DataContext _dataContext;

        /// <summary>
        /// Get the instance of the DataContext class.
        /// </summary>
        public ScheduleService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        /// <summary>
        /// Method GetAll.
        /// </summary>
        public async Task<List<ScheduleResponse>> GetAllAsync()
        {
            return await _dataContext
                .Schedules
                .AsNoTracking()
                .OrderBy(Sch => Sch.Name)
                .Select(Sch => new ScheduleResponse()
                {
                    Id = Sch.Id,
                    Name = Sch.Name,
                    Email = Sch.Email,
                    CellPhone = Sch.CellPhone
                }).ToListAsync();
        }

        /// <summary>
        /// Method Insert.
        /// </summary>
        /// <param name="request">Class request.</param>
        public async Task<int> InsertAsync(ScheduleRequest request)
        {
            var insert = new ScheduleModel()
            {
                Name = request.Name.ToUpper(),
                Email = request.Email.ToLower(),
                CellPhone = request.CellPhone
            };

            _dataContext.Schedules.Add(insert);
            await _dataContext.SaveChangesAsync();
            return insert.Id;
        }

        /// <summary>
        /// Method Update.
        /// </summary>
        /// <param name="request">Class request.</param>
        /// <param name="id">Field id.</param>
        public async Task UpdateAsync(ScheduleRequest request, int id)
        {
            var update = await _dataContext.Schedules.FindAsync(id);
            update.Name = request.Name.ToUpper();
            update.Email = request.Email.ToLower();
            update.CellPhone = request.CellPhone;

            _dataContext.Schedules.Update(update);
            await _dataContext.SaveChangesAsync();
        }

        /// <summary>
        /// Method Delete.
        /// </summary>
        /// <param name="id">Field id.</param>
        public async Task DeleteAsync(int id)
        {
            var delete = await _dataContext.Schedules.FindAsync(id);
            _dataContext.Schedules.Remove(delete);
            await _dataContext.SaveChangesAsync();
        }
    }
}

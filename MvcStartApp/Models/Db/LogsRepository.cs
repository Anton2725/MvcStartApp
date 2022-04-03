using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcStartApp.Models.Db
{
    public class LogsRepository : ILogsRepository
    {
        // ссылка на контекст
        private readonly BlogContext _context;

        // Метод-конструктор для инициализации
        public LogsRepository(BlogContext context)
        {
            _context = context;
        }

        public async Task AddRequest(string url)
        {
            var request = new Request();
            request.Date = DateTime.Now;
            request.Id = Guid.NewGuid();
            request.Url = url;

            // Добавление пользователя
            var entry = _context.Entry(request);
            if (entry.State == EntityState.Detached)
                await _context.Requests.AddAsync(request);

            // Сохранение изенений
            await _context.SaveChangesAsync();
        }

        public async Task<Request[]> GetRequests()
        {
            var requests = (from r in _context.Requests orderby r.Date select r).ToArrayAsync();
            return await requests;
        }
    }
}

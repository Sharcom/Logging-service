using AL;
using DTO;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class LogDAL : ILogCollection
    {
        private readonly LogContext _context;

        public LogDAL(DbContext context)
        {
            _context = context as LogContext ?? throw new ArgumentNullException(nameof(context));
        }

        public bool CreateLog(LogDTO dto)
        {
            Log _log = new Log(dto);
            _context.Logs.Add(_log);
            return _context.SaveChanges() > 0;
        }

        public List<LogDTO> GetLogs(int page, int pageSize = 20, bool excludeHandled = false, int? maxPriority = null)
        {
            return _context.Logs                
                .OrderBy(x => x.Timestamp)
                .Where(x => !excludeHandled || x.Handled == excludeHandled)
                .Where(x => maxPriority == null || x.Priority < maxPriority)
                .Skip(pageSize * (page - 1))
                .Take(pageSize)                
                .Select(x => x.ToDTO())
                .ToList();
        }
    }
}

using DTO;

namespace AL
{
    public interface ILogCollection
    {
        public bool CreateLog(LogDTO dto);
        public List<LogDTO> GetLogs(int page, int pageSize = 20, bool excludeHandled = false, int? maxPriority = null);
    }
}
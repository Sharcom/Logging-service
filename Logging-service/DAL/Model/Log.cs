using DTO;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DAL.Model
{
    public class Log
    {
        public Log() { }
        public Log(LogDTO dto)
        {
            ID = dto.ID;
            Origin = dto.Origin;
            Timestamp = dto.Timestamp;
            Message = dto.Message;
            Priority = dto.Priority;
            Handled = dto.Handled;
        }
        // Primary key
        public int? ID { get; set; }

        // Properties
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Timestamp { get; set; }

        [Required]
        public string Origin { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public int Priority { get; set; }

        public bool Handled { get; set; }

        // External properties

        // Foreign keys

        // Navigational properties

        // Methods
        public LogDTO ToDTO()
        {
            return new LogDTO()
            {
                ID = ID,
                Timestamp = Timestamp,
                Origin = Origin,
                Message = Message,
                Priority = Priority,
                Handled = Handled
            };
        }
    }
}

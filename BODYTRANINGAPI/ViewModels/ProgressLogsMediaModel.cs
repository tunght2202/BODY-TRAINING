using BODYTRANINGAPI.Models;

namespace BODYTRANINGAPI.ViewModels
{
    public class ProgressLogsMediaModel
    {
        public int PLMId { get; set; }
        public int ProgressLogId { get; set; }
        public string MediaUrl { get; set; }
        public DateTime DateCreated { get; set; }
    }
}

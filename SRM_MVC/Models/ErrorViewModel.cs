using System;

namespace SRM_MVC.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public string Message { get; internal set; }
        public string Controller { get; internal set; }
        public string Action { get; internal set; }
    }
}

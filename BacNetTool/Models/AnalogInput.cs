using System;
using System.Collections.Generic;

namespace BacNetTool.Models
{
    public partial class AnalogInput
    {
        public int Id { get; set; }
        public string ObjectName { get; set; }
        public string PresentValue { get; set; }
        public string Description { get; set; }
        public string DeviceType { get; set; }
        public int? StatusFlags { get; set; }
        public int? EventState { get; set; }
        public int? Reliability { get; set; }
        public bool? OutOfService { get; set; }
        public int? UpdateInterval { get; set; }
        public int? Units { get; set; }
        public string MinPresValue { get; set; }
        public string Resolution { get; set; }
        public string Covincrement { get; set; }
        public int? TimeDelay { get; set; }
        public int? NotificationClass { get; set; }
        public string HighLimit { get; set; }
        public string LowLimit { get; set; }
        public string Deadband { get; set; }
        public int? LimitEnable { get; set; }
        public int? EventEnable { get; set; }
        public int? AckedTransistions { get; set; }
        public int? NotifyType { get; set; }
        public bool? EventDetectionEnable { get; set; }
        public bool? EventAlgorithmInhibit { get; set; }
        public int? TimeDelayNormal { get; set; }
        public bool? ReliabilityEvaluationInhibit { get; set; }
        public string InterfaceValue { get; set; }
        public string FaultHighLimit { get; set; }
        public string FaultLowLimit { get; set; }
        public string ProfileLocation { get; set; }
        public string ProfileName { get; set; }
    }
}

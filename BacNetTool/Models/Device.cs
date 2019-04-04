using System;
using System.Collections.Generic;

namespace BacNetTool.Models
{
    public partial class Device
    {
        public Device()
        {
            InverseObjectTypeNavigation = new HashSet<Device>();
        }

        public int Id { get; set; }
        public string ObjectName { get; set; }
        public int? ObjectType { get; set; }
        public int? SystemStatus { get; set; }
        public string VendorName { get; set; }
        public string VendorIdentifier { get; set; }
        public string ModelName { get; set; }
        public string FirmwareRevision { get; set; }
        public string ApplicationSoftwareRevision { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public int? ProtocolVersion { get; set; }
        public int? ProtocolRevision { get; set; }
        public int? ProtocolServicesSupported { get; set; }
        public int? ProtocolObjectTypesSupported { get; set; }
        public int? MaxAdpulengthAccepted { get; set; }
        public int? SegmentationSupported { get; set; }
        public int? MaxSegmentsAccepted { get; set; }
        public DateTime? LocalTime { get; set; }
        public DateTime? LocalDate { get; set; }
        public int? Utcoffset { get; set; }
        public bool? DaylightSavingsStatus { get; set; }
        public int? ApdusegmentTimeout { get; set; }
        public int? Apdutimeout { get; set; }
        public int? NumberOfApduretries { get; set; }
        public int? MaxMaster { get; set; }
        public int? MaxInfoFrames { get; set; }
        public int? DatabaseRevision { get; set; }
        public int? BackupFailureTimeout { get; set; }
        public int? BackupPreparationTime { get; set; }
        public int? RestorePreparationTime { get; set; }
        public int? BackupAndRestoreState { get; set; }
        public int? LastRestartReason { get; set; }
        public int? TimeSynchronizationInterval { get; set; }
        public bool? AlignIntervals { get; set; }
        public int? IntervalOffset { get; set; }
        public string SerialNumber { get; set; }
        public int? StatusFlags { get; set; }
        public int? EventState { get; set; }
        public int? Reliability { get; set; }
        public bool? EventDetectionEnable { get; set; }
        public int? NotificationClass { get; set; }
        public int? EventEnable { get; set; }
        public string AckedTransistions { get; set; }
        public int? NotifyType { get; set; }
        public bool? ReliabilityEvaluationInhibit { get; set; }
        public string ProfileLocation { get; set; }
        public string DeployedProfileLocation { get; set; }
        public string ProfileName { get; set; }

        public Device ObjectTypeNavigation { get; set; }
        public ICollection<Device> InverseObjectTypeNavigation { get; set; }
    }
}

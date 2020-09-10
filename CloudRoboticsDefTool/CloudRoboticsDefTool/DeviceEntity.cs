using System;

namespace CloudRoboticsDefTool
{
    public class DeviceEntity : IComparable<DeviceEntity>
    {
        public string Id { get; set; }
        public string PrimaryKey { get; set; }
        public string SecondaryKey { get; set; }
        public string ConnectionString { get; set; }
        public string ConnectionState { get; set; }
        public DateTime LastActivityTime { get; set; }
        public DateTime LastConnectionStateUpdatedTime { get; set; }
        public DateTime LastStateUpdatedTime { get; set; }
        public int MessageCount { get; set; }
        public string State { get; set; }
        public string SuspensionReason { get; set; }
        public string DevM_DeviceType { get; set; }
        public string DevM_Status { get; set; }
        public string DevM_ResourceGroupId { get; set; }
        public string DevM_Description { get; set; }
        public DateTime DevM_Registered_DateTime { get; set; }

        public int CompareTo(DeviceEntity other)
        {
            return string.Compare(this.Id, other.Id, StringComparison.OrdinalIgnoreCase);
        }

        public override string ToString()
        {
            return $"Device ID = {this.Id}, Primary Key = {this.PrimaryKey}, Secondary Key = {this.SecondaryKey}, ConnectionString = {this.ConnectionString}, ConnState = {this.ConnectionState}, ActivityTime = {this.LastActivityTime}, LastConnState = {this.LastConnectionStateUpdatedTime}, LastStateUpdatedTime = {this.LastStateUpdatedTime}, MessageCount = {this.MessageCount}, State = {this.State}, SuspensionReason = {this.SuspensionReason}, DevM_DeviceType = {this.DevM_DeviceType}, DevM_Status = {this.DevM_Status}, DevM_ResourceGroupId = {this.DevM_ResourceGroupId}, DevM_Description = {this.DevM_Description}, DevM_Registered_DateTime = {this.DevM_Registered_DateTime}" + Environment.NewLine;
        }
    }
}

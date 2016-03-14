using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;

// TODO this class should be moved to TrafficManager.Data, implement TMDataSerializationBinder.
namespace TrafficManager
{
    [Serializable]
    public partial class Configuration
    {
        public string NodeTrafficLights = ""; // TODO rework
        public string NodeCrosswalk = ""; // TODO rework
        public string LaneFlags = ""; // TODO rework

        /// <summary>
        /// Stored lane speed limits
        /// </summary>
        public List<LaneSpeedLimit> LaneSpeedLimits = new List<LaneSpeedLimit>();

        /// <summary>
        /// Stored vehicle restrictions
        /// </summary>
        public List<LaneVehicleTypes> LaneAllowedVehicleTypes = new List<LaneVehicleTypes>();

        /// <summary>
        /// Timed traffic lights
        /// </summary>
        public List<TimedTrafficLights> TimedLights = new List<TimedTrafficLights>();

        /// <summary>
        /// Segment-at-Node configurations
        /// </summary>
        public List<SegmentNodeConf> SegmentNodeConfs = new List<SegmentNodeConf>();

        public List<int[]> PrioritySegments = new List<int[]>(); // TODO rework
        public List<int[]> NodeDictionary = new List<int[]>(); // TODO rework
        public List<int[]> ManualSegments = new List<int[]>(); // TODO rework

        public List<int[]> TimedNodes = new List<int[]>(); // TODO rework
        public List<ushort[]> TimedNodeGroups = new List<ushort[]>(); // TODO rework
        public List<int[]> TimedNodeSteps = new List<int[]>(); // TODO rework
        public List<int[]> TimedNodeStepSegments = new List<int[]>(); // TODO rework
    }
}

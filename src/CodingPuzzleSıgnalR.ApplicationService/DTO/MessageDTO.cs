using CodingPuzzleSıgnalR.ApplicationContext.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace CodingPuzzleSıgnalR.ApplicationService.DTO
{
    [DataContract]
    public class MessageDTO
    {
        [DataMember]
        [Timestamp]
        public string TimeStamp { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Data { get; set; }
    }
}

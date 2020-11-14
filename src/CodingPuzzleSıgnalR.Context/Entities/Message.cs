using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CodingPuzzleSıgnalR.ApplicationContext.Entities
{
    [Table("Message", Schema = "Message")]
    public class Message: BaseEntity<string>
    {
        public virtual RefType Type { get; set; }

        [Timestamp]
        public string TimeStamp { get; set; }

        public virtual RefType Data { get; set; }

        public void Insert(RefType type, RefType data, string timeStamp, string Id)
        {
            this.TimeStamp = timeStamp;
            this.Type = type;
            this.Data = data;
            this.InsertDate = DateTime.Now;
            this.Id = Id;
        }
    }
}

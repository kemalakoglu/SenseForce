using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingPuzzleSıgnalR.ApplicationContext.Entities
{
    [Table("RefValue", Schema = "Message")]
    public class RefValue: BaseEntity<long>
    {
        public string Value { get; set; }

        public virtual RefType RefType { get; set; }

        public void InsertRefValue(string value, RefType key)
        {
            this.Value = value;
            this.RefType = key;
            this.InsertDate = DateTime.Now;
        }
    }
}
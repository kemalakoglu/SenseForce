using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingPuzzleSıgnalR.ApplicationContext.Entities
{
    [Table("RefType", Schema = "Message")]
    public class RefType:BaseEntity<long>
    {
        public string Key { get; protected set; }
        public virtual RefType Parent { get; protected set; }

        public void InsertRefType(string Key, RefType parent)
        {
            this.Key = Key;
            this.Parent = parent;
            this.InsertDate = DateTime.Now;
        }
    }
}
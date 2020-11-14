using System;
using System.ComponentModel.DataAnnotations;

namespace CodingPuzzleSıgnalR.ApplicationContext.Entities
{
    public class BaseEntity<T>
    {
        [Key]
        public T Id { get; set; }
        public DateTime InsertDate { get; protected set; }
        public DateTime UpdateDate { get; protected set; }
    }
}
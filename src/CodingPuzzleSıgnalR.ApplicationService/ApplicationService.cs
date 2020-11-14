using CodingPuzzleSıgnalR.ApplicationContext.Entities;
using CodingPuzzleSıgnalR.ApplicationService.DTO;
using CodingPuzzleSıgnalR.Context;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace CodingPuzzleSıgnalR.ApplicationService
{
    public class ApplicationService:IApplicationService
    {
        public CodingPuzzleContext Context { get; set; }

        public ApplicationService(CodingPuzzleContext context)
        {
            this.Context = context;
        }

        public bool ConsumeMessage(MessageDTO message)
        {      
            string messageName = "Message:" + message.TimeStamp;

            IsValıdMessage(message);

            if (!CheckMessage(message.Id))
            {
                throw new Exception("Repeated Meesage");
            }

            if (CheckType(messageName))
                throw new Exception("Repeated Meesage");

            if (!CheckType(message.Type))
            {
                RefType entity = new RefType();
                entity.InsertRefType(message.Type, null);

                AddRefType(entity);
            }

            RefType type = GetRefTypeParent(message.Type);

      


            RefType messageData = new RefType();
            messageData.InsertRefType(messageName, type);
            messageData = this.AddRefType(messageData);


            Message messageEntity = new Message();
            messageEntity.Insert(type, messageData, message.TimeStamp, message.Id);
            AddMessage(messageEntity);

            var jObj = JToken.Parse(message.Data);
            foreach (JProperty property in jObj.Children())
            {
                RefType key = new RefType();
                key.InsertRefType(property.Name, messageData);

                key = AddRefType(key);

                RefValue value = new RefValue();
                value.InsertRefValue(property.Value.ToString(), key);

                AddRefValue(value);
                //Console.WriteLine(property.Name);
                //Console.WriteLine(property.Value);
            }

            return true;

        }

        private bool CheckMessage(string id)
        {
            Message entity = this.Context.Message.Where(x => x.Id == id).FirstOrDefault();
            return entity == null ? true : false;
        }

        private void IsValıdMessage(MessageDTO message)
        {
            if (message==null)
            {
                throw new Exception("Message is Empty");
            }

            if (string.IsNullOrEmpty(message.Data) || string.IsNullOrEmpty(message.TimeStamp) || string.IsNullOrEmpty(message.Type) || string.IsNullOrEmpty(message.Id))
            {
                throw new Exception("Message Body is not Valid");
            }
        }

        public bool CheckType(string typeName)
        {
            RefType entity= this.Context.RefType.Where(x => x.Key == typeName).FirstOrDefault();
            return entity == null ? false : true;
        }

        public RefType AddRefType(RefType refType)
        {
            this.Context.RefType.Add(refType);
            this.Context.SaveChanges();
            return refType;
        }

        public void AddRefValue(RefValue refValue)
        {
            this.Context.RefValue.Add(refValue);
            this.Context.SaveChanges();
        }

        public RefType GetRefTypeParent(string type)
        {
            return this.Context.RefType.Where(x => x.Key == type).FirstOrDefault();
        }

        public void AddMessage(Message message)
        {
            this.Context.Message.Add(message);
            this.Context.SaveChanges();
        }
    }
}

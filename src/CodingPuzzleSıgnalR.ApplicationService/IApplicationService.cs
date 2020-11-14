using CodingPuzzleSıgnalR.ApplicationContext.Entities;
using CodingPuzzleSıgnalR.ApplicationService.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingPuzzleSıgnalR.ApplicationService
{
    public interface IApplicationService
    {
        bool ConsumeMessage(MessageDTO message);
        bool CheckType(string typeName);
        RefType AddRefType(RefType refType);
        void AddRefValue(RefValue refValue);
        void AddMessage(Message message);
        RefType GetRefTypeParent(string type);
    }
}

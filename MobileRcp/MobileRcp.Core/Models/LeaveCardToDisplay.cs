﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileRcp.Core.Models
{
    //Review: Simple, data transfer objects, that contains no logic like this one can be named [DomainObjectName]Dto (Dto-data transfer object), in this case: LeaveCardDto
    //Classes like this could be placed in Prabez.MobileRcp.Application.User.Models, should not have any methods. Can contain basic, serializable c# types like DateTime, string, int and other DTOs. Data transfer objects can not(!!) referrence domain objects
    public class LeaveCardToDisplay
    {
        public string Type { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string DaysLeft { get; set; }
        public string IsAccepted { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Application.Activities.DeleteActivity
{
    public class Command : IRequest
    {
        public Guid Id { get; set; }
    }
}

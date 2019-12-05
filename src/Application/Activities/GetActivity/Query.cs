using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Application.Activities.GetActivity
{
    public class Query : IRequest<Domain.Activity>
    {
        public  Guid Id { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Application.Activities
{
    public class Query : IRequest<List<Domain.Activity>>
    {

    }
}

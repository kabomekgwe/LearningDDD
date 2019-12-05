using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities.GetActivity
{
    public class QueryHandler : IRequestHandler<Query, Domain.Activity>
    {
        private readonly DataContext _context;

        public QueryHandler(DataContext context)
        {
            _context = context;
        }

        public  async Task<Activity> Handle(Query request, CancellationToken cancellationToken)
        {
            return await _context.Activities.FindAsync(request.Id);
        }
    }
}

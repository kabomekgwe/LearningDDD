using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities
{
    public class QueryHandler : IRequestHandler<Query, List<Domain.Activity>>
    {
        private readonly DataContext _context;

        public QueryHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
        {
            var activities = await _context.Activities.ToListAsync();

            return activities;
        }
    }
}

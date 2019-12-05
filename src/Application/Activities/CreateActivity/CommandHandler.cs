using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities.CreateActivity
{
    public class CommandHandler : IRequestHandler<Command>
    {
        private readonly DataContext _context;

        public CommandHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var activity = new Activity
            {
                Id = request.Id,
                Title = request.Title,
                Description = request.Description,
                Category = request.Venue,
                Date = request.Date,
                City = request.City,
                Venue = request.Venue
            };

            _context.Activities.Add(activity);
            var success = await _context.SaveChangesAsync() > 0;

            if (success) return  Unit.Value;

            throw new Exception("Problem saving changes");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence;

namespace Application.Activities.DeleteActivity
{
    public class CommandHandler : IRequestHandler<Command>
    {
        private readonly DataContext _context;

        public CommandHandler(DataContext  context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {

            var activity = await _context.Activities.FindAsync(request.Id); 

            if(activity == null)
                throw new Exception("Could not find activity");

            _context.Remove(activity);

            var success = await _context.SaveChangesAsync() > 0;

            if (success) return Unit.Value;

            throw new Exception("Problem deleting activity");
        }
    }
}

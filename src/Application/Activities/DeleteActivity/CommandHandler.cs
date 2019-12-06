using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
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
                throw new APIException(HttpStatusCode.NotFound, new  { activity = "Not found "});

            _context.Remove(activity);

            var success = await _context.SaveChangesAsync() > 0;

            if (success) return Unit.Value;

            throw new Exception("Problem deleting activity");
        }
    }
}

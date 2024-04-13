using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.CreateComment
{
    internal class CreateCommentHandler : IRequestHandler<CreateCommentCommand, Unit>
    {
        private readonly DevFreelaDbContext _dbContext;
        public CreateCommentHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new ProjectComment(request.Content, request.ProjectId, request.UserId);

            await _dbContext.ProjectComments.AddAsync(comment);
            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}

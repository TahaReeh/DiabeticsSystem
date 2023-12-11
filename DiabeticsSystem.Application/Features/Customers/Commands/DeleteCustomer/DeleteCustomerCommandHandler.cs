using DiabeticsSystem.Application.Contracts.Persistence;
using DiabeticsSystem.Domain.Entities;
using MediatR;

namespace DiabeticsSystem.Application.Features.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCustomerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var objToDelete = await _unitOfWork.Customer.GetAsync(x => x.Id == request.Id)
                ?? throw new Exceptions.NotFoundException(nameof(Customer), request.Id);

            await _unitOfWork.Customer.RemoveAsync(objToDelete, Save: true);
        }
    }
}

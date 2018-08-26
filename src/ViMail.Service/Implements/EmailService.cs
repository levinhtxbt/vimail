using System;
using System.Threading.Tasks;
using ViMail.Data.Entities;
using ViMail.Data.Interfaces;
using ViMail.Service.Interfaces;

namespace ViMail.Service.Implements
{
    public class EmailService : IEmailService
    {
        private readonly IRepository<Email, Guid> _emailRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EmailService(IRepository<Email, Guid> emailRepository, IUnitOfWork unitOfWork)
        {
            _emailRepository = emailRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Email> Create(Email email)
        {
            _emailRepository.Add(email);
            _unitOfWork.Commit();

            return email;
        }
    }
}
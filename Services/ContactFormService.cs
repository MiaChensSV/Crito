using Crito.Contexts;
using Crito.Models;

namespace Crito.Services
{
    public class ContactFormService
    {
        private readonly DataContext _context;

        public ContactFormService(DataContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ContactFormModel model)
        {
            _context.ContactForms.Add(
                new ContactFormEntity()
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    Email = model.Email,
                    Message = model.Message,
                    Created = DateTime.Now,
                }
            );
            await _context.SaveChangesAsync();
        }
    }
}

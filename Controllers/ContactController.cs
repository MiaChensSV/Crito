using Crito.Models;
using Crito.Services;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;

namespace Crito.Controllers
{
    public class ContactController : SurfaceController
    {
        private readonly ContactFormService _contactFormService;
        public ContactController(IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider, ContactFormService contactFormService) : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {
            _contactFormService = contactFormService;
        }

        [HttpPost]
        public IActionResult Index(ContactFormModel contactform)
        {
            if (!ModelState.IsValid)
            {
                //add invalid message
                ModelState.AddModelError("", ModelState.ValidationState.ToString());
                return CurrentUmbracoPage();
            }

            using var mail = new MailService("no-reply@crito.com", "smtp.crito.com", 587, "contactform@crito.com", "BytMig123!");
            //to sender
            mail.SendAsync(contactform.Email, "Your request was received.", "Hi, your request was received and we will come back to you as soon as possible").ConfigureAwait(false);

            //to receiver
            mail.SendAsync("yihong.chen33@gmail.com", $"{contactform.Name} sent a request", $"{contactform.Message}").ConfigureAwait(false);

            //save to db
            _contactFormService.AddAsync(contactform).ConfigureAwait(false);

            return LocalRedirect(contactform.RedirectUrl ?? "/");
        }
    }
}

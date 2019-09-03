using AutoMapper;
using Ecopetrol.Api.API.Common.Settings;
using Ecopetrol.Api.Data;
using Ecopetrol.Api.Data.Models;
using Ecopetrol.Api.Services.Contracts;
using Ecopetrol.Api.Services.Model;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Ecopetrol.Api.Services
{
    public class FAQService : IFAQService
    {
        private AppSettings _settings;
        private readonly IMapper _mapper;
        FaqDbContext _dbContext;

        public FAQService(IOptions<AppSettings> settings, IMapper mapper, FaqDbContext dbContext)
        {
            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            _settings = settings?.Value;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<FAQ> CreateAsync(FAQ faq)
        {
            if (faq == null)
                throw new ArgumentNullException(nameof(faq));

            var dbFaq = new Data.Models.Faq
            {
                Answer = faq.Answer,
                Question = faq.Question,
            };

            _dbContext.Faqs.Add(dbFaq);
            await _dbContext.SaveChangesAsync();

            return new FAQ
            {
                Answer = dbFaq.Answer,
                Question = dbFaq.Question,
                Id = dbFaq.Id
            };
        }

        public async Task<bool> UpdateAsync(FAQ faq)
        {
            if (faq == null)
                throw new ArgumentNullException(nameof(faq));

            Faq dbFaq = await _dbContext.Faqs.FindAsync(faq.Id);
            if (dbFaq == null)
                return false;

            dbFaq.Answer = faq.Answer;
            dbFaq.Question = faq.Question;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Faq dbFaq = await _dbContext.Faqs.FindAsync(id);
            if (dbFaq == null)
                return false;

            _dbContext.Faqs.Remove(dbFaq);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<FAQ> GetAsync(int id)
        {
            Faq dbFaq = await _dbContext.Faqs.FindAsync(id);
            if (dbFaq == null)
                return null;

            return new FAQ
            {
                Answer = dbFaq.Answer,
                Question = dbFaq.Question,
                Id = dbFaq.Id
            };
        }
        public async Task<IEnumerable<FAQ>> GetAllAsync()
        {
            return _dbContext.Faqs.ToArray().Select(f=> new FAQ {
                Answer = f.Answer,
                Id = f.Id,
                Question = f.Question
            }).ToArray();
        }
    }
}

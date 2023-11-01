using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PrintCalculator.ViewModels.Data.PostPrint;
using PrintCalculator.Abstract.PostPrintInterfaces;
using PrintCalculator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.Services.PostPrintServices
{
    public class PostPrintPriceServices : IPostPrintPriceServices
    {
        private readonly AppDBContext _appDBContext;
        private readonly IMapper _mapper;
        public PostPrintPriceServices(AppDBContext appDBContext, IMapper mapper)
        {
            _appDBContext = appDBContext;
            _mapper = mapper;
        }
        public async Task AddPostPrintPrice(PostPrintPrice postPrintPrice)
        {
            var newPostPrintPrice = _mapper.Map<Data.Models.PostPrint.PostPrintPrice>(postPrintPrice);

            newPostPrintPrice.PostPrintPriceGroup = null;
            newPostPrintPrice.MainPostPrintTarget = null;
            newPostPrintPrice.AdditionalPostPrintTarget = null;
            newPostPrintPrice.PaperFormat = null;
        
            await _appDBContext.AddAsync(newPostPrintPrice);
            await _appDBContext.SaveChangesAsync();
        }

        public async Task DeletePostPrintPrice(Guid id)
        {
            _appDBContext.PostPrintPrices.Remove(await _appDBContext.PostPrintPrices.FirstOrDefaultAsync(ppp => ppp.Id == id));
            await _appDBContext.SaveChangesAsync();
        }

        public async Task<PostPrintPrice> TakePostPrintPriceById(Guid id)
        {
            var postPrintPrice = _mapper.Map<PostPrintPrice>(await _appDBContext.PostPrintPrices.AsNoTracking()
                                                                             .Include(pppg => pppg.PostPrintPriceGroups)
                                                                             .Include(ppt => ppt.PostPrintTargets)
                                                                             .Include(pf => pf.PaperFormats)
                                                                             .FirstOrDefaultAsync(ppp => ppp.Id == id));

            return postPrintPrice;
        }

        public async Task<List<PostPrintPrice>> TakePostPrintPrices()
        {
            var postPrintPrices = _mapper.Map<List<PostPrintPrice>>(await _appDBContext.PostPrintPrices.AsNoTracking()
                                                                            .Include(pppg => pppg.PostPrintPriceGroups)
                                                                            .Include(ppt => ppt.PostPrintTargets)
                                                                            .Include(pf => pf.PaperFormats)
                                                                            .ToListAsync());

            return postPrintPrices;
        }

        public async Task UpdatePostPrintPrice(PostPrintPrice updatedPostPrintPrice)
        {
            var postPrintPrice = await _appDBContext.PostPrintPrices.FirstOrDefaultAsync(ppp => ppp.Id == updatedPostPrintPrice.Id);

            postPrintPrice.PostPrintPriceGroupId = updatedPostPrintPrice.PostPrintPriceGroup.VM.Id.Value;
            postPrintPrice.MainPostPrintTargetId = updatedPostPrintPrice.MainPostPrintTarget.VM.Id.Value;
            postPrintPrice.AdditionalPostPrintTargetId = updatedPostPrintPrice.AdditionalPostPrintTarget.VM.Id.Value;
            postPrintPrice.PaperFormatId = updatedPostPrintPrice.PaperFormat.VM.Id.Value;

            postPrintPrice.PostPrintPriceGroup = null;
            postPrintPrice.MainPostPrintTarget = null;
            postPrintPrice.AdditionalPostPrintTarget = null;
            postPrintPrice.PaperFormat = null;

            await _appDBContext.SaveChangesAsync();
        }
    }
}

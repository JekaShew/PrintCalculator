using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PrintCalculator.Abstract.Data.PostPrint;
using PrintCalculator.Abstract.PostPrintInterfaces;
using PrintCalculator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.Services.PostPrintServices
{
    public class PostPrintPriceGroupServices : IPostPrintPriceGroupServices
    {
        private readonly AppDBContext _appDBContext;
        private readonly IMapper _mapper;
        public PostPrintPriceGroupServices(AppDBContext appDBContext, IMapper mapper)
        {
            _appDBContext = appDBContext;
            _mapper = mapper;
        }

        public async Task AddPostPrintPriceGroup(PostPrintPriceGroup postPostPrintPriceGroup)
        {
            var newPostPrintPriceGroup = _mapper.Map<Data.Models.PostPrint.PostPrintPriceGroup>(postPostPrintPriceGroup);

            await _appDBContext.AddAsync(newPostPrintPriceGroup);
            await _appDBContext.SaveChangesAsync();

        }
        public async Task DeletePostPrintPriceGroup(Guid id)
        {
            _appDBContext.PostPrintPriceGroups.Remove(await _appDBContext.PostPrintPriceGroups.FirstOrDefaultAsync(pppg => pppg.Id == id));
            await _appDBContext.SaveChangesAsync();
        }

        public async Task<List<PostPrintPriceGroup>> TakePostPrintPriceGroups()
        {
            var postPostPrintPriceGroups = _mapper.Map<List<PostPrintPriceGroup>>(await _appDBContext.PostPrintPriceGroups.AsNoTracking().ToListAsync());

            return postPostPrintPriceGroups;
        }

        public async Task<PostPrintPriceGroup> TakePostPrintPriceGroupById(Guid id)
        {
            var postPostPrintPriceGroup = _mapper.Map<PostPrintPriceGroup>(await _appDBContext.PostPrintPriceGroups.AsNoTracking().FirstOrDefaultAsync(pppg => pppg.Id == id));

            return postPostPrintPriceGroup;
        }

        public async Task UpdatePostPrintPriceGroup(PostPrintPriceGroup updatedPostPrintPriceGroup)
        {
            var postPostPrintPriceGroup = await _appDBContext.PostPrintPriceGroups.FirstOrDefaultAsync(pppg => pppg.Id == updatedPostPrintPriceGroup.Id);

            postPostPrintPriceGroup.Id = updatedPostPrintPriceGroup.Id;
            postPostPrintPriceGroup.Title = updatedPostPrintPriceGroup.Title;

            await _appDBContext.SaveChangesAsync();
        }
    }
}

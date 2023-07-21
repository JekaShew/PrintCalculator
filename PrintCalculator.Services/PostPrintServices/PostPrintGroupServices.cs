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
    public class PostPrintGroupServices : IPostPrintGroupServices
    {
        private readonly AppDBContext _appDBContext;
        private readonly IMapper _mapper;
        public PostPrintGroupServices(AppDBContext appDBContext, IMapper mapper)
        {
            _appDBContext = appDBContext;
            _mapper = mapper;
        }

        public async Task AddPostPrintGroup(PostPrintGroup postPrintGroup)
        {
            var newPostPrintGroup = _mapper.Map<Data.Models.PostPrint.PostPrintGroup>(postPrintGroup);

            await _appDBContext.AddAsync(newPostPrintGroup);
            await _appDBContext.SaveChangesAsync();

        }
        public async Task DeletePostPrintGroup(Guid id)
        {
            _appDBContext.PostPrintGroups.Remove(await _appDBContext.PostPrintGroups.FirstOrDefaultAsync(ppg => ppg.Id == id));
            await _appDBContext.SaveChangesAsync();
        }

        public async Task<List<PostPrintGroup>> TakePostPrintGroups()
        {
            var postPrintGroups = _mapper.Map<List<PostPrintGroup>>(await _appDBContext.PostPrintGroups.AsNoTracking().ToListAsync());

            return postPrintGroups;
        }

        public async Task<PostPrintGroup> TakePostPrintGroupById(Guid id)
        {
            var postPrintGroup = _mapper.Map<PostPrintGroup>(await _appDBContext.PostPrintGroups.AsNoTracking().FirstOrDefaultAsync(ppg => ppg.Id == id));

            return postPrintGroup;
        }

        public async Task UpdatePostPrintGroup(PostPrintGroup updatedPostPrintGroup)
        {
            var postPrintGroup = await _appDBContext.PostPrintGroups.FirstOrDefaultAsync(ppg => ppg.Id == updatedPostPrintGroup.Id);

            postPrintGroup.Id = updatedPostPrintGroup.Id;
            postPrintGroup.Title = updatedPostPrintGroup.Title;

            await _appDBContext.SaveChangesAsync();
        }
    }
}

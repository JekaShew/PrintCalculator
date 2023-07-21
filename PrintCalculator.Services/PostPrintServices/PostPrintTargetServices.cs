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
    public class PostPrintTargetServices : IPostPrintTargetServices
    {
        private readonly AppDBContext _appDBContext;
        private readonly IMapper _mapper;
        public PostPrintTargetServices(AppDBContext appDBContext, IMapper mapper)
        {
            _appDBContext = appDBContext;
            _mapper = mapper;
        }

        public async Task AddPostPrintTarget(PostPrintTarget postPrintTarget)
        {
            var newPostPrintTarget = _mapper.Map<Data.Models.PostPrint.PostPrintTarget>(postPrintTarget);

            await _appDBContext.AddAsync(newPostPrintTarget);
            await _appDBContext.SaveChangesAsync();

        }
        public async Task DeletePostPrintTarget(Guid id)
        {
            _appDBContext.PostPrintTargets.Remove(await _appDBContext.PostPrintTargets.FirstOrDefaultAsync(ppt => ppt.Id == id));
            await _appDBContext.SaveChangesAsync();
        }

        public async Task<List<PostPrintTarget>> TakePostPrintTargets()
        {
            var postPrintTargets = _mapper.Map<List<PostPrintTarget>>(await _appDBContext.PostPrintTargets.AsNoTracking().ToListAsync());

            return postPrintTargets;
        }

        public async Task<PostPrintTarget> TakePostPrintTargetById(Guid id)
        {
            var postPrintTarget = _mapper.Map<PostPrintTarget>(await _appDBContext.PostPrintTargets.AsNoTracking().FirstOrDefaultAsync(ppt => ppt.Id == id));

            return postPrintTarget;
        }

        public async Task UpdatePostPrintTarget(PostPrintTarget updatedPostPrintTarget)
        {
            var postPrintTarget = await _appDBContext.PostPrintTargets.FirstOrDefaultAsync(ppt => ppt.Id == updatedPostPrintTarget.Id);

            postPrintTarget.Id = updatedPostPrintTarget.Id;
            postPrintTarget.Title = updatedPostPrintTarget.Title;

            await _appDBContext.SaveChangesAsync();
        }
    }
}

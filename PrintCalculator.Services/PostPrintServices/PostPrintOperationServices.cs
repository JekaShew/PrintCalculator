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
    public class PostPrintOperationServices : IPostPrintOperationServices
    {
        private readonly AppDBContext _appDBContext;
        private readonly IMapper _mapper;
        public PostPrintOperationServices(AppDBContext appDBContext, IMapper mapper)
        {
            _appDBContext = appDBContext;
            _mapper = mapper;
        }

        public async Task AddPostPrintOperation(PostPrintOperation postPrintOperation)
        {
            var newPostPrintOperation = _mapper.Map<Data.Models.PostPrint.PostPrintOperation>(postPrintOperation);

            newPostPrintOperation.PostPrintGroup = null;
            newPostPrintOperation.PostPrintTarget = null;
            newPostPrintOperation.Sector = null;

            await _appDBContext.AddAsync(newPostPrintOperation);
            await _appDBContext.SaveChangesAsync();

        }
        public async Task DeletePostPrintOperation(Guid id)
        {
            _appDBContext.PostPrintOperations.Remove(await _appDBContext.PostPrintOperations.FirstOrDefaultAsync(ppo => ppo.Id == id));
            await _appDBContext.SaveChangesAsync();
        }

        public async Task<List<PostPrintOperation>> TakePostPrintOperations()
        {
            var postPrintOperations = _mapper.Map<List<PostPrintOperation>>(await _appDBContext.PostPrintOperations.AsNoTracking()
                                                                                    .Include(ppg => ppg.PostPrintGroups)
                                                                                    .Include(ppt => ppt.PostPrintTargets)
                                                                                    .Include(s => s.Sectors)
                                                                                    .ToListAsync());

            return postPrintOperations;
        }

        public async Task<PostPrintOperation> TakePostPrintOperationById(Guid id)
        {
            var postPrintOperation = _mapper.Map<PostPrintOperation>(await _appDBContext.PostPrintOperations.AsNoTracking()
                                                                            .Include(ppg => ppg.PostPrintGroups)
                                                                            .Include(ppt => ppt.PostPrintTargets)
                                                                            .Include(s => s.Sectors)
                                                                            .FirstOrDefaultAsync(ppo => ppo.Id == id));

            return postPrintOperation;
        }

        public async Task UpdatePostPrintOperation(PostPrintOperation updatedPostPrintOperation)
        {
            var postPrintOperation = await _appDBContext.PostPrintOperations.FirstOrDefaultAsync(ppo => ppo.Id == updatedPostPrintOperation.Id);

            postPrintOperation.Id = updatedPostPrintOperation.Id.Value;
            postPrintOperation.Title = updatedPostPrintOperation.Title;
            postPrintOperation.MeasureUnit = updatedPostPrintOperation.MeasureUnit;
            postPrintOperation.ConsumesPaperMaterial = updatedPostPrintOperation.ConsumesPaperMaterial;
            postPrintOperation.WaitingTime = updatedPostPrintOperation.WaitingTime;
            postPrintOperation.PreparationTime = updatedPostPrintOperation.PreparationTime;
            postPrintOperation.OperationTime = updatedPostPrintOperation.OperationTime;

            postPrintOperation.PostPrintGroupId = updatedPostPrintOperation.PostPrintGroup.VM.Id.Value;
            postPrintOperation.PostPrintTargetId = updatedPostPrintOperation.PostPrintTarget.VM.Id.Value;
            postPrintOperation.SectorId = updatedPostPrintOperation.Sector.VM.Id.Value;

            postPrintOperation.PostPrintGroup = null;
            postPrintOperation.PostPrintTarget = null;
            postPrintOperation.Sector = null;

            await _appDBContext.SaveChangesAsync();
        }
    }
}

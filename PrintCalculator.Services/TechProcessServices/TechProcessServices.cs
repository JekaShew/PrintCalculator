using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PrintCalculator.ViewModels.Data.TechProcess;
using PrintCalculator.Abstract.TechProcessInterfaces;
using PrintCalculator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintCalculator.Services.TechProcessServices
{
    public class TechProcessServices : ITechProcessServices
    {
        private readonly AppDBContext _appDBContext;
        private readonly IMapper _mapper;
        public TechProcessServices(AppDBContext appDBContext, IMapper mapper)
        {
            _appDBContext = appDBContext;
            _mapper = mapper;
        }

        public async Task AddTechProcess(TechProcess techProcess)
        {
            var newTechProcess = _mapper.Map<Data.Models.TechProcess.TechProcess>(techProcess);
           
            newTechProcess.PrintType = null;
            newTechProcess.Sector = null;
            newTechProcess.Storage = null;
            newTechProcess.PaperFormat = null;
            newTechProcess.PaperSize = null;

            _appDBContext.TechProcessOptions.AddRange(techProcess.TechProcessOptions.Select(tpo => new Data.Models.TechProcess.TechProcessOption
            {
                Id = tpo.Id.Value,
                TechProcessId = techProcess.Id.Value,
                OptionId = tpo.Option.VM.Id.Value,
            }));

            await _appDBContext.AddAsync(newTechProcess);
            await _appDBContext.SaveChangesAsync();

        }
        public async Task DeleteTechProcess(Guid id)
        {
            _appDBContext.TechProcesses.Remove(await _appDBContext.TechProcesses.FirstOrDefaultAsync(tp => tp.Id == id));
            await _appDBContext.SaveChangesAsync();
        }

        public async Task<List<TechProcess>> TakeTechProcesses()
        {
            var techProcesses = _mapper.Map<List<TechProcess>>(await _appDBContext.TechProcesses.AsNoTracking()
                                                                        .Include(tpo=> tpo.TechProcessOptions)
                                                                            .ThenInclude(o=> o.Option)
                                                                        .Include(pt=> pt.PrintTypes)
                                                                        .Include(s=> s.Sectors)
                                                                        .Include(st=> st.Storages)
                                                                        .Include(pf=> pf.PaperFormats)
                                                                        .Include(pf=> pf.PaperFormats)
                                                                        .ToListAsync());

            return techProcesses;
        }

        public async Task<TechProcess> TakeTechProcessById(Guid id)
        {
            var techProcess = _mapper.Map<TechProcess>(await _appDBContext.TechProcesses.AsNoTracking()
                                                                .Include(tpo => tpo.TechProcessOptions)
                                                                    .ThenInclude(o => o.Option)
                                                                .Include(pt => pt.PrintTypes)
                                                                .Include(s => s.Sectors)
                                                                .Include(st => st.Storages)
                                                                .Include(pf => pf.PaperFormats)
                                                                .Include(pf => pf.PaperFormats)
                                                                .FirstOrDefaultAsync(tp => tp.Id == id));

            return techProcess;
        }

        public async Task UpdateTechProcess(TechProcess updatedTechProcess)
        {
            var techProcess = await _appDBContext.TechProcesses.FirstOrDefaultAsync(tp => tp.Id == updatedTechProcess.Id);

            techProcess.Id = updatedTechProcess.Id.Value;
            techProcess.Title = updatedTechProcess.Title;

            techProcess.Color = updatedTechProcess.Color;
            techProcess.Special = updatedTechProcess.Special;
            techProcess.MaxPaperWidth = updatedTechProcess.MaxPaperWidth;
            techProcess.MaxPaperHeight = updatedTechProcess.MaxPaperHeight;
            techProcess.MinPaperWidth = updatedTechProcess.MinPaperWidth;
            techProcess.MinPaperHeight = updatedTechProcess.MinPaperHeight;
            techProcess.BeforePrintTime = updatedTechProcess.BeforePrintTime;
            techProcess.StartPrintTime = updatedTechProcess.StartPrintTime;
            techProcess.OneInstancePrintTime = updatedTechProcess.OneInstancePrintTime;
            techProcess.WaitingPostPrintTime = updatedTechProcess.WaitingPostPrintTime;
            techProcess.DryingTime = updatedTechProcess.DryingTime;
            techProcess.CheckTime = updatedTechProcess.CheckTime;
            techProcess.InstallationTime = updatedTechProcess.InstallationTime;
            techProcess.CostPrice = updatedTechProcess.CostPrice;
            techProcess.MaterialMarkup = updatedTechProcess.MaterialMarkup;
            techProcess.FittingPrice = updatedTechProcess.FittingPrice;
            techProcess.FittingWithoutTurnOver = updatedTechProcess.FittingWithoutTurnOver;
            techProcess.FittingForeignerTurnOver = updatedTechProcess.FittingForeignerTurnOver;
            techProcess.FittingKombo = updatedTechProcess.FittingKombo;
            techProcess.FittingYourTurnOver = updatedTechProcess.FittingYourTurnOver;
            techProcess.FormsPrice = updatedTechProcess.FormsPrice;
            techProcess.PantonBatchPrice = updatedTechProcess.PantonBatchPrice;
            techProcess.LacquerPreparationPrice = updatedTechProcess.LacquerPreparationPrice;
            techProcess.PaperFittingFirstPrint = updatedTechProcess.PaperFittingFirstPrint;
            techProcess.PaperFittingAdditionalPaint = updatedTechProcess.PaperFittingAdditionalPaint;
            techProcess.PaperFittingPanton = updatedTechProcess.PaperFittingPanton;
            techProcess.PaperFittingFromEdition = updatedTechProcess.PaperFittingFromEdition;
            techProcess.CuttingCutPrice = updatedTechProcess.CuttingCutPrice;
            techProcess.PrintRunPrice = updatedTechProcess.PrintRunPrice;
            techProcess.PrintRunLacquerPrice = updatedTechProcess.PrintRunLacquerPrice;
            techProcess.CuttingPreparationPrice = updatedTechProcess.CuttingPreparationPrice;
            techProcess.ValveWidth = updatedTechProcess.ValveWidth;
            techProcess.PaperTrim = updatedTechProcess.PaperTrim;
            techProcess.FieldForCrosses = updatedTechProcess.FieldForCrosses;
            techProcess.DiesWidth = updatedTechProcess.DiesWidth;
            techProcess.SectionsInThePriceOfARun = updatedTechProcess.SectionsInThePriceOfARun;
            techProcess.FittingPerRunPrice = updatedTechProcess.FittingPerRunPrice;
            techProcess.MinPrintPrice = updatedTechProcess.MinPrintPrice;
            techProcess.MinPrintSheetPrice = updatedTechProcess.MinPrintSheetPrice;
            techProcess.IncreasedTireWear = updatedTechProcess.IncreasedTireWear;
            techProcess.PlatesCtPResource = updatedTechProcess.PlatesCtPResource;
            techProcess.CuttingWithACollarMarkUp = updatedTechProcess.CuttingWithACollarMarkUp;
            techProcess.CoefficientPerTurnOver = updatedTechProcess.CoefficientPerTurnOver;
            techProcess.CustomCutting = updatedTechProcess.CustomCutting;
            techProcess.FittingYourTurnOverThroughValvePrice = updatedTechProcess.FittingYourTurnOverThroughValvePrice;
            techProcess.FittingCoefficientForYourTurnOver = updatedTechProcess.FittingCoefficientForYourTurnOver;
            techProcess.Rewash = updatedTechProcess.Rewash;

            techProcess.PrintTypeId = updatedTechProcess.PrintType.VM.Id.Value;
            techProcess.SectorId = updatedTechProcess.Sector.VM.Id.Value;
            techProcess.StorageId = updatedTechProcess.Storage.VM.Id.Value;
            techProcess.PaperFormatId = updatedTechProcess.PaperFormat.VM.Id.Value;
            techProcess.PaperSizeId = updatedTechProcess.PaperSize.VM.Id.Value;

            techProcess.PrintType = null;
            techProcess.Sector = null;
            techProcess.Storage = null;
            techProcess.PaperFormat = null;
            techProcess.PaperSize = null;

            _appDBContext.TechProcessOptions.RemoveRange(techProcess.TechProcessOptions);
            var techProcessOptions = new List<Data.Models.TechProcess.TechProcessOption>();
            foreach (var techProcessOption in updatedTechProcess.TechProcessOptions)
            {
                techProcess.TechProcessOptions.Add(_mapper.Map<Data.Models.TechProcess.TechProcessOption>(techProcessOption));
            }
            _appDBContext.TechProcessOptions.AddRange(techProcessOptions);

            await _appDBContext.SaveChangesAsync();
        }
    }
}

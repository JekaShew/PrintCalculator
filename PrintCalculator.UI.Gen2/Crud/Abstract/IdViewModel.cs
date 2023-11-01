using PrintCalculator.FileStorage.Abstract;
using PrintCalculator.UI.Gen2.Crud.ViewModels;
using PrintCalculator.UI.Gen2.Data.Abstract;
using System;

namespace PrintCalculator.UI.Gen2.Crud.Abstract
{
    /// <summary>
    /// Base client model
    /// </summary>
    /// <typeparam name="TDM">Data model type</typeparam>
    public abstract class IdViewModel<TDM> where TDM : Model
    {
        /// <summary>
        /// Unique identifier
        /// Null when adding, value when editing
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// Fill data from data model
        /// </summary>
        public virtual void FromDataModel(TDM dm, UtilsServices service)
        {
            Id = dm.Id;
        }

        /// <summary>
        /// Fill data model from current view model
        /// </summary>
        public virtual void ToDataModel(TDM dm, UtilsServices service)
        {
            if (Id.HasValue)
                dm.Id = Id.Value;
        }

        /// <summary>
        /// Action after delete
        /// </summary>
        public virtual void OnDelete(TDM dm, UtilsServices service) { }

        /// <summary>
        /// Shortcut to update media property
        /// </summary>
        /// <typeparam name="TMT">Media model</typeparam>
        /// <param name="vmGet">Client model media property getter</param>
        /// <param name="dmGet">Data model media property getter</param>
        /// <param name="dmSet">Data model media property setter</param>
        /// <param name="dmSetId">Data model media id property setter</param>
        public void SetMedia<TMT>(Func<MediaValue> vmGet, Func<TMT> dmGet, Action<TMT> dmSet, Action<Guid?> dmSetId, UtilsServices service) where TMT : Model, IFileModel, new()
        {
            var media = vmGet();
            var dm = dmGet();
            
            if (media == null)
            {
                if (dm != null)
                {
                    dmSetId(null);
                    service.AppDbContext.Set<TMT>().Remove(dm);
                    service.StorageService.RemoveMedia(dm, "media").Wait();
                }
            }
            else
            {
                if (media.Update != null)
                {
                    if (dm != null)
                    {
                        dmSetId(null);
                        service.AppDbContext.Set<TMT>().Remove(dm);
                        service.StorageService.RemoveMedia(dm, "media").Wait();
                    }

                    var update = new TMT
                    {
                        Extension = "png",
                        Id = Guid.NewGuid(),
                        Type = FileType.Image
                    };

                    dmSet(update);
                    dmSetId(update.Id);
                    service.StorageService.SaveMedia(update, media.Update, "media").Wait();
                    service.AppDbContext.Set<TMT>().Add(update);
                }
            }
        }

        /// <summary>
        /// Shortcut to update media property
        /// </summary>
        /// <typeparam name="TMT">Media model</typeparam>
        /// <param name="vmMedia">Client model media property</param>
        /// <param name="dmMedia">Data model media property</param>
        /// <param name="dmSet">Data model media property setter</param>
        /// <param name="dmSetId">Data model media id property setter</param>
        public void SetMedia<TMT>(MediaValue vmMedia, TMT dmMedia, Action<TMT> dmSet, Action<Guid?> dmSetId, UtilsServices service) where TMT : Model, IFileModel, new()
            => SetMedia(() => vmMedia, () => dmMedia, dmSet, dmSetId, service);

        /// <summary>
        /// Shortcut to create media view model
        /// </summary>
        public MediaValue GetMedia(Guid? mediaId)
        {
            if (mediaId.HasValue)
                return new MediaValue
                {
                    Id = mediaId.Value,
                };
            else
                return null;
        }

        /// <summary>
        /// Shortcut to delete connected media
        /// </summary>
        public void DeleteMedia<TMT>(TMT media, UtilsServices service) where TMT : Model, IFileModel
        {
            if (media == null)
                return;
            service.AppDbContext.Set<TMT>().Remove(media);
            service.StorageService.RemoveMedia(media, "media").Wait();
        }
    }
}

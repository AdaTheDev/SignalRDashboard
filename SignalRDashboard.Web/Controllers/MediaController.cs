using System.Web.Mvc;
using SignalRDashboard.Web.Utilities;

namespace SignalRDashboard.Web.Controllers
{
    public class MediaController : Controller
    {
        private readonly IFilePathToUrlConverter _filePathConverter;
        private readonly ISoundFilePicker _soundFilePicker;

        public MediaController(IFilePathToUrlConverter filePathConverter, ISoundFilePicker soundFilePicker)
        {
            _filePathConverter = filePathConverter;
            _soundFilePicker = soundFilePicker;
        }

        [HttpGet]
        public JsonResult GetRandomErrorSound(string component)
        {
            return GetRandomSoundFile(component, SoundFileCategory.Error);
        }

        [HttpGet]
        public JsonResult GetRandomSuccessSound(string component)
        {
            return GetRandomSoundFile(component, SoundFileCategory.Success);
        }

        private JsonResult GetRandomSoundFile(string component, SoundFileCategory category)
        {
            var file = _soundFilePicker.GetRandomSoundFile(component, category);
            var relative = _filePathConverter.ToFullWebUrl(file);
            return Json(Url.Content(relative),
                JsonRequestBehavior.AllowGet);           
        }
    }
}
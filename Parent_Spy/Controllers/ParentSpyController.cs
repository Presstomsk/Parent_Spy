using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Parent_Spy.DataBase;
using Parent_Spy.DTO;
using System;
using System.Linq;
using System.Text.Json;

namespace Parent_Spy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParentSpyController : ControllerBase
    {       

        private readonly ILogger<ParentSpyController> _logger;

        public ParentSpyController(ILogger<ParentSpyController> logger)
        {
            _logger = logger;

            
        }

        [HttpPost]
        [Route("sites")]
        public string GetSites()
        {
            using (var context = new PlacesContext())
            {
                var sites = context.MozPlaces.Where(x => x.LastVisitDate !=null ).Select(x => new SiteSendDTO
                {
                    Url = x.Url,
                    Date = DateTimeOffset.FromUnixTimeSeconds((long)x.LastVisitDate/1000000).DateTime,
                    Host = x.Origin.Host
                }).ToList();

                var result = JsonSerializer.Serialize(sites);

                return result;

            }
        }

        [HttpPost]
        [Route("files")]
        public string GetFiles()
        {
            using (var context = new PlacesContext())
            {
                var files = context.MozAnnos.Where(x => x.AnnoAttributeId == 1 && x.DateAdded != null).Select(x => new FileSendDTO
                {
                    FilePath = x.Content,
                    Date = DateTimeOffset.FromUnixTimeSeconds((long)x.DateAdded / 1000000).DateTime,
                    Title = x.Place.Title,
                    Url = x.Place.Url
                }).ToList();

                var result = JsonSerializer.Serialize(files);

                return result;
            }
        }


    }
}

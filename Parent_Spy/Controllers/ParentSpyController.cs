using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Parent_Spy.DataBase;
using Parent_Spy.DTO;
using System;
using System.IO;
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

        [HttpPost, Route("sites")]       
        public ActionResult GetSites() // Получение списка сайтов
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
                var gzip = new Gzip.Gzip();
                var compressed = gzip.Compress(result);

                return Ok(compressed);

            }
        }

        [HttpPost, Route("files")]        
        public ActionResult GetFiles() //Получение списка файлов
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
                var gzip = new Gzip.Gzip();
                var compressed = gzip.Compress(result);

                return Ok(compressed);
            }
        }

        [HttpPost, Route("echo")]
        public ActionResult Echo() //Проверка работоспособности сервиса
        {
            return Ok();
        }
        [HttpGet, Route("echoGet")]
        public ActionResult EchoGet() //Проверка работоспособности сервиса
        {
            return Ok();
        }


        [HttpPost, Route("block")]
        public ActionResult BlockSite(string site) // Блокировка веб-сайта на компьютере
        {
            try
            {
                var templateDirectory = "C:\\Windows\\System32\\drivers\\etcn";
                var files = new DirectoryInfo($"{templateDirectory}").GetFiles($"hosts");

                if (files.Length == 0) return BadRequest("Файл не найден!");

                var filePath = files.First().FullName;
                StreamWriter sw = new($"{filePath}", true);

                sw.WriteLine($"127.0.0.1 {site}");
                sw.Close();

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost, Route("getFile")]
        public ActionResult GetFile(string filePath) //Закачка файла с компьютера 
        {
            try
            {
                var fileName = Path.GetFileName(filePath);
                return PhysicalFile(filePath, "application/octet-stream", fileName);
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}

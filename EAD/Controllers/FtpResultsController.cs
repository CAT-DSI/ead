using AutoMapper;
using EAD.Attributes;
using EAD.Helpers;
using EAD.Interfaces.Services;
using EAD.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Threading.Tasks;

namespace EAD.Controllers
{
    public class FtpResultsController : BaseController
    {
        public FtpResultsController(IUnitOfWork uow, IHttpContextAccessor httpContext, IMapper mapper, IStringLocalizer<NotificationsHelper> notify)
            : base(typeof(FtpResultsController), uow, httpContext, mapper, notify)
        {
        }

        /// <summary>
        /// Adding new FTP results into the database
        /// </summary>
        /// <param name="ftpResult">FTP result data</param>
        [ApiKey]
        [AllowAnonymous]
        [HttpPost("/FtpResults/Post")]
        public async Task<IActionResult> Post([FromBody] FtpResult ftpResult)
        {
            if (!ftpResult.IsValid())
            {
                return BadRequest("Invalid data or empty object");
            }

            ftpResult.Date = DateTime.Now;
            _uow.FtpResultsRepository.Add(ftpResult);
            if (await _uow.SaveChanges() <= 0)
            {
                return BadRequest($"An error has occured while trying to add new FTP restult");
            }

            return Ok($"New FTP result has been successfully added");
        }
    }
}

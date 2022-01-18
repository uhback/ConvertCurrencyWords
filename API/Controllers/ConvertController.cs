using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("api/convert")]

    public class ConvertController : ControllerBase
    {
        private readonly ILogger<ConvertController> _logger;
        public ConvertController(ILogger<ConvertController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult CurrencyWords([FromQuery] double inputNum)
        {
            try
            {
                // Validaations
                // input decimla len: 2
                // must not be negative
                var converts = new Converts();

                if (inputNum < 0)
                    throw new ArgumentException("The input number must be greater than 0.");

                // 1. Separte input number to integer and decimal part
                int[] parts = converts.SplitNumericToInteger(inputNum);
                int intPart = parts[0];
                int decPart = parts[1];

                // 2. Convert each of numbers to the words
                var wholeWords = new List<string>();
                if (intPart > 0)
                    wholeWords.Add(string.Concat(converts.ConvertNumToWords(intPart), " Dollar"));

                if (decPart > 0)
                    wholeWords.Add(string.Concat(converts.ConvertNumToWords(decPart), " Cents"));

                // 3. Returning whole words
                return Ok(string.Join(" and ", wholeWords));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
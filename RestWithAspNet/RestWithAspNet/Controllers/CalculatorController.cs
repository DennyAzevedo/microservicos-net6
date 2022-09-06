using Microsoft.AspNetCore.Mvc;

namespace RestWithAspNet.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CalculatorController : ControllerBase
	{

		private readonly ILogger<CalculatorController> _logger;

		public CalculatorController(ILogger<CalculatorController> logger)
		{
			_logger = logger;
		}

		[HttpGet("sum/{firstNumber}/{secondNumber}")]
		public IActionResult Sum(string firstNumber, string secondNumber)
		{
			if (IsNumeric(firstNumber) && IsNumeric(firstNumber))
			{
				var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
				return Ok(sum.ToString());
			}
			return BadRequest("Invalid Input");
		}

		[HttpGet("minus/{firstNumber}/{secondNumber}")]
		public IActionResult Minus(string firstNumber, string secondNumber)
		{
			if (IsNumeric(firstNumber) && IsNumeric(firstNumber))
			{
				var minus = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
				return Ok(minus.ToString());
			}
			return BadRequest("Invalid Input");
		}

		[HttpGet("div/{firstNumber}/{secondNumber}")]
		public IActionResult Div(string firstNumber, string secondNumber)
		{
			if (IsNumeric(firstNumber) && IsNumeric(firstNumber))
			{
				var div = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
				return Ok(div.ToString());
			}
			return BadRequest("Invalid Input");
		}

		[HttpGet("mult/{firstNumber}/{secondNumber}")]
		public IActionResult Mult(string firstNumber, string secondNumber)
		{
			if (IsNumeric(firstNumber) && IsNumeric(firstNumber))
			{
				var mult = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
				return Ok(mult.ToString());
			}
			return BadRequest("Invalid Input");
		}

		[HttpGet("raiz/{firstNumber}")]
		public IActionResult Raiz(string firstNumber)
		{
			if (IsNumeric(firstNumber))
			{
				var raiz = Math.Sqrt(ConvertToDouble(firstNumber));
				return Ok(raiz.ToString());
			}
			return BadRequest("Invalid Input");
		}

		private bool IsNumeric(string strNumber)
		{
			double number;
			bool isNumber = double.TryParse(
				strNumber,
				System.Globalization.NumberStyles.Any,
				System.Globalization.NumberFormatInfo.InvariantInfo,
				out number
				);
			return isNumber;

		}
		private decimal ConvertToDecimal(string strNumber)
		{
			decimal decimalValue;
			if (decimal.TryParse(strNumber, out decimalValue))
			{
				return decimalValue;
			}
			return 0;
		}

		private double ConvertToDouble(string strNumber)
		{
			double doubleValue;
			if (double.TryParse(strNumber, out doubleValue))
			{
				return doubleValue;
			}
			return 0;
		}
	}
}
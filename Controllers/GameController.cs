using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;

namespace YourProject.Controllers
{
    public class GameController : Controller
    {
        private const string SessionKeyRandomNumber = "RandomNumber";
        private const string SessionKeyGuessCount = "GuessCount";

        [HttpGet]
        [Route("GuessingGame")]
        public IActionResult GuessingGame()
        {
            // Generate a new random number and save it in the session
            var random = new Random();
            int randomNumber = random.Next(1, 101);
            HttpContext.Session.SetInt32(SessionKeyRandomNumber, randomNumber);
            HttpContext.Session.SetInt32(SessionKeyGuessCount, 0);

            ViewBag.Message = "Enter a number between 1 and 100.";
            return View();
        }

        [HttpPost]
        [Route("GuessingGame")]
        public IActionResult GuessingGame(int? guess)
        {
            if (!guess.HasValue)
            {
                ViewBag.Message = "Please enter a valid number.";
                return View();
            }

            int? randomNumber = HttpContext.Session.GetInt32(SessionKeyRandomNumber);
            int guessCount = HttpContext.Session.GetInt32(SessionKeyGuessCount) ?? 0;
            guessCount++;
            HttpContext.Session.SetInt32(SessionKeyGuessCount, guessCount);

            if (randomNumber == null)
            {
                ViewBag.Message = "Session expired. Please reload the page.";
                return View();
            }

            if (guess.Value == randomNumber)
            {
                ViewBag.Message = $"Congratulations! You guessed the correct number {randomNumber} in {guessCount} attempts.";
                HttpContext.Session.Remove(SessionKeyRandomNumber); // Clear the session
                HttpContext.Session.Remove(SessionKeyGuessCount);   // Clear the session
                return View();
            }
            else if (guess.Value < randomNumber)
            {
                ViewBag.Message = "Your guess is too low.";
            }
            else
            {
                ViewBag.Message = "Your guess is too high.";
            }

            ViewBag.GuessCount = guessCount;
            return View();
        }
    }
}

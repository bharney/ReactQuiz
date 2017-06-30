using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApplicationBasic.Controllers
{
    public enum QuestionFormat
    {
        TrueFalse,
        MultipleChoice,
        MultipleSelect
    }

    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private static List<WeatherForecast> WeatherForecastsData = new List<WeatherForecast>() {
            new WeatherForecast {ID = 91, Format = QuestionFormat.TrueFalse, AssessmentID = 0, Variation1 = "Nuget and the Xamarin Component Store are great places to find cross-platform libraries.", Variation2 = null, Variation3 = null, Answer1 = "true", Answer2 = "false", Answer3 = null, Answer4 = null, Answer5 = null, Answer6 = null, CorrectAnswers = "1", QuestionOrder = 1 },
            new WeatherForecast {ID = 92, Format = QuestionFormat.MultipleSelect, AssessmentID = 0, Variation1 = "The portions of code you can typically share if you are using native UI (iOS, Android and Windows Phone) include (select all that apply):", Variation2 = null, Variation3 = null, Answer1 = "Business Logic", Answer2 = "Data Layer", Answer3 = "User Interface", Answer4 = "Navigation Mangement", Answer5 = null, Answer6 = null, CorrectAnswers = "1,2", QuestionOrder = 2 },
            new WeatherForecast {ID = 93, Format = QuestionFormat.MultipleSelect, AssessmentID = 0, Variation1 = "Which are controls included with Xamarin.Forms (select all that apply)?", Variation2 = null, Variation3 = null, Answer1 ="Label", Answer2 = "Button", Answer3 = "Slider", Answer4 = "Entry", Answer5 = null, Answer6 = null, CorrectAnswers = "1, 2, 3, 4", QuestionOrder = 3},
            new WeatherForecast {ID = 94, Format = QuestionFormat.MultipleChoice, AssessmentID = 0, Variation1 = "To abstract the differences from the file systems on different platforms, you should:", Variation2 = null, Variation3 = null, Answer1 = "Always use the native platform - specific APIs", Answer2 = "Use Path.Combine and specific casing for all filenames and directories.", Answer3 = "No need to do anything - Xamarin handles all the differences for you.", Answer4 = "Always just use the current directory.", Answer5 = null, Answer6 = null, CorrectAnswers = "2", QuestionOrder=4},
            new WeatherForecast {ID = 95, Format = QuestionFormat.MultipleSelect, AssessmentID = 0, Variation1 = "You can use the following classes to retrieve remote data from servers through HTTP in a cross-platform fashion (select all that apply):", Variation2 = null, Variation3 = null, Answer1 = "WebRequest", Answer2 = "WebClient", Answer3 = "NSURLRequest", Answer4 = "HttpClient", Answer5 = null, Answer6 = null, CorrectAnswers = "1, 2, 4", QuestionOrder=5},
            new WeatherForecast {ID = 96, Format = QuestionFormat.TrueFalse, AssessmentID = 0, Variation1 = "Isolated storage can be used across all three dominant platforms (iOS, Android, Windows Phone).", Variation2 = null, Variation3 = null, Answer1 = "true", Answer2 = "false", Answer3 = null, Answer4 = null, Answer5 = null, Answer6 = null, CorrectAnswers = "1", QuestionOrder=6},
            new WeatherForecast {ID = 97, Format = QuestionFormat.MultipleSelect, AssessmentID = 0, Variation1 = "The portions of code you can typically share if you are using native UI (iOS, Android and Windows Phone) include (select all that apply):", Variation2 = null, Variation3 = null, Answer1 = "Business Logic", Answer2 = "Data Layer", Answer3 = "User Interface", Answer4 = "Navigation Mangement", Answer5 = null, Answer6 = null, CorrectAnswers = "1,2", QuestionOrder = 7 },
            new WeatherForecast {ID = 98, Format = QuestionFormat.MultipleSelect, AssessmentID = 0, Variation1 = "Which are controls included with Xamarin.Forms (select all that apply)?", Variation2 = null, Variation3 = null, Answer1 ="Label", Answer2 = "Button", Answer3 = "Slider", Answer4 = "Entry", Answer5 = null, Answer6 = null, CorrectAnswers = "1, 2, 3, 4", QuestionOrder = 8},
            new WeatherForecast {ID = 99, Format = QuestionFormat.MultipleChoice, AssessmentID = 0, Variation1 = "To abstract the differences from the file systems on different platforms, you should:", Variation2 = null, Variation3 = null, Answer1 = "Always use the native platform - specific APIs", Answer2 = "Use Path.Combine and specific casing for all filenames and directories.", Answer3 = "No need to do anything - Xamarin handles all the differences for you.", Answer4 = "Always just use the current directory.", Answer5 = null, Answer6 = null, CorrectAnswers = "2", QuestionOrder=9},
            new WeatherForecast {ID = 100, Format = QuestionFormat.MultipleSelect, AssessmentID = 0, Variation1 = "You can use the following classes to retrieve remote data from servers through HTTP in a cross-platform fashion (select all that apply):", Variation2 = null, Variation3 = null, Answer1 = "WebRequest", Answer2 = "WebClient", Answer3 = "NSURLRequest", Answer4 = "HttpClient", Answer5 = null, Answer6 = null, CorrectAnswers = "1, 2, 4", QuestionOrder=10},
            new WeatherForecast {ID = 101, Format = QuestionFormat.TrueFalse, AssessmentID = 0, Variation1 = "Isolated storage can be used across all three dominant platforms (iOS, Android, Windows Phone).", Variation2 = null, Variation3 = null, Answer1 = "true", Answer2 = "false", Answer3 = null, Answer4 = null, Answer5 = null, Answer6 = null, CorrectAnswers = "1", QuestionOrder=11}
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts(int startDateIndex)
        {
            var rng = new Random();
            return Enumerable.Range(1, 4).Select(index => new WeatherForecast
            {
                ID = WeatherForecastsData[index + startDateIndex].ID,
                Variation1 = WeatherForecastsData[index + startDateIndex].Variation1,
                Answer1 = WeatherForecastsData[index + startDateIndex].Answer1,
                Answer2 = WeatherForecastsData[index + startDateIndex].Answer2,
                Answer3 = WeatherForecastsData[index + startDateIndex].Answer3,
                Answer4 = WeatherForecastsData[index + startDateIndex].Answer4,
                Format = WeatherForecastsData[index + startDateIndex].Format
            });
        }

        public class WeatherForecast
        {
            public int ID { get; set; }
            public int AssessmentID { get; set; }
            public QuestionFormat Format { get; set; }
            public string Variation1 { get; set; }
            public string Variation2 { get; set; }
            public string Variation3 { get; set; }
            public string Answer1 { get; set; }
            public string Answer2 { get; set; }
            public string Answer3 { get; set; }
            public string Answer4 { get; set; }
            public string Answer5 { get; set; }
            public string Answer6 { get; set; }
            public string CorrectAnswers { get; set; }
            public int QuestionOrder { get; set; }
        }
    }
}

        // private static string[] Summaries = new[]
        // {
            // "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        // };

        // [HttpGet("[action]")]
        // public IEnumerable<WeatherForecast> WeatherForecasts(int startDateIndex)
        // {
            // var rng = new Random();
            // return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            // {
                // DateFormatted = DateTime.Now.AddDays(index + startDateIndex).ToString("d"),
                // TemperatureC = rng.Next(-20, 55),
                // Summary = Summaries[rng.Next(Summaries.Length)]
            // });
        // }

        // public class WeatherForecast
        // {
            // public string DateFormatted { get; set; }
            // public int TemperatureC { get; set; }
            // public string Summary { get; set; }

            // public int TemperatureF
            // {
                // get
                // {
                    // return 32 + (int)(TemperatureC / 0.5556);
                // }
            // }
        // }


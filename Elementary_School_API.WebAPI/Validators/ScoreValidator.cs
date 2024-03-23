using System.Globalization;
using System.Text.RegularExpressions;
using Elementary_School_API.Domain.Entities;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Elementary_School_API.WebAPI.Validators
{
	public class ScoreValidator : AbstractValidator<Score>
	{


		public ScoreValidator()
		{

			RuleFor(x => x.Quarter)
				.Custom((name, context) =>
				{
					if ((int)name <= 0 || (int)name > 4)
						context.AddFailure(new ValidationFailure("Quarter",
							"Quarter value must be between 1 and 4"));

				});

			RuleFor(x => x.Art)
				.Must(MyCustomValidator.Rule1ForDoubleScores)
				.WithMessage(MyCustomValidator.Rule1InvalidationMessage)
				.Must(MyCustomValidator.Rule2ForDoubleScores)
				.WithMessage(MyCustomValidator.Rule2InvalidationMessage);
				

			RuleFor(x => x.Language)
				.Must(MyCustomValidator.Rule1ForDoubleScores)
				.WithMessage(MyCustomValidator.Rule1InvalidationMessage)
				.Must(MyCustomValidator.Rule2ForDoubleScores)
				.WithMessage(MyCustomValidator.Rule2InvalidationMessage);


			RuleFor(x => x.Math)
				.Must(MyCustomValidator.Rule1ForDoubleScores)
				.WithMessage(MyCustomValidator.Rule1InvalidationMessage)
				.Must(MyCustomValidator.Rule2ForDoubleScores)
				.WithMessage(MyCustomValidator.Rule2InvalidationMessage);


			RuleFor(x => x.PhysicalEducation)
				.Must(MyCustomValidator.Rule1ForDoubleScores)
				.WithMessage(MyCustomValidator.Rule1InvalidationMessage)
				.Must(MyCustomValidator.Rule2ForDoubleScores)
				.WithMessage(MyCustomValidator.Rule2InvalidationMessage);


			RuleFor(x => x.Reading)
				.Must(MyCustomValidator.Rule1ForDoubleScores)
				.WithMessage(MyCustomValidator.Rule1InvalidationMessage)
				.Must(MyCustomValidator.Rule2ForDoubleScores)
				.WithMessage(MyCustomValidator.Rule2InvalidationMessage);


			RuleFor(x => x.Science)
				.Must(MyCustomValidator.Rule1ForDoubleScores)
				.WithMessage(MyCustomValidator.Rule1InvalidationMessage)
				.Must(MyCustomValidator.Rule2ForDoubleScores)
				.WithMessage(MyCustomValidator.Rule2InvalidationMessage);


			RuleFor(x => x.Spelling)
				.Must(MyCustomValidator.Rule1ForDoubleScores)
				.WithMessage(MyCustomValidator.Rule1InvalidationMessage)
				.Must(MyCustomValidator.Rule2ForDoubleScores)
				.WithMessage(MyCustomValidator.Rule2InvalidationMessage);


			RuleFor(x => x.Writing)
				.Must(MyCustomValidator.Rule1ForDoubleScores)
				.WithMessage(MyCustomValidator.Rule1InvalidationMessage)
				.Must(MyCustomValidator.Rule2ForDoubleScores)
				.WithMessage(MyCustomValidator.Rule2InvalidationMessage);


		}

		private static class MyCustomValidator
		{

			public  const string Rule1InvalidationMessage = "This field should  between 0 and 20!";

			public const string Rule2InvalidationMessage = "This field must be numeric only!";

			public static bool Rule1ForDoubleScores(double score)
			{
				return score is > 0 and <= 20;
			}

			public static bool Rule2ForDoubleScores(double score)
			{
				var inputString = score.ToString(CultureInfo.InvariantCulture);
				var rg = new Regex("^[-+]?[0-9]*\\.?[0-9]+$");

				return rg.IsMatch(inputString);

			}

		}



	}
}

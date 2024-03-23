using System.Text.RegularExpressions;
using Elementary_School_API.Domain.Entities;
using FluentValidation;
using FluentValidation.Results;

namespace Elementary_School_API.WebAPI.Validators
{
	public class StudentValidator : AbstractValidator<Student>
	{

		public StudentValidator()
		{

			RuleFor(x => x.FirstName!.Trim())
				.NotEmpty()
				.WithMessage("this field is required!")
				.MaximumLength(50)
				.WithMessage("This Field must have less than 50 characters!");
				// .Custom((name, context) =>
				// {
				// 	//check if input parameter have html tags or not:
				// 	Regex rg = new Regex("(<.*?>)");
				// 	if (rg.Matches(name!).Count > 0)
				// 	{
				//
				// 		//raise an error:
				// 		context.AddFailure(new ValidationFailure(
				// 			"FirstName",
				// 			"The parameter has invalid content"					
				// 			));
				//
				// 	}
				//
				// });

				RuleFor(x => x.FatherName!.Trim())
					
					.NotEmpty()
					.WithMessage("this field is required!")
					.MaximumLength(50)
					.WithMessage("This Field must have less than 50 characters!");

				RuleFor(x=> x.LastName!.Trim())		
					.NotEmpty()
					.WithMessage("this field is required!")
					.MaximumLength(50)
					.WithMessage("This Field must have less than 50 characters!");

				RuleFor(x => x.NationalCode!.Trim())
					.NotEmpty()
					.WithMessage("this field is required!")
					.Length(10)
					.WithMessage("This Field must have exactly 10 numbers!")
					.Custom((name, context) =>
					{
						Regex rg = new Regex("[^0-9]+");
						//check every character is numeric

						var notMatch = false;
						foreach (char c in name.Trim())
						{
							notMatch = !rg.IsMatch(c.ToString());
							
						}
						if (notMatch)
						{

							context.AddFailure(new ValidationFailure("NationalCode",
								"This field must be numeric only"
							));
						}

					});

			// foreach (var property in typeof(Student).GetProperties())
			// {
			// 		
			// 		RuleFor(x=> property.Name)
			// 		.Custom((name, context) =>
			// 		{
			// 			//check if input parameter have html tags or not:
			// 			Regex rg = new Regex("(<.*?>)");
			// 			if (rg.Matches(name!).Count > 0)
			// 			{
			// 		
			// 				//raise an error:
			// 				context.AddFailure(new ValidationFailure(
			// 					"FirstName",
			// 					"The parameter has invalid content"					
			// 					));
			// 		
			// 			}
			// 		
			// 		});
			//
			//
			//
			// }





		}

	}
}

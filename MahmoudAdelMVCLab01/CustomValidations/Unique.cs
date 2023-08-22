using MahmoudAdelMVCLab.Models;
using System.ComponentModel.DataAnnotations;

namespace MahmoudAdelMVCLab.CustomValidations;

public class Unique : ValidationAttribute {
	private readonly ITIContext context = new ITIContext();
	public int Id { get; set; }

	protected override ValidationResult? IsValid(object? value, ValidationContext validationContext) {
		string? name = value?.ToString();

		Course? foundCourse = context.Course.Where(crs => crs.Name == name).FirstOrDefault();

		if (foundCourse == null) {
			return ValidationResult.Success;
		}
		return new ValidationResult(ErrorMessage ?? "Field Already Taken!");
	}
}

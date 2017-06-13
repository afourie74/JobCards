using JobCards.Models.EntityManager;
using System;
using System.ComponentModel.DataAnnotations;

namespace JobCards.Models.Validation
{
    public class JobsPerDateAttribute : ValidationAttribute
    {
        public int NumberOfDays { get; private set; }
        public JobsPerDateAttribute(int numberOfDays)
        {
            NumberOfDays = numberOfDays;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                //if (validationContext.)
                if (value is DateTime)
                {
                    if (((DateTime)value) <= DateTime.Parse(DateTime.Now.ToShortDateString()).AddDays(1))
                    {
                        return new ValidationResult("You must select a date in the future!");
                    }

                    JobCardManager manager = new JobCardManager();
                    int numJobs = manager.GetJobsPerDate((DateTime)value);

                    if (numJobs > NumberOfDays)
                    {
                        return new ValidationResult("There are already 4 or more jobs for this date!");
                    }
                }
            }

            return ValidationResult.Success;
        }
    }
}
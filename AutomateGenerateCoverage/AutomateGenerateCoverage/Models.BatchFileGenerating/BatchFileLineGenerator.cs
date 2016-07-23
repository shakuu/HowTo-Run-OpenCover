namespace AutomateGenerateCoverage.Models.BatchFileGenerating
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutomateGenerateCoverage.Contracts;
    using AutomateGenerateCoverage.Contracts.BatchFileGenerating;
    using AutomateGenerateCoverage.Models.Abstract;
    using AutomateGenerateCoverage.Enums;

    public class BatchFileLineGenerator : ValidatorProvider, IBatchFileLineGenerator
    {
        public BatchFileLineGenerator()
        {
        }

        public BatchFileLineGenerator(IValidate validator)
            : base(validator)
        {
        }

        public string GenerateBatchFileLine(ICollection<BatchFileLineParameterType> parameters, ICollection<string> values)
        {
            if (base.Validator.CheckIfObjectIsNull(parameters))
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            if (base.Validator.CheckIfObjectIsNull(values))
            {
                throw new ArgumentNullException(nameof(values));
            }

            if (values.Any(str=> base.Validator.CheckIfStringIsNullOrEmpty(str)))
            {
                throw new ArgumentNullException(nameof(values));
            }

            if (parameters.Count != values.Count)
            {
                throw new ArgumentException($"parameters: {parameters.Count}, values: {values.Count}");

            }

            throw new NotImplementedException();
        }
    }
}

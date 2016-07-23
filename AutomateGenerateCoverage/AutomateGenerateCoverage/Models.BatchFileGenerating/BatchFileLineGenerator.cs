namespace AutomateGenerateCoverage.Models.BatchFileGenerating
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using AutomateGenerateCoverage.Contracts;
    using AutomateGenerateCoverage.Contracts.BatchFileGenerating;
    using AutomateGenerateCoverage.Models.Abstract;
    using AutomateGenerateCoverage.Enums;

    public class BatchFileLineGenerator : ValidatorProvider, IBatchFileLineGenerator
    {
        private ITypeTranslator batchFileLineParameterTypeTranslator;

        public BatchFileLineGenerator(ITypeTranslator batchFileLineParameterTypeTranslator)
        {
            this.BatchFileLineParameterTypeTranslator = batchFileLineParameterTypeTranslator;
        }

        public BatchFileLineGenerator(ITypeTranslator batchFileLineParameterTypeTranslator, IValidate validator)
            : base(validator)
        {
            this.BatchFileLineParameterTypeTranslator = batchFileLineParameterTypeTranslator;
        }

        private ITypeTranslator BatchFileLineParameterTypeTranslator
        {
            get
            {
                return this.batchFileLineParameterTypeTranslator;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("BatchParameterTranslator");
                }

                this.batchFileLineParameterTypeTranslator = value;
            }
        }

        public string GenerateBatchFileLine(IList<BatchFileLineParameterType> parameters, IList<string> values)
        {
            var batchFileLineOutputWords = new List<string>();

            this.ValidateInputParameters(parameters, values);

            for (int i = 0; i < parameters.Count; i++)
            {
                var currentParameter = this.batchFileLineParameterTypeTranslator.GetTranslatedValue((int)parameters[i]);

                var wordToAdd = currentParameter + values[i];

                batchFileLineOutputWords.Add(wordToAdd);
            }

            return string.Join(" ", batchFileLineOutputWords);
        }

        private void ValidateInputParameters(ICollection<BatchFileLineParameterType> parameters, ICollection<string> values)
        {
            if (base.Validator.CheckIfObjectIsNull(parameters))
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            if (base.Validator.CheckIfObjectIsNull(values))
            {
                throw new ArgumentNullException(nameof(values));
            }

            if (values.Any(str => base.Validator.CheckIfStringIsNullOrEmpty(str)))
            {
                throw new ArgumentNullException(nameof(values));
            }

            if (parameters.Count != values.Count)
            {
                throw new ArgumentException($"parameters: {parameters.Count}, values: {values.Count}");

            }
        }
    }
}

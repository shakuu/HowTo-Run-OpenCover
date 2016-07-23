namespace AutomateGenerateCoverage.Models.Abstract
{
    using System;

    using AutomateGenerateCoverage.Contracts;
    using AutomateGenerateCoverage.Utils;

    public abstract class ValidatorProvider
    {
        private IValidate validator;

        public ValidatorProvider()
        {

        }

        public ValidatorProvider(IValidate validator)
        {
            this.Validator = validator;
        }

        /// <summary>
        /// Initialize default validator if none is passed.
        /// </summary>
        protected IValidate Validator
        {
            get
            {
                if (this.validator == null)
                {
                    this.validator = new Validator();
                }

                return this.validator;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                this.validator = value;
            }
        }
    }
}

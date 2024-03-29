using System;

using R5T.T0132;


namespace R5T.F0002
{
	[FunctionalityMarker]
	public partial interface IEnumerationHelper : IFunctionalityMarker
	{
        /// <summary>
        /// Produces an exception for the situation where a value of the <typeparamref name="TEnum"/> enumeration was unexpected.
        /// This is useful in producing an error in the default case for switch statements based on enumeration values.
        /// </summary>
        public UnexpectedEnumerationValueException<TEnum> UnexpectedEnumerationValueException<TEnum>(TEnum unexpectedValue)
            where TEnum : Enum
        {
            var unexpectedEnumerationValueException = new UnexpectedEnumerationValueException<TEnum>(unexpectedValue);
            return unexpectedEnumerationValueException;
        }

        /// <summary>
        /// Gets a message indicating the the input value of the <typeparamref name="TEnum"/> enumeration was unexpected.
        /// This is useful in producing an error in the default case for switch statements based on enumeration values.
        /// </summary>
        /// <remarks>
        /// See: https://stackoverflow.com/questions/13645149/what-is-the-correct-exception-to-throw-for-unhandled-enum-values
        /// </remarks>
        public string UnexpectedEnumerationValueMessage<TEnum>(TEnum unexpectedValue)
            where TEnum : Enum
        {
            var output = $@"Unexpected enumeration value: '{unexpectedValue}' for enumeration type {typeof(TEnum).FullName}";
            return output;
        }

        public TEnum GetValue<TEnum>(string valueString)
            where TEnum : Enum
        {
            var value = (TEnum)Enum.Parse(typeof(TEnum), valueString);
            return value;
        }

        /// <summary>
        /// Produces an exception for use in the default case of a switch statement based on values of the <typeparamref name="TEnum"/> enumeration.
        /// Note: there is no method just throwing the exception, as the VS linter does not detect that a method call will always produce an exception, and thus demands that switch default case behavior cannot fall through one default case to another. The throw keyword in the switch default case must be present.
        /// </summary>
        public UnexpectedEnumerationValueException<TEnum> GetSwitchDefaultCaseException<TEnum>(TEnum value)
            where TEnum : Enum
        {
            var exception = this.UnexpectedEnumerationValueException(value);
            return exception;
        }

        /// <summary>
        /// Gets a message indicating that the input string representation of an enumeration value was not recognized among the string representations of a possible values of the enumeration type.
        /// </summary>
        public string UnrecognizedEnumerationValueMessage(string enumerationTypeFullName, string unrecognizedValue)
        {
            var output = $@"Unrecognized enumeration value string '{unrecognizedValue}' for enumeration type {enumerationTypeFullName}";
            return output;
        }

        public string UnrecognizedEnumerationValueMessage(Type enumerationType, string unrecognizedValue)
        {
            var enumerationTypeFullName = enumerationType.FullName;

            var output = this.UnrecognizedEnumerationValueMessage(enumerationTypeFullName, unrecognizedValue);
            return output;
        }

        /// <summary>
        /// Gets a message indicating that the input string representation of an enumeration value was not recognized among the string representations of a possible values of the <typeparamref name="TEnum"/> enumeration.
        /// </summary>
        public string UnrecognizedEnumerationValueMessage<TEnum>(string unrecognizedValue)
            where TEnum : Enum
        {
            var enumerationType = typeof(TEnum);

            var output = this.UnrecognizedEnumerationValueMessage(enumerationType, unrecognizedValue);
            return output;
        }

        /// <summary>
        /// Produces an exception in the case where the string representation of a enumeration value is unrecognizable as one of the values of the <paramref name="enumerationTypeFullName"/> enumeration.
        /// Useful in the default case of a switch statement for parsing a string to an enumeration.
        /// </summary>
        public UnrecognizedEnumerationValueException UnrecognizedEnumerationValueException(string enumerationTypeFullName, string unrecognizedValue)
        {
            var unrecognizedEnumerationValueException = new UnrecognizedEnumerationValueException(enumerationTypeFullName, unrecognizedValue);
            return unrecognizedEnumerationValueException;
        }

        /// <summary>
        /// Produces an exception in the case where the string representation of a enumeration value is unrecognizable as one of the values of the <paramref name="enumerationType"/> enumeration.
        /// Useful in the default case of a switch statement for parsing a string to an enumeration.
        /// </summary>
        public UnrecognizedEnumerationValueException UnrecognizedEnumerationValueException(Type enumerationType, string unrecognizedValue)
        {
            var enumerationTypeFullName = enumerationType.FullName;

            var unrecognizedEnumerationValueException = this.UnrecognizedEnumerationValueException(enumerationTypeFullName, unrecognizedValue);
            return unrecognizedEnumerationValueException;
        }

        /// <summary>
        /// Produces an exception in the case where the string representation of a enumeration value is unrecognizable as one of the values of the <typeparamref name="TEnum"/> enumeration.
        /// Useful in the default case of a switch statement for parsing a string to an enumeration.
        /// </summary>
        public UnrecognizedEnumerationValueException UnrecognizedEnumerationValueException<TEnum>(string unrecognizedValue)
            where TEnum : Enum
        {
            var enumerationType = typeof(TEnum);

            var unrecognizedEnumerationValueException = this.UnrecognizedEnumerationValueException(enumerationType, unrecognizedValue);
            return unrecognizedEnumerationValueException;
        }
    }
}
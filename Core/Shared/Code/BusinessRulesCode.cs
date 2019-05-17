namespace SAC.Munin.Code
{
    using Seed.NLayer.ExceptionHandling;

    internal class BusinessRulesCode
    {
        private static BusinessRuleData @default;
        private static BusinessRuleData locationExists;

        public static BusinessRuleData LocationExists
        {
            get
            {
                return locationExists
                       ?? (locationExists =
                           new BusinessRuleData { Code = "LocationExists", Message = "La Localidad (País/Provincia/Cuidad) ya se encuentra en la base de datos." });
            }
        }

        public static BusinessRuleData Default
        {
            get
            {
                return @default
                       ?? (@default =
                           new BusinessRuleData
                           {
                               Code = "Default",
                               Message =
                                   "Se presentó una condición de falla. Por favor, reintente y si se repite el inconveniente comuníquelo al soporte técnico del sistema."
                           });
            }
        }

        internal class BusinessRuleData
        {
            public string Code { get; set; }
            public string Message { get; set; }
            public string FormatMessage(params object[] args)
            {
                return args.Length > 0 ? string.Format(this.Message, args) : this.Message;
            }

            public BusinessRulesException NewBusinessException(params object[] args)
            {
                return new BusinessRulesException(this.FormatMessage(args), this.Code);
            }
        }
    }
}

namespace MapChallenge.Shared.Mapping
{
    using AutoMapper;

    internal interface IHaveCustomMappings
    {
        void CreateMappings(IProfileExpression configuration);
    }
}

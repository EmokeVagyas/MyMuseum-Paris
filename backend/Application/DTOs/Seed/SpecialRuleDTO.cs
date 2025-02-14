using Backend.Application.DTOs.Seed;

public class SpecialRuleDto
{
    public string RuleType { get; set; } = string.Empty;
    public ConditionDto Condition { get; set; } = new ConditionDto();
    public string Description { get; set; } = string.Empty;
}
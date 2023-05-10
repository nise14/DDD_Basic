namespace Api.Commands;

public record CreatePersonCommand(Guid personId, string Name, string addressLine, string postalCode);
namespace SuperPoc.BuildingBlocks.Infrastructure.Options;

public record SmtpOptions(string Host, int Port, string Username, string Password);
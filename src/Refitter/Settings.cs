using Spectre.Console.Cli;
using System.ComponentModel;

namespace Refitter;

public sealed class Settings : CommandSettings
{
    [Description("URL or file path to OpenAPI Specification file")]
    [CommandArgument(0, "[URL or input file]")]
    public string? OpenApiPath { get; set; }

    [Description("Default namespace to use for generated types")]
    [CommandOption("-n|--namespace")]
    [DefaultValue("GeneratedCode")]
    public string? Namespace { get; set; }

    [Description("Path to Output file")]
    [CommandOption("-o|--output")]
    [DefaultValue("Output.cs")]
    public string? OutputPath { get; set; }

    [Description("Don't add <auto-generated> header to output file")]
    [CommandOption("--no-auto-generated-header")]
    [DefaultValue(false)]
    public bool NoAutoGeneratedHeader { get; set; }

    [Description("Don't generate contract types")]
    [CommandOption("--interface-only")]
    [DefaultValue(false)]
    public bool InterfaceOnly { get; set; }

    [Description("Return Task<IApiResponse<T>> instead of Task<T>")]
    [CommandOption("--use-api-response")]
    [DefaultValue(false)]
    public bool ReturnIApiResponse { get; set; }

    [Description("Set the accessibility of the generated types to 'internal'")]
    [CommandOption("--internal")]
    [DefaultValue(false)]
    public bool InternalTypeAccessibility { get; set; }

    [Description("Use cancellation tokens")]
    [CommandOption("--cancellation-tokens")]
    [DefaultValue(false)]
    public bool UseCancellationTokens { get; set; }

    [Description("Don't generate operation headers")]
    [CommandOption("--no-operation-headers")]
    [DefaultValue(false)]
    public bool NoOperationHeaders { get; set; }

    [Description("Don't log errors or collect telemetry")]
    [CommandOption("--no-logging")]
    [DefaultValue(false)]
    public bool NoLogging { get; set; }

    [Description("Add additional namespace to generated types")]
    [CommandOption("--additional-namespace")]
    [DefaultValue(new string[0])]
    public string[]? AdditionalNamespaces { get; set; }

    [Description("Explicitly format date query string parameters in ISO 8601 standard date format using delimiters (2023-06-15)")]
    [CommandOption("--use-iso-date-format")]
    [DefaultValue(false)]
    public bool UseIsoDateFormat { get; set; }

    private const string MultipleInterfacesValues = $"{nameof(Core.MultipleInterfaces.ByEndpoint)}, {nameof(Core.MultipleInterfaces.ByTag)}";

    [Description($"Generate a Refit interface for each endpoint. May be one of {MultipleInterfacesValues}")]
    [CommandOption("--multiple-interfaces")]
    public Core.MultipleInterfaces MultipleInterfaces { get; set; } = Core.MultipleInterfaces.Unset;
}
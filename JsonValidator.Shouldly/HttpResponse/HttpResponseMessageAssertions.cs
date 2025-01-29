using System.Linq;
using System.Net.Http;
using Shouldly;

namespace JsonValidator.Shouldly.HttpResponse;

public static class HttpResponseMessageExtensions
{
    private const string BasicErrorMessage = "Expected response body to match the JSON input.";

    /// <summary>
    /// Checks whether the HTTP response's body as a JSON string matches the input object in both structure and values.
    /// </summary>
    /// <param name="instance">The <see cref="HttpResponseMessage"/> to validate</param>
    /// <param name="expected">The expected value as an anonymous object</param>
    public static void ShouldHaveJsonBody(this HttpResponseMessage instance, object expected)
    {
        var isMatch = System.Text.Json.JsonDocument
            .Parse(instance.Content.ReadAsStringAsync().GetAwaiter().GetResult())
            .TryValidateMatch(expected, out var errors);

        // When the match is false, the error list will not be empty, but we prepare for an empty list just in case.
        isMatch.ShouldBeTrue(
            errors.Any()
                ? $"{BasicErrorMessage} Issues: {string.Join(", ", errors)}"
                : BasicErrorMessage);
    }
}

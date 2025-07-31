using System.Linq;
using System.Text.Json;
using Shouldly;

namespace JsonValidator.Shouldly.Json;

public static class JsonDocumentAssertions
{
    private const string BasicErrorMessage = "Expected JSON object to match the given object.";

    /// <summary>
    /// Checks whether the JSON document matches the input object in both structure and values.
    /// </summary>
    /// <param name="jsonDocument">The <see cref="JsonDocument"/> to validate</param>
    /// <param name="expected">The expected value as an anonymous object</param>
    public static void ShouldMatch(this JsonDocument jsonDocument, object expected)
    {
        var isMatch = jsonDocument.TryValidateMatch(expected, out var errors);

        // When the match is false, the error list will not be empty, but we prepare for an empty list just in case.
        isMatch.ShouldBeTrue(
            errors.Any()
                ? $"{BasicErrorMessage} Issues: {string.Join(", ", errors)}"
                : BasicErrorMessage);
    }
}

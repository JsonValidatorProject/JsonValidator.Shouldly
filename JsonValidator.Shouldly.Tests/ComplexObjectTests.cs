using System.Net.Http.Headers;
using System.Text.Json;
using JsonValidator.Shouldly.HttpResponse;
using JsonValidator.Shouldly.Json;

namespace JsonValidator.Shouldly.Tests;

public class ComplexObjectTests
{
    public class MatchTests
    {
        [Fact]
        public void TestComplexObjectFromJson()
        {
            var json = JsonDocument.Parse(
                """
                {
                  "name": "Jenny Smith",
                  "title": null,
                  "level": 2,
                  "isAvailable": true,
                  "employeeScore": 4.5326,
                  "nextLevels": [ 3, 4, 5 ],
                  "capabilities": ["accounting", "marketing", "sales"],
                  "pollAnswers": [true, false, true, true],
                  "oldEmployeeScores": [4.2563, 4.2311, 4.3956],
                  "personalData":
                  {
                    "age": 41,
                    "nickname": "JenTheMan",
                    "isMarried": false,
                    "creditScore": 789.3698
                  },
                  "shadows": [
                    {
                      "name": "Jack Smith",
                      "level": 0,
                      "employeeScore": 3.256,
                      "isAvailable": true,
                      "title": null
                    },
                    {
                      "name": "Anna Nicholson",
                      "level": 1,
                      "employeeScore": 3.35,
                      "isAvailable": false,
                      "title": null
                    },
                    null
                  ]
                }
                """);

            var expected = new
            {
                name = "Jenny Smith",
                title = null as string,
                level = 2,
                isAvailable = true,
                employeeScore = 4.5326,
                nextLevels = new[] { 3, 4, 5 },
                capabilities = new[] { "accounting", "marketing", "sales" },
                pollAnswers = new[] { true, false, true, true },
                oldEmployeeScores = new[] { 4.2563, 4.2311, 4.3956 },
                personalData = new { age = 41, nickname = "JenTheMan", isMarried = false, creditScore = 789.3698 },
                shadows = new[]
                {
                    new
                    {
                        name = "Jack Smith",
                        level = 0,
                        employeeScore = 3.256,
                        isAvailable = true,
                        title = null as string
                    },
                    new
                    {
                        name = "Anna Nicholson",
                        level = 1,
                        employeeScore = 3.35,
                        isAvailable = false,
                        title = null as string
                    },
                    null
                }
            };

            json.ShouldMatch(expected);
        }

        [Fact]
        public void TestComplexObjectFromHttpResponse()
        {
            var jsonString =
                """
                {
                  "name": "Jenny Smith",
                  "title": null,
                  "level": 2,
                  "isAvailable": true,
                  "employeeScore": 4.5326,
                  "nextLevels": [ 3, 4, 5 ],
                  "capabilities": ["accounting", "marketing", "sales"],
                  "pollAnswers": [true, false, true, true],
                  "oldEmployeeScores": [4.2563, 4.2311, 4.3956],
                  "personalData":
                  {
                    "age": 41,
                    "nickname": "JenTheMan",
                    "isMarried": false,
                    "creditScore": 789.3698
                  },
                  "shadows": [
                    {
                      "name": "Jack Smith",
                      "level": 0,
                      "employeeScore": 3.256,
                      "isAvailable": true,
                      "title": null
                    },
                    {
                      "name": "Anna Nicholson",
                      "level": 1,
                      "employeeScore": 3.35,
                      "isAvailable": false,
                      "title": null
                    },
                    null
                  ]
                }
                """;

            var expected = new
            {
                name = "Jenny Smith",
                title = null as string,
                level = 2,
                isAvailable = true,
                employeeScore = 4.5326,
                nextLevels = new[] { 3, 4, 5 },
                capabilities = new[] { "accounting", "marketing", "sales" },
                pollAnswers = new[] { true, false, true, true },
                oldEmployeeScores = new[] { 4.2563, 4.2311, 4.3956 },
                personalData = new { age = 41, nickname = "JenTheMan", isMarried = false, creditScore = 789.3698 },
                shadows = new[]
                {
                    new
                    {
                        name = "Jack Smith",
                        level = 0,
                        employeeScore = 3.256,
                        isAvailable = true,
                        title = null as string
                    },
                    new
                    {
                        name = "Anna Nicholson",
                        level = 1,
                        employeeScore = 3.35,
                        isAvailable = false,
                        title = null as string
                    },
                    null
                }
            };

            var response = new HttpResponseMessage
            {
                Content = new StringContent(jsonString, mediaType: new MediaTypeHeaderValue("application/json"))
            };

            response.ShouldHaveJsonBody(expected);
        }
    }

    public class MismatchTests
    {
        [Fact]
        public void TestComplexObjectFromJson()
        {
            var json = JsonDocument.Parse(
                """
                {
                  "name": "Jenny Smith",
                  "title": null,
                  "level": 2,
                  "isAvailable": true,
                  "employeeScore": 4.5326,
                  "nextLevels": [ 3, 4, 5 ],
                  "capabilities": ["accounting", "marketing", "sales"],
                  "pollAnswers": [true, false, true, true],
                  "oldEmployeeScores": [4.2563, 4.2311, 4.3956],
                  "personalData":
                  {
                    "age": 41,
                    "nickname": "JenTheMan",
                    "isMarried": false,
                    "creditScore": 789.3698
                  },
                  "shadows": [
                    {
                      "name": "Jack Smith",
                      "level": 0,
                      "employeeScore": 3.256,
                      "isAvailable": true,
                      "title": null
                    },
                    {
                      "name": "Anna Nicholson",
                      "level": 1,
                      "employeeScore": 3.35,
                      "isAvailable": false,
                      "title": null
                    },
                    null
                  ]
                }
                """);

            var expected = new
            {
                name = "Johnny Smith",
                title = null as string,
                level = 2,
                isAvailable = true,
                employeeScore = 4.5326,
                nextLevels = new[] { 3, 4, 5 },
                capabilities = new[] { "accounting", "marketing", "development" },
                pollAnswers = new[] { true, false, true, true },
                oldEmployeeScores = new[] { 4.2563, 4.2311, 4.3956 },
                personalData = new { age = 41, nickname = "JenTheMan", isMarried = false, creditScore = 789.3698 },
                shadows = new[]
                {
                    new
                    {
                        name = "Jack Smith",
                        level = 0,
                        employeeScore = 3.256,
                        isAvailable = true,
                        title = null as string
                    },
                    new
                    {
                        name = "Anna Nicholson",
                        level = 1,
                        employeeScore = 3.35,
                        isAvailable = false,
                        title = null as string
                    },
                    null
                }
            };

            var act = () => json.ShouldMatch(expected);

            act
                .ShouldThrow<ShouldAssertException>()
                .Message.ShouldContain("Expected JSON object to match the given object");
        }

        [Fact]
        public void TestComplexObjectFromHttpResponse()
        {
            var jsonString =
                """
                {
                  "name": "Jenny Smith",
                  "title": null,
                  "level": 2,
                  "isAvailable": true,
                  "employeeScore": 4.5326,
                  "nextLevels": [ 3, 4, 5 ],
                  "capabilities": ["accounting", "marketing", "sales"],
                  "pollAnswers": [true, false, true, true],
                  "oldEmployeeScores": [4.2563, 4.2311, 4.3956],
                  "personalData":
                  {
                    "age": 41,
                    "nickname": "JenTheMan",
                    "isMarried": false,
                    "creditScore": 789.3698
                  },
                  "shadows": [
                    {
                      "name": "Jack Smith",
                      "level": 0,
                      "employeeScore": 3.256,
                      "isAvailable": true,
                      "title": null
                    },
                    {
                      "name": "Anna Nicholson",
                      "level": 1,
                      "employeeScore": 3.35,
                      "isAvailable": false,
                      "title": null
                    },
                    null
                  ]
                }
                """;

            var expected = new
            {
                name = "Johnny Smith",
                title = null as string,
                level = 2,
                isAvailable = true,
                employeeScore = 4.5326,
                nextLevels = new[] { 3, 4, 5 },
                capabilities = new[] { "accounting", "marketing", "development" },
                pollAnswers = new[] { true, false, true, true },
                oldEmployeeScores = new[] { 4.2563, 4.2311, 4.3956 },
                personalData = new { age = 41, nickname = "JenTheMan", isMarried = false, creditScore = 789.3698 },
                shadows = new[]
                {
                    new
                    {
                        name = "Jack Smith",
                        level = 0,
                        employeeScore = 3.256,
                        isAvailable = true,
                        title = null as string
                    },
                    new
                    {
                        name = "Anna Nicholson",
                        level = 1,
                        employeeScore = 3.35,
                        isAvailable = false,
                        title = null as string
                    },
                    null
                }
            };

            var response = new HttpResponseMessage
            {
                Content = new StringContent(jsonString, mediaType: new MediaTypeHeaderValue("application/json"))
            };

            var act = () => response.ShouldHaveJsonBody(expected);

            act
                .ShouldThrow<ShouldAssertException>()
                .Message.ShouldContain("Expected response body to match the JSON input");
        }
    }
}

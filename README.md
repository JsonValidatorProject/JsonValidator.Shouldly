# `{✓}` JSON Validator for Shouldly
This project provides a simple way to validate JSON objects in dotnet. The main use for the tool is in integration tests where you would — ideally — validate an API JSON response manually instead of using the model classes.

[![Build Status](https://github.com/JsonValidatorProject/JsonValidator.Shouldly/workflows/build-and-test/badge.svg "Build Status")](https://github.com/JsonValidatorProject/JsonValidator.Shouldly/actions?query=workflow%3A%22build-and-test%22)
[![Coverage](https://codecov.io/gh/JsonValidatorProject/JsonValidator.Shouldly/branch/main/graph/badge.svg)](https://codecov.io/gh/JsonValidatorProject/JsonValidator.Shouldly)
[![Nuget: JsonValidator.Shouldly](https://img.shields.io/nuget/v/JsonValidator.Shouldly?label=JsonValidator.Shouldly&logo=nuget)](https://www.nuget.org/packages/JsonValidator.Shouldly)
[![License: MIT](https://img.shields.io/badge/license-MIT-blueviolet)](https://opensource.org/licenses/MIT)
[![pull requests: welcome](https://img.shields.io/badge/pull%20requests-welcome-brightgreen)](https://github.com/JsonValidatorProject/JsonValidator/fork)

## Usage
- The `JsonValidator.Shouldly` package depends on and uses both [Shouldly](https://github.com/shouldly/shouldly) and the basic [JsonValidator](https://github.com/JsonValidatorProject/JsonValidator) package.
- This package provides extensions that follow Shouldly's `Should...()` pattern.
- Available extensions:
  - for `System.Text.Json.JsonDocument`: `ShouldMatch(...)` checks whether the JSON document matches the input object in both structure and values.
  - for `System.Net.Http.HttpResponseMessage`: `ShouldHaveJsonBody(...)` checks whether the HTTP response's body as a JSON string matches the input object in both structure and values.

### Examples
For `JsonDocument`:
```csharp
var json = JsonDocument.Parse(myJsonString);

json.ShouldMatch(
  new
  {
      name = "Anna Smith",
      level = 2,
  });
```

For `HttpResponseMessage`:
```csharp
HttpResponseMessage response = await _client.SendAsync(request);

response.ShouldHaveJsonBody(
  new
  {
      name = "Anna Smith",
      level = 2,
  });
```

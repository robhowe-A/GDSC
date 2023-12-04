# Dotnet project async fetch

This folder, "APIREQUEST", represents a fetch request to USGS. It returns a file with XML from the endpoint.

## Project Setup

- In Main, change the coordinates to get your results.

```
//coordinates
            string Northern_most = @"32.874699";
            string Western_most = @"-96.958875";
            string Eastern_most = @"-96.932789";
            string Southern_most = @"32.859052";
```

- In terminal, type dotnet run. The program completes, and the file 'waterservices.txt' is over-written with the results.

```
dotnet build
dotnet run
```

## Dependencies

1. DotNet 8, SDK

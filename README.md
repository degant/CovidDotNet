[![Nuget](https://img.shields.io/nuget/v/CovidDotNet?color=orange)](https://www.nuget.org/packages/CovidDotNet)

# CovidDotNet
CovidDotNet is a C# client for using the Coronavirus Tracking APIs by [@ExpDev07](https://github.com/ExpDev07/) (https://github.com/ExpDev07/coronavirus-tracker-api). The nuget package targets .NET Standard so it supports both .NET Core (> 2.1) and .NET framework (> 4.6).


The aim of the client is to help speed up the development time for anyone looking to access data from the tracking APIs. The client 
takes care of parsing all values returned from the API into the valid data types (including `DateTimeOffset`, `long` etc.).

## Nuget
CovidDotNet is available as nuget package: https://www.nuget.org/packages/CovidDotNet

## Usage

Initialize the client

```csharp
CovidClient client = new CovidClient();
```

To get latest numbers,

```csharp
Latest latest = await c.GetLatestAsync();

Console.WriteLine("Confirmed: " + latest.Confirmed);
Console.WriteLine("Deaths: " + latest.Deaths);
Console.WriteLine("Recovered: " + latest.Recovered);
```

To get data for all locations,


```csharp
IList<Location> locations = await c.GetLocationsAsync();
Console.WriteLine("Total Locations: " + locations.Count);
```

All APIs default the datasource as `DataSource.JHS` but it can be passed explicitly to any of the APIs:

```csharp
Latest latest = await c.GetLatestAsync(DataSource.CSBS);
```
    
## Feedback
Feel free to open an issue, or share any feedback using the client.

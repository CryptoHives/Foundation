| Description                               | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|------------------------------------------ |------------- |---------------:|------------:|------------:|----------:|
| TryComputeHash · Whirlpool · Managed      | 128B         |       888.8 ns |     0.58 ns |     0.55 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET | 128B         |     1,996.3 ns |     8.00 ns |     7.48 ns |    6336 B |
| TryComputeHash · Whirlpool · BouncyCastle | 128B         |     4,373.2 ns |    13.97 ns |    13.06 ns |      56 B |
|                                           |              |                |             |             |           |
| TryComputeHash · Whirlpool · Managed      | 137B         |       887.3 ns |     0.41 ns |     0.36 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET | 137B         |     1,995.5 ns |     6.80 ns |     6.36 ns |    6328 B |
| TryComputeHash · Whirlpool · BouncyCastle | 137B         |     4,378.4 ns |    12.43 ns |    11.63 ns |      56 B |
|                                           |              |                |             |             |           |
| TryComputeHash · Whirlpool · Managed      | 1KB          |     4,935.2 ns |     3.17 ns |     2.97 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET | 1KB          |    10,346.6 ns |    31.42 ns |    29.39 ns |   12032 B |
| TryComputeHash · Whirlpool · BouncyCastle | 1KB          |    27,062.3 ns |    66.76 ns |    62.44 ns |      56 B |
|                                           |              |                |             |             |           |
| TryComputeHash · Whirlpool · Managed      | 1025B        |     4,939.5 ns |     1.96 ns |     1.83 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET | 1025B        |    10,316.1 ns |    23.25 ns |    21.75 ns |   12040 B |
| TryComputeHash · Whirlpool · BouncyCastle | 1025B        |    27,048.7 ns |    69.39 ns |    64.91 ns |      56 B |
|                                           |              |                |             |             |           |
| TryComputeHash · Whirlpool · Managed      | 8KB          |    37,305.3 ns |    19.89 ns |    18.61 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET | 8KB          |    76,258.5 ns |   263.72 ns |   246.69 ns |   58624 B |
| TryComputeHash · Whirlpool · BouncyCastle | 8KB          |   208,392.6 ns |   532.19 ns |   471.77 ns |      56 B |
|                                           |              |                |             |             |           |
| TryComputeHash · Whirlpool · Managed      | 128KB        |   592,400.6 ns |   309.19 ns |   289.22 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET | 128KB        | 1,225,115.9 ns | 3,663.51 ns | 3,426.85 ns |  857372 B |
| TryComputeHash · Whirlpool · BouncyCastle | 128KB        | 3,312,039.0 ns | 6,413.94 ns | 5,685.79 ns |      56 B |
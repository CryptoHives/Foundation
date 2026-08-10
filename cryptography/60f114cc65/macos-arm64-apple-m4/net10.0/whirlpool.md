| Description                               | TestDataSize | Mean           | Error     | StdDev    | Allocated |
|------------------------------------------ |------------- |---------------:|----------:|----------:|----------:|
| TryComputeHash · Whirlpool · Managed      | 128B         |       889.1 ns |   0.22 ns |   0.21 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET | 128B         |     2,020.2 ns |   0.90 ns |   0.75 ns |    6336 B |
| TryComputeHash · Whirlpool · BouncyCastle | 128B         |     4,427.4 ns |   1.49 ns |   1.39 ns |      56 B |
|                                           |              |                |           |           |           |
| TryComputeHash · Whirlpool · Managed      | 137B         |       887.5 ns |   0.19 ns |   0.18 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET | 137B         |     2,019.7 ns |   0.82 ns |   0.73 ns |    6328 B |
| TryComputeHash · Whirlpool · BouncyCastle | 137B         |     4,423.7 ns |   5.81 ns |   5.44 ns |      56 B |
|                                           |              |                |           |           |           |
| TryComputeHash · Whirlpool · Managed      | 1KB          |     4,936.7 ns |   2.20 ns |   1.84 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET | 1KB          |    10,461.2 ns |   6.19 ns |   5.48 ns |   12032 B |
| TryComputeHash · Whirlpool · BouncyCastle | 1KB          |    27,350.1 ns |   5.11 ns |   4.26 ns |      56 B |
|                                           |              |                |           |           |           |
| TryComputeHash · Whirlpool · Managed      | 1025B        |     4,941.4 ns |   2.46 ns |   2.30 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET | 1025B        |    10,494.5 ns |   6.94 ns |   6.49 ns |   12040 B |
| TryComputeHash · Whirlpool · BouncyCastle | 1025B        |    27,309.7 ns |   2.79 ns |   2.61 ns |      56 B |
|                                           |              |                |           |           |           |
| TryComputeHash · Whirlpool · Managed      | 8KB          |    37,331.5 ns |  10.93 ns |  10.23 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET | 8KB          |    77,309.6 ns | 183.12 ns | 171.30 ns |   58624 B |
| TryComputeHash · Whirlpool · BouncyCastle | 8KB          |   210,561.4 ns |  33.61 ns |  29.80 ns |      56 B |
|                                           |              |                |           |           |           |
| TryComputeHash · Whirlpool · Managed      | 128KB        |   593,178.2 ns | 235.32 ns | 208.61 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET | 128KB        | 1,241,220.9 ns | 464.92 ns | 412.14 ns |  857372 B |
| TryComputeHash · Whirlpool · BouncyCastle | 128KB        | 3,344,331.1 ns | 918.47 ns | 859.14 ns |      56 B |
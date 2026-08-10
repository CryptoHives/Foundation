| Description                               | TestDataSize | Mean         | Error      | StdDev     | Allocated |
|------------------------------------------ |------------- |-------------:|-----------:|-----------:|----------:|
| TryComputeHash · Whirlpool · Managed      | 128B         |     1.345 μs |  0.0077 μs |  0.0072 μs |         - |
| TryComputeHash · Whirlpool · Hashify .NET | 128B         |     1.987 μs |  0.0236 μs |  0.0209 μs |    6336 B |
| TryComputeHash · Whirlpool · BouncyCastle | 128B         |     5.006 μs |  0.0262 μs |  0.0232 μs |      56 B |
|                                           |              |              |            |            |           |
| TryComputeHash · Whirlpool · Managed      | 137B         |     1.347 μs |  0.0076 μs |  0.0071 μs |         - |
| TryComputeHash · Whirlpool · Hashify .NET | 137B         |     2.014 μs |  0.0234 μs |  0.0219 μs |    6328 B |
| TryComputeHash · Whirlpool · BouncyCastle | 137B         |     5.032 μs |  0.0162 μs |  0.0136 μs |      56 B |
|                                           |              |              |            |            |           |
| TryComputeHash · Whirlpool · Managed      | 1KB          |     9.012 μs |  0.0363 μs |  0.0340 μs |         - |
| TryComputeHash · Whirlpool · Hashify .NET | 1KB          |    10.253 μs |  0.0611 μs |  0.0510 μs |   12032 B |
| TryComputeHash · Whirlpool · BouncyCastle | 1KB          |    31.051 μs |  0.2385 μs |  0.2231 μs |      56 B |
|                                           |              |              |            |            |           |
| TryComputeHash · Whirlpool · Managed      | 1025B        |     7.449 μs |  0.0211 μs |  0.0197 μs |         - |
| TryComputeHash · Whirlpool · Hashify .NET | 1025B        |    10.285 μs |  0.0463 μs |  0.0410 μs |   12040 B |
| TryComputeHash · Whirlpool · BouncyCastle | 1025B        |    31.002 μs |  0.1677 μs |  0.1486 μs |      56 B |
|                                           |              |              |            |            |           |
| TryComputeHash · Whirlpool · Managed      | 8KB          |    57.461 μs |  0.9536 μs |  0.7963 μs |         - |
| TryComputeHash · Whirlpool · Hashify .NET | 8KB          |    75.981 μs |  0.7616 μs |  0.6751 μs |   58624 B |
| TryComputeHash · Whirlpool · BouncyCastle | 8KB          |   242.989 μs |  4.5670 μs |  6.6942 μs |      56 B |
|                                           |              |              |            |            |           |
| TryComputeHash · Whirlpool · Managed      | 128KB        |   890.438 μs |  5.4600 μs |  5.1073 μs |         - |
| TryComputeHash · Whirlpool · Hashify .NET | 128KB        | 1,251.434 μs |  6.2803 μs |  5.5673 μs |  857372 B |
| TryComputeHash · Whirlpool · BouncyCastle | 128KB        | 3,790.528 μs | 13.4650 μs | 11.9364 μs |      56 B |
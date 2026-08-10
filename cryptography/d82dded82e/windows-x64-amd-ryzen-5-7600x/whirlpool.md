| Description                               | TestDataSize | Mean         | Error      | StdDev     | Median       | Allocated |
|------------------------------------------ |------------- |-------------:|-----------:|-----------:|-------------:|----------:|
| TryComputeHash · Whirlpool · Managed      | 128B         |     1.345 μs |  0.0265 μs |  0.0261 μs |     1.344 μs |         - |
| TryComputeHash · Whirlpool · Hashify .NET | 128B         |     2.079 μs |  0.0399 μs |  0.0560 μs |     2.075 μs |    6336 B |
| TryComputeHash · Whirlpool · BouncyCastle | 128B         |     5.107 μs |  0.0535 μs |  0.0501 μs |     5.094 μs |      56 B |
|                                           |              |              |            |            |              |           |
| TryComputeHash · Whirlpool · Managed      | 137B         |     1.328 μs |  0.0087 μs |  0.0082 μs |     1.326 μs |         - |
| TryComputeHash · Whirlpool · Hashify .NET | 137B         |     2.066 μs |  0.0411 μs |  0.0403 μs |     2.053 μs |    6328 B |
| TryComputeHash · Whirlpool · BouncyCastle | 137B         |     5.143 μs |  0.0814 μs |  0.0761 μs |     5.135 μs |      56 B |
|                                           |              |              |            |            |              |           |
| TryComputeHash · Whirlpool · Managed      | 1KB          |     7.624 μs |  0.1062 μs |  0.0941 μs |     7.621 μs |         - |
| TryComputeHash · Whirlpool · Hashify .NET | 1KB          |    10.440 μs |  0.0591 μs |  0.0524 μs |    10.418 μs |   12032 B |
| TryComputeHash · Whirlpool · BouncyCastle | 1KB          |    31.852 μs |  0.6259 μs |  0.6697 μs |    31.603 μs |      56 B |
|                                           |              |              |            |            |              |           |
| TryComputeHash · Whirlpool · Managed      | 1025B        |     9.148 μs |  0.1751 μs |  0.2338 μs |     9.064 μs |         - |
| TryComputeHash · Whirlpool · Hashify .NET | 1025B        |    10.854 μs |  0.2152 μs |  0.3086 μs |    10.750 μs |   12040 B |
| TryComputeHash · Whirlpool · BouncyCastle | 1025B        |    31.762 μs |  0.6230 μs |  0.5827 μs |    31.757 μs |      56 B |
|                                           |              |              |            |            |              |           |
| TryComputeHash · Whirlpool · Managed      | 8KB          |    58.836 μs |  1.1718 μs |  3.0038 μs |    57.556 μs |         - |
| TryComputeHash · Whirlpool · Hashify .NET | 8KB          |    76.728 μs |  0.6145 μs |  0.5131 μs |    76.800 μs |   58624 B |
| TryComputeHash · Whirlpool · BouncyCastle | 8KB          |   240.887 μs |  1.0425 μs |  0.9752 μs |   240.714 μs |      56 B |
|                                           |              |              |            |            |              |           |
| TryComputeHash · Whirlpool · Managed      | 128KB        |   913.005 μs |  6.1540 μs |  5.7564 μs |   913.813 μs |         - |
| TryComputeHash · Whirlpool · Hashify .NET | 128KB        | 1,310.202 μs | 25.4117 μs | 33.0423 μs | 1,309.372 μs |  857372 B |
| TryComputeHash · Whirlpool · BouncyCastle | 128KB        | 3,860.332 μs | 74.5913 μs | 73.2586 μs | 3,821.104 μs |      56 B |
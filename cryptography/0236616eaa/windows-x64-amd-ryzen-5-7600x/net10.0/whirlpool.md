| Description                                     | TestDataSize | Mean         | Error     | StdDev    | Code Size | Allocated |
|------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|----------:|
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 128B         |     1.388 μs | 0.0036 μs | 0.0030 μs |   5,043 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 128B         |     2.117 μs | 0.0205 μs | 0.0171 μs |        NA |    6336 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 128B         |     5.184 μs | 0.0141 μs | 0.0118 μs |  10,733 B |      56 B |
|                                                 |              |              |           |           |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 137B         |     1.370 μs | 0.0034 μs | 0.0030 μs |   5,049 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 137B         |     2.114 μs | 0.0151 μs | 0.0141 μs |        NA |    6328 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 137B         |     5.188 μs | 0.0160 μs | 0.0142 μs |  10,709 B |      56 B |
|                                                 |              |              |           |           |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 1KB          |     7.899 μs | 0.0250 μs | 0.0221 μs |   5,043 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 1KB          |    10.678 μs | 0.0590 μs | 0.0523 μs |        NA |   12032 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 1KB          |    31.892 μs | 0.0800 μs | 0.0625 μs |  10,711 B |      56 B |
|                                                 |              |              |           |           |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 1025B        |     7.778 μs | 0.0226 μs | 0.0211 μs |   5,045 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 1025B        |    10.687 μs | 0.0584 μs | 0.0547 μs |        NA |   12040 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 1025B        |    31.993 μs | 0.0482 μs | 0.0402 μs |  10,706 B |      56 B |
|                                                 |              |              |           |           |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 8KB          |    58.196 μs | 0.1975 μs | 0.1847 μs |   5,043 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 8KB          |    78.607 μs | 0.3852 μs | 0.3415 μs |        NA |   58624 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 8KB          |   245.331 μs | 0.5066 μs | 0.4231 μs |  10,711 B |      56 B |
|                                                 |              |              |           |           |           |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 128KB        |   935.293 μs | 2.5817 μs | 2.2886 μs |   5,053 B |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 128KB        | 1,293.218 μs | 7.3026 μs | 6.8308 μs |        NA |  857372 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 128KB        | 3,923.702 μs | 4.3089 μs | 3.8197 μs |  10,706 B |      56 B |
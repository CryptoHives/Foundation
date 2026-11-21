| Description                                     | TestDataSize | Mean           | Error        | StdDev      | Allocated |
|------------------------------------------------ |------------- |---------------:|-------------:|------------:|----------:|
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 128B         |       907.8 ns |      0.48 ns |     0.44 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 128B         |     2,015.7 ns |      3.50 ns |     3.28 ns |    6336 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 128B         |     4,479.7 ns |      5.86 ns |     5.48 ns |      56 B |
|                                                 |              |                |              |             |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 137B         |       904.9 ns |      0.54 ns |     0.51 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 137B         |     2,014.3 ns |      2.85 ns |     2.67 ns |    6328 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 137B         |     4,477.5 ns |      3.53 ns |     3.30 ns |      56 B |
|                                                 |              |                |              |             |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 1KB          |     5,029.8 ns |      4.18 ns |     3.91 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 1KB          |    10,328.8 ns |     21.40 ns |    20.02 ns |   12032 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 1KB          |    27,724.5 ns |     69.39 ns |    61.52 ns |      56 B |
|                                                 |              |                |              |             |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 1025B        |     5,052.9 ns |     15.25 ns |    14.27 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 1025B        |    10,451.8 ns |     39.32 ns |    36.78 ns |   12040 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 1025B        |    27,797.5 ns |     82.75 ns |    77.40 ns |      56 B |
|                                                 |              |                |              |             |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 8KB          |    38,219.8 ns |    140.69 ns |   131.60 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 8KB          |    77,934.9 ns |    213.11 ns |   199.35 ns |   58624 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 8KB          |   215,406.3 ns |    434.55 ns |   406.48 ns |      56 B |
|                                                 |              |                |              |             |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 128KB        |   604,276.0 ns |  3,729.60 ns | 3,488.67 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 128KB        | 1,243,606.4 ns |  4,612.69 ns | 4,314.71 ns |  857383 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 128KB        | 3,400,086.2 ns | 10,684.99 ns | 9,994.75 ns |      56 B |
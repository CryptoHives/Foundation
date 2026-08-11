| Description                                     | TestDataSize | Mean           | Error        | StdDev       | Allocated |
|------------------------------------------------ |------------- |---------------:|-------------:|-------------:|----------:|
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 128B         |       895.0 ns |      2.60 ns |      2.31 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 128B         |     2,035.0 ns |      7.25 ns |      6.79 ns |    6336 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 128B         |     4,443.4 ns |     14.71 ns |     13.76 ns |      56 B |
|                                                 |              |                |              |              |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 137B         |       892.3 ns |      2.67 ns |      2.50 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 137B         |     2,036.8 ns |      2.04 ns |      1.91 ns |    6328 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 137B         |     4,484.5 ns |      2.27 ns |      2.12 ns |      56 B |
|                                                 |              |                |              |              |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 1KB          |     4,974.0 ns |     10.09 ns |      9.44 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 1KB          |    10,517.1 ns |      6.72 ns |      6.28 ns |   12032 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 1KB          |    27,513.0 ns |     22.53 ns |     21.07 ns |      56 B |
|                                                 |              |                |              |              |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 1025B        |     4,966.5 ns |     13.36 ns |     12.50 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 1025B        |    10,522.2 ns |      6.89 ns |      6.45 ns |   12040 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 1025B        |    27,506.6 ns |     23.01 ns |     21.52 ns |      56 B |
|                                                 |              |                |              |              |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 8KB          |    37,578.2 ns |    127.31 ns |    112.86 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 8KB          |    77,601.1 ns |     85.60 ns |     80.07 ns |   58624 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 8KB          |   211,797.7 ns |    658.72 ns |    616.17 ns |      56 B |
|                                                 |              |                |              |              |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 128KB        |   596,541.3 ns |  1,690.68 ns |  1,581.46 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 128KB        | 1,251,944.0 ns |    910.20 ns |    851.40 ns |  857372 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 128KB        | 3,358,991.9 ns | 10,858.62 ns | 10,157.16 ns |      56 B |
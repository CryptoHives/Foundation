| Description                                     | TestDataSize | Mean           | Error        | StdDev      | Allocated |
|------------------------------------------------ |------------- |---------------:|-------------:|------------:|----------:|
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 128B         |       885.0 ns |      3.30 ns |     3.09 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 128B         |     2,051.9 ns |      7.43 ns |     6.95 ns |    6336 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 128B         |     4,435.4 ns |     14.73 ns |    13.78 ns |      56 B |
|                                                 |              |                |              |             |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 137B         |       883.6 ns |      2.56 ns |     2.39 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 137B         |     2,036.7 ns |      4.31 ns |     4.03 ns |    6328 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 137B         |     4,434.9 ns |     16.64 ns |    15.57 ns |      56 B |
|                                                 |              |                |              |             |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 1KB          |     4,918.0 ns |     19.66 ns |    18.39 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 1KB          |    10,495.3 ns |     39.05 ns |    36.52 ns |   12032 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 1KB          |    27,416.7 ns |     67.32 ns |    59.68 ns |      56 B |
|                                                 |              |                |              |             |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 1025B        |     4,928.0 ns |     16.27 ns |    15.22 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 1025B        |    10,503.8 ns |     35.32 ns |    33.04 ns |   12040 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 1025B        |    27,450.1 ns |     57.16 ns |    53.47 ns |      56 B |
|                                                 |              |                |              |             |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 8KB          |    37,299.2 ns |     58.17 ns |    51.56 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 8KB          |    77,615.6 ns |    274.09 ns |   256.39 ns |   58624 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 8KB          |   211,500.4 ns |    658.73 ns |   616.18 ns |      56 B |
|                                                 |              |                |              |             |           |
| TryComputeHash · Whirlpool · CryptoHives-Scalar | 128KB        |   591,789.1 ns |  2,074.81 ns | 1,940.77 ns |         - |
| TryComputeHash · Whirlpool · Hashify .NET       | 128KB        | 1,248,770.9 ns |  4,001.87 ns | 3,743.35 ns |  857372 B |
| TryComputeHash · Whirlpool · BouncyCastle       | 128KB        | 3,356,927.9 ns | 10,190.55 ns | 9,532.24 ns |      56 B |
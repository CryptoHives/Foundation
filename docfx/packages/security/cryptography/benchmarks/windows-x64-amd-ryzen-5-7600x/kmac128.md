| Description                                    | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 128B         |     639.3 ns |     4.43 ns |     4.15 ns |         - |
| TryComputeHash · KMAC-128 · OS Native          | 128B         |     999.7 ns |     6.60 ns |     5.85 ns |     184 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 128B         |   1,971.0 ns |     7.39 ns |     6.17 ns |     256 B |
|                                                |              |              |             |             |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 137B         |     637.9 ns |     3.86 ns |     3.23 ns |         - |
| TryComputeHash · KMAC-128 · OS Native          | 137B         |   1,011.2 ns |     7.80 ns |     6.92 ns |     200 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 137B         |   1,994.4 ns |    12.68 ns |    11.86 ns |     256 B |
|                                                |              |              |             |             |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 1KB          |   1,845.7 ns |    25.21 ns |    23.58 ns |         - |
| TryComputeHash · KMAC-128 · OS Native          | 1KB          |   2,500.8 ns |    22.71 ns |    21.25 ns |    1080 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 1KB          |   3,802.3 ns |    14.47 ns |    12.08 ns |     256 B |
|                                                |              |              |             |             |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 1025B        |   1,831.1 ns |    11.22 ns |    10.50 ns |         - |
| TryComputeHash · KMAC-128 · OS Native          | 1025B        |   2,490.6 ns |    17.50 ns |    16.37 ns |    1088 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 1025B        |   3,805.8 ns |    14.19 ns |    12.58 ns |     256 B |
|                                                |              |              |             |             |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 8KB          |  10,164.6 ns |    51.04 ns |    47.74 ns |         - |
| TryComputeHash · KMAC-128 · OS Native          | 8KB          |  12,849.2 ns |    54.87 ns |    45.82 ns |    8248 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 8KB          |  16,837.5 ns |    91.76 ns |    81.34 ns |     256 B |
|                                                |              |              |             |             |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 128KB        | 155,699.8 ns | 1,005.02 ns |   940.10 ns |         - |
| TryComputeHash · KMAC-128 · OS Native          | 128KB        | 223,175.9 ns | 1,345.67 ns | 1,258.74 ns |  131151 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 128KB        | 241,935.6 ns | 1,192.39 ns | 1,057.02 ns |     256 B |
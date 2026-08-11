| Description                                    | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|----------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 128B         |     665.6 ns |     1.85 ns |     1.64 ns |        NA |         - |
| TryComputeHash · KMAC-128 · OS Native          | 128B         |   1,032.9 ns |     2.70 ns |     2.25 ns |   8,545 B |     184 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 128B         |   2,035.1 ns |     6.72 ns |     5.96 ns |  19,444 B |     256 B |
|                                                |              |              |             |             |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 137B         |     666.4 ns |     1.46 ns |     1.22 ns |        NA |         - |
| TryComputeHash · KMAC-128 · OS Native          | 137B         |   1,036.9 ns |     3.64 ns |     3.22 ns |   8,669 B |     200 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 137B         |   2,036.0 ns |     6.93 ns |     5.78 ns |  19,447 B |     256 B |
|                                                |              |              |             |             |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 1KB          |   1,913.1 ns |     6.08 ns |     5.39 ns |        NA |         - |
| TryComputeHash · KMAC-128 · OS Native          | 1KB          |   2,622.0 ns |     7.93 ns |     6.62 ns |   8,542 B |    1080 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 1KB          |   3,919.1 ns |     5.02 ns |     3.92 ns |  19,492 B |     256 B |
|                                                |              |              |             |             |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 1025B        |   1,909.3 ns |     4.73 ns |     3.95 ns |        NA |         - |
| TryComputeHash · KMAC-128 · OS Native          | 1025B        |   2,592.2 ns |    11.09 ns |     9.83 ns |   8,543 B |    1088 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 1025B        |   3,967.1 ns |    14.14 ns |    13.22 ns |  18,930 B |     256 B |
|                                                |              |              |             |             |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 8KB          |  10,603.8 ns |    21.54 ns |    20.15 ns |        NA |         - |
| TryComputeHash · KMAC-128 · OS Native          | 8KB          |  13,512.8 ns |    73.07 ns |    64.77 ns |   8,753 B |    8248 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 8KB          |  17,065.5 ns |    49.20 ns |    41.08 ns |  22,596 B |     256 B |
|                                                |              |              |             |             |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 128KB        | 161,986.0 ns |   288.20 ns |   240.66 ns |        NA |         - |
| TryComputeHash · KMAC-128 · OS Native          | 128KB        | 236,886.0 ns | 1,314.11 ns | 1,164.93 ns |   8,964 B |  131151 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 128KB        | 247,946.9 ns |   746.21 ns |   698.00 ns |  22,774 B |     256 B |
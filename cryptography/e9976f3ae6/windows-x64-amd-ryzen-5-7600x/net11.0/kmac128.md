| Description                                    | TestDataSize | Mean         | Error       | StdDev    | Code Size | Allocated |
|----------------------------------------------- |------------- |-------------:|------------:|----------:|----------:|----------:|
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 128B         |     739.3 ns |     2.32 ns |   1.94 ns |  18,937 B |         - |
| TryComputeHash · KMAC-128 · OS Native          | 128B         |   1,164.4 ns |     4.77 ns |   4.23 ns |  16,653 B |     184 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 128B         |   2,262.4 ns |     5.42 ns |   4.52 ns |  25,471 B |     256 B |
|                                                |              |              |             |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 137B         |     738.8 ns |     2.34 ns |   1.95 ns |  18,747 B |         - |
| TryComputeHash · KMAC-128 · OS Native          | 137B         |   1,162.9 ns |     6.78 ns |   6.01 ns |  10,484 B |     200 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 137B         |   2,259.0 ns |     6.61 ns |   5.86 ns |  18,751 B |     256 B |
|                                                |              |              |             |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 1KB          |   2,127.2 ns |     6.21 ns |   5.18 ns |  12,408 B |         - |
| TryComputeHash · KMAC-128 · OS Native          | 1KB          |   2,878.9 ns |     6.73 ns |   5.62 ns |  16,667 B |    1080 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 1KB          |   4,379.8 ns |    25.84 ns |  24.17 ns |  18,968 B |     256 B |
|                                                |              |              |             |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 1025B        |   2,135.0 ns |    21.02 ns |  18.63 ns |  12,408 B |         - |
| TryComputeHash · KMAC-128 · OS Native          | 1025B        |   2,896.4 ns |    15.58 ns |  14.57 ns |  17,255 B |    1088 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 1025B        |   4,362.8 ns |    15.38 ns |  13.64 ns |  18,968 B |     256 B |
|                                                |              |              |             |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 8KB          |  11,849.1 ns |    24.44 ns |  20.41 ns |  12,399 B |         - |
| TryComputeHash · KMAC-128 · OS Native          | 8KB          |  15,016.6 ns |    52.51 ns |  43.85 ns |  17,084 B |    8248 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 8KB          |  19,160.4 ns |    63.89 ns |  56.63 ns |  26,320 B |     256 B |
|                                                |              |              |             |           |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 128KB        | 181,165.0 ns |   474.76 ns | 420.86 ns |  18,734 B |         - |
| TryComputeHash · KMAC-128 · OS Native          | 128KB        | 268,045.3 ns | 1,103.80 ns | 921.73 ns |  18,228 B |  131191 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 128KB        | 275,479.2 ns |   954.15 ns | 845.83 ns |  19,887 B |     256 B |
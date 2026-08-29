| Description                                    | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|----------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 128B         |     666.7 ns |     1.83 ns |     1.62 ns |        NA |         - |
| TryComputeHash · KMAC-128 · OS Native          | 128B         |   1,047.4 ns |    18.72 ns |    17.51 ns |   8,532 B |     184 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 128B         |   2,028.4 ns |     9.95 ns |     8.82 ns |  19,450 B |     256 B |
|                                                |              |              |             |             |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 137B         |     666.1 ns |     1.93 ns |     1.71 ns |        NA |         - |
| TryComputeHash · KMAC-128 · OS Native          | 137B         |   1,039.2 ns |     6.38 ns |     4.98 ns |   8,539 B |     200 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 137B         |   2,038.5 ns |     6.81 ns |     6.03 ns |  19,438 B |     256 B |
|                                                |              |              |             |             |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 1KB          |   1,905.8 ns |     9.90 ns |     7.73 ns |        NA |         - |
| TryComputeHash · KMAC-128 · OS Native          | 1KB          |   2,585.3 ns |    14.09 ns |    11.00 ns |   8,526 B |    1080 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 1KB          |   3,900.8 ns |    14.89 ns |    12.44 ns |  19,508 B |     256 B |
|                                                |              |              |             |             |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 1025B        |   1,915.0 ns |     6.09 ns |     4.75 ns |        NA |         - |
| TryComputeHash · KMAC-128 · OS Native          | 1025B        |   2,603.8 ns |    14.14 ns |    13.22 ns |   8,527 B |    1088 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 1025B        |   3,962.2 ns |    13.33 ns |    11.13 ns |  19,508 B |     256 B |
|                                                |              |              |             |             |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 8KB          |  10,550.2 ns |    52.22 ns |    43.60 ns |        NA |         - |
| TryComputeHash · KMAC-128 · OS Native          | 8KB          |  13,425.5 ns |    70.04 ns |    58.49 ns |   8,744 B |    8248 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 8KB          |  16,987.0 ns |    55.08 ns |    51.52 ns |  22,620 B |     256 B |
|                                                |              |              |             |             |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 128KB        | 162,251.6 ns | 1,660.35 ns | 1,630.69 ns |        NA |         - |
| TryComputeHash · KMAC-128 · OS Native          | 128KB        | 234,155.4 ns | 1,761.05 ns | 1,561.12 ns |   8,455 B |  131151 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 128KB        | 252,362.3 ns | 2,890.27 ns | 3,440.66 ns |  22,766 B |     256 B |
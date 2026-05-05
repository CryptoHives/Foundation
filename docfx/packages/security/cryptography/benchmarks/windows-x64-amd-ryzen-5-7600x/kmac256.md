| Description                                    | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 128B         |     629.6 ns |     3.16 ns |     2.80 ns |         - |
| TryComputeHash · KMAC-256 · OS Native          | 128B         |   1,006.4 ns |     5.70 ns |     5.33 ns |     184 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 128B         |   1,952.9 ns |    15.74 ns |    14.73 ns |     256 B |
|                                                |              |              |             |             |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 137B         |     826.2 ns |     4.23 ns |     3.30 ns |         - |
| TryComputeHash · KMAC-256 · OS Native          | 137B         |   1,257.4 ns |     6.32 ns |     5.61 ns |     200 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 137B         |   2,241.1 ns |    13.80 ns |    12.23 ns |     256 B |
|                                                |              |              |             |             |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 1KB          |   2,012.7 ns |    12.28 ns |    11.49 ns |         - |
| TryComputeHash · KMAC-256 · OS Native          | 1KB          |   2,715.3 ns |    19.65 ns |    18.38 ns |    1080 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 1KB          |   4,091.3 ns |    15.59 ns |    13.02 ns |     256 B |
|                                                |              |              |             |             |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 1025B        |   2,013.1 ns |    19.41 ns |    18.16 ns |         - |
| TryComputeHash · KMAC-256 · OS Native          | 1025B        |   2,714.8 ns |    16.76 ns |    14.86 ns |    1088 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 1025B        |   4,111.0 ns |    43.10 ns |    40.31 ns |     256 B |
|                                                |              |              |             |             |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 8KB          |  12,476.3 ns |    62.15 ns |    58.14 ns |         - |
| TryComputeHash · KMAC-256 · OS Native          | 8KB          |  15,712.9 ns |   109.22 ns |    96.82 ns |    8248 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 8KB          |  20,277.5 ns |   125.13 ns |   110.93 ns |     256 B |
|                                                |              |              |             |             |           |
| TryComputeHash · KMAC-256 · CryptoHives-Scalar | 128KB        | 190,673.8 ns |   958.36 ns |   849.56 ns |         - |
| TryComputeHash · KMAC-256 · OS Native          | 128KB        | 264,992.3 ns | 1,632.14 ns | 1,446.85 ns |  131151 B |
| TryComputeHash · KMAC-256 · BouncyCastle       | 128KB        | 294,836.4 ns | 1,281.56 ns | 1,198.77 ns |     256 B |
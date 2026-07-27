| Description                                    | TestDataSize | Mean         | Error       | StdDev      | Code Size | Allocated |
|----------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|----------:|
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 128B         |     657.1 ns |     4.38 ns |     4.10 ns |        NA |         - |
| TryComputeHash · KMAC-128 · OS Native          | 128B         |   1,020.5 ns |    12.39 ns |    10.98 ns |   8,545 B |     184 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 128B         |   2,033.2 ns |    14.89 ns |    13.20 ns |  19,101 B |     256 B |
|                                                |              |              |             |             |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 137B         |     657.5 ns |     6.00 ns |     5.61 ns |        NA |         - |
| TryComputeHash · KMAC-128 · OS Native          | 137B         |   1,035.2 ns |    14.81 ns |    13.86 ns |   8,470 B |     200 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 137B         |   2,032.4 ns |    18.41 ns |    17.22 ns |  19,092 B |     256 B |
|                                                |              |              |             |             |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 1KB          |   1,880.4 ns |    14.27 ns |    13.35 ns |        NA |         - |
| TryComputeHash · KMAC-128 · OS Native          | 1KB          |   2,574.5 ns |    33.68 ns |    29.86 ns |   8,527 B |    1080 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 1KB          |   3,916.4 ns |    32.36 ns |    28.68 ns |  19,108 B |     256 B |
|                                                |              |              |             |             |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 1025B        |   1,876.1 ns |    11.94 ns |    10.59 ns |        NA |         - |
| TryComputeHash · KMAC-128 · OS Native          | 1025B        |   2,570.4 ns |    29.43 ns |    26.09 ns |   8,693 B |    1088 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 1025B        |   3,915.3 ns |    34.07 ns |    31.87 ns |  19,131 B |     256 B |
|                                                |              |              |             |             |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 8KB          |  10,448.8 ns |    79.90 ns |    74.74 ns |        NA |         - |
| TryComputeHash · KMAC-128 · OS Native          | 8KB          |  13,271.7 ns |   108.22 ns |   101.23 ns |   8,747 B |    8248 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 8KB          |  17,085.3 ns |    70.22 ns |    62.25 ns |  17,589 B |     256 B |
|                                                |              |              |             |             |           |           |
| TryComputeHash · KMAC-128 · CryptoHives-Scalar | 128KB        | 158,923.2 ns |   783.85 ns |   654.55 ns |        NA |         - |
| TryComputeHash · KMAC-128 · OS Native          | 128KB        | 228,685.0 ns | 1,114.74 ns | 1,042.72 ns |   8,980 B |  131151 B |
| TryComputeHash · KMAC-128 · BouncyCastle       | 128KB        | 247,724.8 ns | 1,827.83 ns | 1,709.75 ns |  17,726 B |     256 B |
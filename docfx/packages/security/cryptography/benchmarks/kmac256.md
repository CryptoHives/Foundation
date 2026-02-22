| Description                              | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| TryComputeHash · KMAC-256 · Managed      | 128B         |     666.6 ns |     3.65 ns |     3.05 ns |         - |
| TryComputeHash · KMAC-256 · OS Native    | 128B         |     998.1 ns |     4.72 ns |     3.94 ns |     184 B |
| TryComputeHash · KMAC-256 · BouncyCastle | 128B         |   1,946.6 ns |    10.75 ns |     9.53 ns |     256 B |
|                                          |              |              |             |             |           |
| TryComputeHash · KMAC-256 · Managed      | 137B         |     911.5 ns |     3.40 ns |     3.19 ns |         - |
| TryComputeHash · KMAC-256 · OS Native    | 137B         |   1,258.0 ns |    11.30 ns |    10.57 ns |     200 B |
| TryComputeHash · KMAC-256 · BouncyCastle | 137B         |   2,238.9 ns |    15.88 ns |    14.86 ns |     256 B |
|                                          |              |              |             |             |           |
| TryComputeHash · KMAC-256 · Managed      | 1KB          |   2,067.5 ns |    14.56 ns |    13.62 ns |         - |
| TryComputeHash · KMAC-256 · OS Native    | 1KB          |   2,702.5 ns |     6.43 ns |     5.70 ns |    1080 B |
| TryComputeHash · KMAC-256 · BouncyCastle | 1KB          |   4,070.0 ns |    28.05 ns |    26.23 ns |     256 B |
|                                          |              |              |             |             |           |
| TryComputeHash · KMAC-256 · Managed      | 1025B        |   2,056.8 ns |    10.78 ns |     9.56 ns |         - |
| TryComputeHash · KMAC-256 · OS Native    | 1025B        |   2,696.0 ns |    17.38 ns |    16.26 ns |    1088 B |
| TryComputeHash · KMAC-256 · BouncyCastle | 1025B        |   4,067.2 ns |    24.84 ns |    22.02 ns |     256 B |
|                                          |              |              |             |             |           |
| TryComputeHash · KMAC-256 · Managed      | 8KB          |  12,491.8 ns |    88.68 ns |    82.95 ns |         - |
| TryComputeHash · KMAC-256 · OS Native    | 8KB          |  15,646.1 ns |   139.58 ns |   130.57 ns |    8248 B |
| TryComputeHash · KMAC-256 · BouncyCastle | 8KB          |  20,164.1 ns |   110.33 ns |   103.21 ns |     256 B |
|                                          |              |              |             |             |           |
| TryComputeHash · KMAC-256 · Managed      | 128KB        | 189,838.3 ns | 1,320.60 ns | 1,235.29 ns |         - |
| TryComputeHash · KMAC-256 · OS Native    | 128KB        | 263,347.0 ns | 1,215.03 ns | 1,014.60 ns |  131151 B |
| TryComputeHash · KMAC-256 · BouncyCastle | 128KB        | 293,350.7 ns | 1,650.91 ns | 1,463.49 ns |     256 B |